using Asp.Versioning;
using Asp.Versioning.Builder;
using Caching.Distributed.Redis.Common.Utils;

namespace Caching.Distributed.Redis.Common.Extensions;

public static class GetLatestApiVersionExtension
{
    public static ApiVersion GetLatestApiVersion(this ApiVersionSet apiVersionSet)
    {
        return ApiVersioningUtil.GetLatestApiVersion(apiVersionSet);
    }
    
    public static ApiVersion GetFirstApiVersion(this ApiVersionSet apiVersionSet)
    {
        return ApiVersioningUtil.GetFirstApiVersion(apiVersionSet);
    }
    
    public static ApiVersion GetApiVersion(this ApiVersionSet apiVersionSet, int version)
    {
        return ApiVersioningUtil.GetApiVersion(apiVersionSet, version);
    }
}