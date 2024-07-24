using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHealthChecks()
    .AddRedis(
        redisConnectionString: "localhost:6379",
        name: "Redis Check",
        failureStatus: HealthStatus.Degraded | HealthStatus.Unhealthy,
        tags: new string[] { "redis" }
    )
    .AddNpgSql(
        connectionString: "User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=postgres",
        name: "PostgreSQL Check",
        failureStatus: HealthStatus.Degraded | HealthStatus.Unhealthy,
        healthQuery: "SELECT 1",
        tags: new string[] { "postgresql" }
    );

var app = builder.Build();
app.UseHealthChecks("/health", new HealthCheckOptions()
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();
