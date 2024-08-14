using Comix.Core.ElasticSearch;
using Comix.Core.Entity;
using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using Furion.LinqBuilder;
using Microsoft.Extensions.Logging;

namespace Comix.Core.Logging;
/// <summary>
/// ES服务注册
/// </summary>
public static class ElasticSearchLogSetup
{
    public static void AddElasticSearchLog(this IServiceCollection services)
    {
        var enabled = App.GetConfig<bool>("Logging:ElasticSearch:Enabled");
        if (!enabled) return;

        var logEsName = App.GetConfig<string>("Logging:ElasticSearch:Name");
        if (!logEsName.IsNullOrEmpty())
        {
            var esFactory = App.GetService<ElasticSearchFactory>();
            var exists = esFactory.Exists(logEsName);
            if (!exists)
            {
                var logger = App.GetService<ILogger>();
                logger.LogError($"日志es【{logEsName}】不存在");
            }

            return;
        }
        
        //兼容原来的逻辑
        var serverUris = App.GetConfig<List<string>>("Logging:ElasticSearch:ServerUris");

        ElasticSearchFactory factory = new ElasticSearchFactory();
        factory.AddClient(new EsConfig()
        {
            Name = "Log",
            Password = App.GetConfig<string>("Logging:ElasticSearch:Password"),
            UserName = App.GetConfig<string>("Logging:ElasticSearch:UserName"),
            Uris = serverUris
        });
        
        services.AddSingleton(factory);
    }
}