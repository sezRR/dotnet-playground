using Asp.Versioning.Builder;
using Caching.InMemory.InMemoryCaching.Common.Interfaces;

namespace Caching.InMemory.InMemoryCaching.Endpoints;

public class TestEndpoints : IEndpointModule
{
    public void MapEndpoints(IEndpointRouteBuilder routes, ApiVersionSet apiVersionSet)
    {
        routes.MapGet("/", async () => await Task.FromResult(Results.Ok("Hello World!"))).MapToApiVersion(2);
    }
}