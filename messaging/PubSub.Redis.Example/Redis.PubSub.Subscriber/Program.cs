using StackExchange.Redis;

var redisConnection = await ConnectionMultiplexer.ConnectAsync("localhost:6379");

ISubscriber subscriber = redisConnection.GetSubscriber();

await subscriber.SubscribeAsync("mychannel.*", (channel, message) =>
{
    Console.WriteLine($"{channel} -> {message}");
});

Console.ReadLine();