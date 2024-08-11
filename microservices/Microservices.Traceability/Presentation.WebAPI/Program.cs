using NLog.Web;
using Presentation.WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region NLog Setup

builder.Logging.ClearProviders();
builder.Host.UseNLog();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<CorrelationIdMiddleware>();
app.UseMiddleware<OtherMiddleware>();

app.MapGet("/", (HttpContext context, ILogger<Program> logger) =>
{
    var correlationId = context.Request.Headers["X-Correlation-Id"];
      
    NLog.ScopeContext.PushProperty("CorrelationId", correlationId);
    logger.LogInformation("Minimal API: Request ({CorrelationId}): {Request}", correlationId, context.Request.Path);
});

app.Run();
