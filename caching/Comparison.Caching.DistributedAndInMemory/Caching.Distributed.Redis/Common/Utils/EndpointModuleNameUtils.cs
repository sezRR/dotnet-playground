using Caching.Distributed.Redis.Common.Interfaces;

namespace Caching.Distributed.Redis.Common.Utils;

public static class EndpointModuleNameUtils
{
    public static string GetEndpointModuleName(IEndpointModule endpointModule)
    {
        return endpointModule.GetType().Name;
    }
    
    public static string MakeEndpointModuleNamePlural(string uncheckedModuleName)
    {
        var moduleName = uncheckedModuleName.EndsWith("Endpoints") 
            ? uncheckedModuleName.Split("Endpoints")[0]
            : uncheckedModuleName;

        if (moduleName.EndsWith('s') || moduleName.EndsWith('x') || moduleName.EndsWith('z') || 
              moduleName.EndsWith("ch") || moduleName.EndsWith("sh"))
        {
            return moduleName + "es";
        }

        return moduleName + "s";
    }
    
    public static string MakeEndpointModuleNamePlural(IEndpointModule endpointModule)
    {
        return MakeEndpointModuleNamePlural(GetEndpointModuleName(endpointModule));
    }
}