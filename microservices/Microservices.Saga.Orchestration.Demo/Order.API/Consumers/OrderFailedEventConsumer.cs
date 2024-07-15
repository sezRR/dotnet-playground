﻿using MassTransit;
using Order.API.Contexts;
using Shared.OrderEvents;

namespace Order.API.Consumers;

public class OrderFailedEventConsumer(OrderDbContext orderDbContext) : IConsumer<OrderFailedEvent>
{
    public async Task Consume(ConsumeContext<OrderFailedEvent> context)
    {
        Models.Order? order = await orderDbContext.Orders.FindAsync(context.Message.OrderId);

        if (order != null)
        {
            order.OrderStatus = Enums.OrderStatus.Failed;
            await orderDbContext.SaveChangesAsync();
        }

    }
}
