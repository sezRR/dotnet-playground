using MassTransit;
using MongoDB.Driver;
using Shared;
using Shared.Events;
using Stock.API.Models;
using Stock.API.Services;

namespace Stock.API.Consumers;

public class OrderCreatedEventConsumer(
    MongoDBService mongoDBService, 
    ISendEndpointProvider sendEndpointProvider,
    IPublishEndpoint publishEndpoint
) : IConsumer<OrderCreatedEvent>
{
    public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
    {
        List<bool> stockResult = new();
        IMongoCollection<Models.Stock> collection = mongoDBService.GetCollection<Models.Stock>();

        foreach (var orderItem in context.Message.OrderItems)
        {
            stockResult.Add(await (await collection.FindAsync(s => s.ProductId == orderItem.ProductId.ToString() && s.Count >= (long) orderItem.Count)).AnyAsync());
        }

        if (stockResult.TrueForAll(s => s.Equals(true)))
        {
            // Stock update
            foreach (var orderItem in context.Message.OrderItems)
            {
                Models.Stock stock = await (await collection.FindAsync(s => s.ProductId == orderItem.ProductId.ToString())).FirstOrDefaultAsync();

                stock.Count -= orderItem.Count;

                await collection.FindOneAndReplaceAsync(x => x.ProductId == orderItem.ProductId.ToString(), stock);
            }

            // Payment event
            var sendEndpoint = await sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{RabbitMQSettings.Payment_StockReservedEventQueue}"));
            StockReservedEvent stockReservedEvent = new()
            {
                BuyerId = context.Message.BuyerId,
                OrderId = context.Message.OrderId,
                TotalPrice = context.Message.TotalPrice,
                OrderItems = context.Message.OrderItems,
            };

            await sendEndpoint.Send(stockReservedEvent);
        }
        else
        {
            // Stock process unfailed

            // Order trigger event
            StockNotReservedEvent stockNotReservedEvent = new()
            {
                BuyerId = context.Message.BuyerId,
                OrderId = context.Message.OrderId,
                Message = "Insufficient stock quantity",
            };

            await publishEndpoint.Publish(stockNotReservedEvent);
        }
    }
}
