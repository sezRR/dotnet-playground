using Microsoft.AspNetCore.Http.HttpResults;
using Redis.Sentinel.WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var endpointsCacheGroup = app.MapGroup("/cache");

endpointsCacheGroup.MapPut("/value/{key}", async (string key, string value) =>
{
    var redis = await RedisService.RedisMasterDatabase();
    await redis.StringSetAsync(key, value);
    return Results.Ok($"{key} -> {value}");
});
endpointsCacheGroup.MapGet("/value/{key}", async (string key) =>
{
    var redis = await RedisService.RedisMasterDatabase();
    var data = await redis.StringGetAsync(key);
    return Results.Ok(data.ToString());
});

app.Run();
