using Asp.Versioning.Builder;
using Caching.InMemory.InMemoryCaching.Common.Extensions;
using Caching.InMemory.InMemoryCaching.Common.Interfaces;

namespace Caching.InMemory.InMemoryCaching.Endpoints;

public class ProductEndpoints : IEndpointModule
{
    public void MapEndpoints(IEndpointRouteBuilder routes, ApiVersionSet apiVersionSet)
    {
        routes.MapPost("/", async (string dto) => await Task.FromResult(Results.Ok(dto))).MapToApiVersion(1);
        
        routes.MapPost("/", async (string dto) => await Task.FromResult(Results.Ok(dto)))
            .MapToApiVersion(apiVersionSet.GetLatestApiVersion());
    }
}