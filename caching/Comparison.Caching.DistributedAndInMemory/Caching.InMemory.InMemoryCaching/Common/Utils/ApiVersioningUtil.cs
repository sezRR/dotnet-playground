using Asp.Versioning;
using Asp.Versioning.Builder;

namespace Caching.InMemory.InMemoryCaching.Common.Utils;

public static class ApiVersioningUtil
{
    public static ApiVersion GetLatestApiVersion(ApiVersionSet apiVersionSet)
    {
        return apiVersionSet.Build(new ApiVersioningOptions()).SupportedApiVersions.Last();
    }
    
    public static ApiVersion GetFirstApiVersion(ApiVersionSet apiVersionSet)
    {
        return apiVersionSet.Build(new ApiVersioningOptions()).SupportedApiVersions.First();
    }
    
    public static ApiVersion GetApiVersion(ApiVersionSet apiVersionSet, int version)
    {
        return apiVersionSet.Build(new ApiVersioningOptions()).SupportedApiVersions.SingleOrDefault(apiVersion => apiVersion.MajorVersion == version, GetLatestApiVersion(apiVersionSet));
    }
}