using System.Text;
using Asp.Versioning.Builder;
using Caching.Distributed.Redis.Common.Extensions;
using Caching.Distributed.Redis.Common.Interfaces;
using Microsoft.Extensions.Caching.Distributed;

namespace Caching.Distributed.Redis.Endpoints;

public class RedisEndpoints(IDistributedCache distributedCache) : IEndpointModule
{
    public void MapEndpoints(IEndpointRouteBuilder routes, ApiVersionSet apiVersionSet)
    {
        routes.MapGet("/cache", async () =>
        {
            // byte[] value = await distributedCache.GetAsync("cache");
            // return Results.Ok(value);
            
            string? firstName = await distributedCache.GetStringAsync("name");
            byte[]? lastName = await distributedCache.GetAsync("surname");
            string lastNameString = Encoding.UTF8.GetString(lastName ?? []);
            
            return Results.Ok(new
            {
                name = firstName,
                surname = lastNameString
            });
        }).MapToApiVersion(apiVersionSet.GetLatestApiVersion());
        
        routes.MapPost("/cache", async (string firstName, string lastName) =>
        {
            // await distributedCache.SetAsync("cache", Encoding.UTF8.GetBytes(value));
            await distributedCache.SetStringAsync("name", firstName, options: new()
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(30),
                SlidingExpiration = TimeSpan.FromSeconds(5)
            });
            
            await distributedCache.SetAsync("surname", Encoding.UTF8.GetBytes(lastName), options: new()
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(30),
                SlidingExpiration = TimeSpan.FromSeconds(5)
            });
            
            return Results.Ok();
        }).MapToApiVersion(apiVersionSet.GetLatestApiVersion());
    }
}