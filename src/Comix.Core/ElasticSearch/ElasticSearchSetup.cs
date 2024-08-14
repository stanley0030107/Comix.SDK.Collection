using Comix.Core.DbMonitor;

namespace Comix.Core.ElasticSearch;

public static class ElasticSearchSetup
{
    public static IServiceCollection AddElasticSearch(this IServiceCollection services)
    {
        var esConfigs = App.GetConfig<List<EsConfig>>("ElasticSearchs");
        if (esConfigs == null || !esConfigs.Any()) return services;

        ElasticSearchFactory factory = new ElasticSearchFactory();
        foreach (var esConfig in esConfigs)
        {
            factory.AddClient(esConfig);
        }

        services.AddSingleton(factory);

        services.AddSingleton<IBaseEsService, BaseEsService>();
        services.AddSingleton<IInitMonitorLogAppService, InitMonitorLogAppService>();
        
        return services;
    }
}