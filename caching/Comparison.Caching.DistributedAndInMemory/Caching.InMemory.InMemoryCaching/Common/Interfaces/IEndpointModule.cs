using Asp.Versioning.Builder;

namespace Caching.InMemory.InMemoryCaching.Common.Interfaces;

public interface IEndpointModule
{
    void MapEndpoints(IEndpointRouteBuilder routes, ApiVersionSet apiVersionSet);
}