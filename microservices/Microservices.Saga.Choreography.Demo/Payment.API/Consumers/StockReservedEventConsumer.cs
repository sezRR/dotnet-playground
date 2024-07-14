using MassTransit;
using Shared.Events;

namespace Payment.API.Consumers;

public class StockReservedEventConsumer(IPublishEndpoint publishEndpoint) : IConsumer<StockReservedEvent>
{
    public async Task Consume(ConsumeContext<StockReservedEvent> context)
    {
        if (true)
        {
            // Payment successfull
            PaymentCompletedEvent paymentCompletedEvent = new()
            {
                OrderId = context.Message.OrderId,
            };

            await publishEndpoint.Publish(paymentCompletedEvent);
            await Console.Out.WriteLineAsync("Payment successfull");
        } else
        {
            // Payment unsuccessfull
            PaymentFailedEvent paymentFailedEvent = new()
            {
                OrderId = context.Message.OrderId,
                Message = "Insufficient balance",
                OrderItems = context.Message.OrderItems
            };

            await publishEndpoint.Publish(paymentFailedEvent);
            await Console.Out.WriteLineAsync("Payment unsuccessfull");
        }
    }
}
