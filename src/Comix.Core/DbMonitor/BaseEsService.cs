using Comix.Core.ElasticSearch;
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.IndexManagement;
using Elastic.Clients.Elasticsearch.Mapping;
using Furion.LinqBuilder;
using Microsoft.Extensions.Logging;

namespace Comix.Core.DbMonitor;

public class BaseEsService : IBaseEsService
{
    protected readonly ILogger<BaseEsService> _logger;
    private static object _l = new();
    private static List<string> _indexName = new();
    private static Dictionary<Type, string> _typeIndexName = new();
    protected readonly ElasticsearchClient ElasticsearchClient;

    public BaseEsService(ILogger<BaseEsService> logger, ElasticSearchFactory factory)
    {
        _logger = logger;
        ElasticsearchClient = factory.Get("MonitorData");
    }

    /// <summary>
    /// 创建索引，如果存在则不创建
    /// </summary>
    /// <param name="key"></param>
    /// <param name="currentIndexName">索引</param>
    /// <param name="configure"></param>
    /// <exception cref="Exception"></exception>
    private void CreateIndex<T>(Guid key, string currentIndexName,
        Action<PropertiesDescriptor<T>> configure = null)
    {
        if (_indexName.Contains(currentIndexName))
        {
            return;
        }

        lock (_l)
        {
            try
            {
                var existResp = ElasticsearchClient.Indices.Exists(currentIndexName);
                if (!existResp.IsSuccess())
                {
                    throw new Exception($"{key} 判断索引是否存在失败{currentIndexName}, {existResp.DebugInformation}");
                }

                if (existResp.Exists)
                {
                    _indexName.Add(currentIndexName);
                    return;
                }

                var createIndexResponse = ElasticsearchClient.Indices.Create(currentIndexName, i => i
                    .Settings(k => k
                        .Lifecycle(new IndexSettingsLifecycle()
                        {
                            RolloverAlias = nameof(BaseEsModel.esDateTime)
                        }))
                );
                if (!createIndexResponse.IsSuccess())
                {
                    throw new Exception($"{key} 创建索引失败{currentIndexName}, {createIndexResponse.DebugInformation}");
                }

                _indexName.Add(currentIndexName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

    /// <summary>
    /// 获取es索引
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public string GetIndexName<T>() where T : BaseEsModel
    {
        var type = typeof(T);
        if (_typeIndexName.ContainsKey(type))
        {
            return _typeIndexName[type];
        }

        lock (_l)
        {
            // 获取类型上的EsIndexAttribute特性
            var attribute = type.GetCustomAttribute<EsIndexAttribute>();
            if (attribute == null || attribute.IndexName.IsNullOrEmpty())
            {
                throw new Exception($"类型{nameof(T)} 没有配置es索引，请添加特性{nameof(EsIndexAttribute)}");
            }

            _typeIndexName.Add(type, attribute.IndexName);

            return attribute.IndexName;
        }
    }

    /// <summary>
    /// 推送数据到es
    ///
    /// 1、创建索引
    /// 2、推送数据
    /// </summary>
    /// <param name="key"></param>
    /// <param name="orders"></param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="Exception"></exception>
    public async Task DoPush<T>(Guid key, T[] orders) where T : BaseEsModel
    {
        var years = orders
            .Select(o => o.esDateTime.Year).Distinct();
        foreach (var year in years)
        {
            try
            {
                var indexName = $"{GetIndexName<T>()}_{year}";
                CreateIndex<T>(key, indexName);

                var yearOrders = orders.Where(o => o.esDateTime.Year == year).ToArray();

                var insertResp = await ElasticsearchClient.IndexManyAsync(yearOrders, indexName);
                if (!insertResp.IsSuccess() || insertResp.Errors)
                {
                    _logger.LogWarning($"{key} 推送es失败 数据：{JSON.Serialize(yearOrders)}");
                    throw new Exception($"{key} 推送es失败 {insertResp.DebugInformation}");
                }
            }
            catch (Exception e)
            {
                _logger.LogWarning($"{key} 推送es失败 数据：{JSON.Serialize(orders)}");
                throw;
            }
        }
    }
}