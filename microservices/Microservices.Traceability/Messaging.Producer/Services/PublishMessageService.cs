using System.Diagnostics;
using System.Text.Json;
using MassTransit;
using Messaging.Shared;

namespace Messaging.Producer.Services;

public class PublishMessageService(IPublishEndpoint publishEndpoint, ILogger<PublishMessageService> logger)
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        var correlationId = Guid.NewGuid();
        var i = 0;
        
        while (true)
        {
            ExampleMessage message = new()
            {
                Text = $"Message: {++i}"
            };

            Trace.CorrelationManager.ActivityId = correlationId;
            logger.LogDebug("Producer: {Message} - Correlation Id : {CorrelationId}", message, correlationId);

            await Console.Out.WriteLineAsync($"{JsonSerializer.Serialize(message)} - Correlation Id : {correlationId}");
            await publishEndpoint.Publish(message, context =>
            {
                context.Headers.Set("CorrelationId", correlationId);
                return Task.CompletedTask;
            }, cancellationToken);
            
            await Task.Delay(3000, cancellationToken);
        }
    }   
}
