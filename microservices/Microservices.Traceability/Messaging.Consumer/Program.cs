using MassTransit;
using Messaging.Consumer.Consumers;
using NLog.Extensions.Logging;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddMassTransit(configurator =>
{
    configurator.AddConsumer<ExampleMessageConsumer>();

    configurator.UsingRabbitMq((context, _configurator) =>
    {
        _configurator.Host("amqps://afqsvxrt:aP2KoTqVsleK8P5vrrujOPKMVblji8jw@cow.rmq2.cloudamqp.com/afqsvxrt");

        _configurator.ReceiveEndpoint("example-message-queue", endpointConfigurator =>
        {
            endpointConfigurator.ConfigureConsumer<ExampleMessageConsumer>(context);
        });
    });
});

builder.Logging.ClearProviders();
builder.Logging.AddNLog();

var host = builder.Build();
host.Run();
