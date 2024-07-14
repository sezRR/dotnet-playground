var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/ready", () =>
{
    Console.WriteLine("Order service is ready");
    return true;
});

app.MapGet("/commit", () =>
{
    Console.WriteLine("Order service is committed");
    return false;
});

app.MapGet("/rollback", () =>
{
    Console.WriteLine("Order service is rollbacked");
});

app.Run();