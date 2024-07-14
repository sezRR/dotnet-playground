using MassTransit;
using Microsoft.EntityFrameworkCore;
using Order.API.Consumers;
using Order.API.Models;
using Order.API.Models.Contexts;
using Order.API.ViewModels;
using Shared;
using Shared.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(configuratior =>
{
    configuratior.AddConsumer<PaymentCompletedEventConsumer>();
    configuratior.AddConsumer<PaymentFailedEventConsumer>();
    configuratior.AddConsumer<StockNotReservedEventConsumer>();
    configuratior.UsingRabbitMq((context, _configure) =>
    {
        _configure.Host(builder.Configuration["RabbitMQ"]);

        _configure.ReceiveEndpoint(RabbitMQSettings.Order_PaymentCompletedEventQueue, e => e.ConfigureConsumer<PaymentCompletedEventConsumer>(context));

        _configure.ReceiveEndpoint(RabbitMQSettings.Order_PaymentFailedEventQueue, e => e.ConfigureConsumer<PaymentFailedEventConsumer>(context));

        _configure.ReceiveEndpoint(RabbitMQSettings.Order_StockNotReservedEventQueue, e => e.ConfigureConsumer<StockNotReservedEventConsumer>(context));
    });
});

builder.Services.AddDbContext<OrderAPIDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServer")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast")
//.WithOpenApi();

app.MapPost("/order", async (
    CreateOrderVM model, 
    OrderAPIDbContext context,
    IPublishEndpoint publishEndpoint
) =>
{
    Order.API.Models.Order order = new()
    {
        BuyerId = Guid.TryParse(model.BuyerId, out Guid _buyerId) ? _buyerId : Guid.NewGuid(),
        OrderItems = model.OrderItems.Select(oi => new OrderItem()
        {
            Count = oi.Count,
            Price = oi.Price,
            ProductId = Guid.Parse(oi.ProductId),
        }).ToList(),
        OrderStatus = Order.API.Enums.OrderStatus.Suspend,
        CreatedDate = DateTime.UtcNow,
        TotalPrice = model.OrderItems.Sum(oi => oi.Price * oi.Count),
    };

    await context.Orders.AddAsync(order);
    await context.SaveChangesAsync();

    OrderCreatedEvent orderCreatedEvent = new()
    {
        BuyerId = order.BuyerId,
        OrderId = order.Id,
        TotalPrice = order.TotalPrice,
        OrderItems = order.OrderItems.Select(oi => new Shared.Messages.OrderItemMessage()
        {
            Count = oi.Count,
            Price = oi.Price,
            ProductId = oi.ProductId,
        }).ToList(),
    };

    await publishEndpoint.Publish(orderCreatedEvent);
});

app.Run();
