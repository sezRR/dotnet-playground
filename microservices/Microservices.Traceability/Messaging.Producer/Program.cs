using MassTransit;
using Messaging.Producer.Services;
using NLog.Extensions.Logging;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddMassTransit(configurator =>
{
    configurator.UsingRabbitMq((_, _configurator) =>
    {
        _configurator.Host("amqps://afqsvxrt:aP2KoTqVsleK8P5vrrujOPKMVblji8jw@cow.rmq2.cloudamqp.com/afqsvxrt");
    });
});

builder.Logging.ClearProviders();
builder.Logging.AddNLog();

builder.Services.AddHostedService<PublishMessageService>(provider =>
{
    using IServiceScope scope = provider.CreateScope();
    
    IPublishEndpoint publishEndpoint = scope.ServiceProvider.GetService<IPublishEndpoint>()!;
    var logger = scope.ServiceProvider.GetService<ILogger<PublishMessageService>>();
    
    return new(publishEndpoint, logger!);
});

var host = builder.Build();
host.Run();
