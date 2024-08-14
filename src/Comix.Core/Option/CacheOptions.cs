using Furion.ConfigurableOptions;

namespace Comix.Core.Option;
/// <summary>
/// 缓存配置选项
/// </summary>
public sealed class CacheOptions : IConfigurableOptions
{
    /// <summary>
    /// 缓存类型
    /// </summary>
    public string CacheType { get; set; }

    /// <summary>
    /// Redis连接字符串
    /// </summary>
    public string RedisConnectionString { get; set; }

    /// <summary>
    /// 数据库编号
    /// </summary>
    public int DefaultDB {
        get
        {
            if (string.IsNullOrEmpty(RedisConnectionString))
            {
                return 0;
            }

            var kvs = RedisConnectionString.Split(',');
            if (kvs == null || kvs.Length == 0)
            {
                return 0;
            }

            var defaultDatabaseKV = kvs.Where(o => o.Contains("defaultDatabase")).FirstOrDefault();
            if (string.IsNullOrEmpty(defaultDatabaseKV))
            {
                return 0;
            }

            var kv = defaultDatabaseKV.Split('=');
            if (kv == null || kv.Length != 2)
            {
                return 0;
            }

            var b = int.TryParse(kv[1],out var defaultDatabase);
            if (!b)
            {
                return 0;
            }

            return defaultDatabase;
        }
    } 
}
