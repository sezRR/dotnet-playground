using Asp.Versioning.Builder;

namespace Caching.Distributed.Redis.Common.Interfaces;

public interface IEndpointModule
{
    void MapEndpoints(IEndpointRouteBuilder routes, ApiVersionSet apiVersionSet);
}