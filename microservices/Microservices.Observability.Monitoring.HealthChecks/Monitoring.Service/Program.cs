var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecksUI(settings =>
{
    settings.AddHealthCheckEndpoint("Service A", "https://localhost:7061/health");
    settings.AddHealthCheckEndpoint("Service B", "https://localhost:7087/health");
    settings.SetEvaluationTimeInSeconds(30);
    settings.SetApiMaxActiveRequests(2);
}).AddSqlServerStorage("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HealthCheckUIDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

var app = builder.Build();

app.UseHealthChecksUI(options => options.UIPath = "/health");

app.Run();