using Elastic.Clients.Elasticsearch.Mapping;

namespace Comix.Core.DbMonitor;

public interface IBaseEsService : ISingleton
{
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
    Task DoPush<T>(Guid key, T[] orders) where T : BaseEsModel;

    /// <summary>
    /// 获取es索引
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public string GetIndexName<T>() where T : BaseEsModel;
}