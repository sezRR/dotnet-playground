using StackExchange.Redis;

var redisConnection = await ConnectionMultiplexer.ConnectAsync("localhost:6379");

ISubscriber subscriber = redisConnection.GetSubscriber();

while (true)
{ 
    Console.Write("Message: ");

    string message = Console.ReadLine()!;
    await subscriber.PublishAsync("mychannel", message);
}