var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", (HttpContext context) =>
{
    var actual_client_ip = context.Request.Headers["X-Forwarded-For"];
    var client_ip = context.Connection.RemoteIpAddress;
    
    return $"Actual Client IP: {actual_client_ip} | Client IP: {client_ip} | Instance: {args[0]}";
});

app.Run();

