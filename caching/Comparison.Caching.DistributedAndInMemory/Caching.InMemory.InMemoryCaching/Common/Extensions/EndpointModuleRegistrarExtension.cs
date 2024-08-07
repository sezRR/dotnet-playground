using Asp.Versioning;
using Asp.Versioning.Builder;
using Caching.InMemory.InMemoryCaching.Common.Interfaces;
using Caching.InMemory.InMemoryCaching.Common.Utils;

namespace Caching.InMemory.InMemoryCaching.Common.Extensions;

public static class EndpointModuleRegistrarExtension
{
    public static void AddModules(this IServiceCollection serviceCollection)
    {
        serviceCollection.Scan(scan => scan
            .FromAssemblyOf<IEndpointModule>()
            .AddClasses(classes => classes.AssignableTo<IEndpointModule>())
            .As<IEndpointModule>()
            .WithSingletonLifetime());
    }
    
    public static void UseModules(this WebApplication app)
    {
        ApiVersionSet apiVersionSet = app.NewApiVersionSet()
            .HasApiVersion(new ApiVersion(2))
            .HasApiVersion(new ApiVersion(3))
            .HasDeprecatedApiVersion(new ApiVersion(1))
            .ReportApiVersions()
            .Build();
        
        var modules = app.Services.GetServices<IEndpointModule>();
        foreach (var module in modules)
        {
            var moduleName = EndpointModuleNameUtils.MakeEndpointModuleNamePlural(module);
            var versionedRouteGroupBuilder = app
                .MapGroup($"/api/v{{apiVersion:apiVersion}}/{moduleName.ToLower()}")
                .WithApiVersionSet(apiVersionSet)
                .WithTags(moduleName);
            
            module.MapEndpoints(versionedRouteGroupBuilder, apiVersionSet);
        }
    }
}