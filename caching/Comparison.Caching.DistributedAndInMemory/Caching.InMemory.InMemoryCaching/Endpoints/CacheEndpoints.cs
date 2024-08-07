using Asp.Versioning.Builder;
using Caching.InMemory.InMemoryCaching.Common.Extensions;
using Caching.InMemory.InMemoryCaching.Common.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Caching.InMemory.InMemoryCaching.Endpoints;

public class CacheEndpoints(IMemoryCache memoryCache) : IEndpointModule
{
    public void MapEndpoints(IEndpointRouteBuilder routes, ApiVersionSet apiVersionSet)
    {
        #region API v2
        routes.MapGet("/cache", async () =>
        {
            if (memoryCache.TryGetValue("name", out string? name))
                return await Task.FromResult(name);

            return await Task.FromResult("No name in cache");
        }).MapToApiVersion(apiVersionSet.GetApiVersion(2));
        
        routes.MapPost("/cache/{name}", (string name) =>
        {
            memoryCache.Set("name", name, TimeSpan.FromSeconds(10));

            return Task.CompletedTask;
        }).MapToApiVersion(apiVersionSet.GetFirstApiVersion());
        #endregion
        
        #region API v3
        routes.MapGet("/cache", async () =>
        {
            if (memoryCache.TryGetValue("date", out DateTime? dateTime))
                return await Task.FromResult(dateTime.ToString());

            return await Task.FromResult("No date in cache");
        }).MapToApiVersion(apiVersionSet.GetLatestApiVersion());
        
        routes.MapPost("/cache", () =>
        {
            memoryCache.Set("date", DateTime.Now, options: new()
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(10),
                SlidingExpiration = TimeSpan.FromSeconds(5),
            });

            return Task.CompletedTask;
        }).MapToApiVersion(apiVersionSet.GetLatestApiVersion());
        #endregion
    }
}