using System.Collections.Concurrent;
using Grpc.Core.Logging;
using RedLockNet;
using RedLockNet.SERedis;
using RedLockNet.SERedis.Configuration;
using StackExchange.Redis;
using Exception = System.Exception;

namespace Comix.Core.Helpers;

public class RedisHelper : IDisposable
{
    private string _connectionString; //连接字符串
    private string _instanceName; //实例名称
    private int _defaultDB; //默认数据库
    private ConcurrentDictionary<string, ConnectionMultiplexer> _connections;

    private RedLockFactory redLockFactory;


    public RedisHelper(string connectionString, string instanceName, int defaultDB = 0)
    {
        _connectionString = connectionString;
        _instanceName = instanceName;
        _defaultDB = defaultDB;
        _connections = new ConcurrentDictionary<string, ConnectionMultiplexer>();
    }

    /// <summary>
    /// 获取ConnectionMultiplexer
    /// </summary>
    /// <returns></returns>
    public ConnectionMultiplexer GetConnect()
    {
        return _connections.GetOrAdd(_instanceName, p => ConnectionMultiplexer.Connect(_connectionString));
    }

    /// <summary>
    /// 获取数据库
    /// </summary>
    /// <param name="configName"></param>
    /// <param name="db">默认为0：优先代码的db配置，其次config中的配置</param>
    /// <returns></returns>
    public IDatabase GetDatabase()
    {
        return GetConnect().GetDatabase(_defaultDB);
    }

    public IServer GetServer(string configName = null, int endPointsIndex = 0)
    {
        var confOption = ConfigurationOptions.Parse(_connectionString);
        return GetConnect().GetServer(confOption.EndPoints[endPointsIndex]);
    }

    public ISubscriber GetSubscriber(string configName = null)
    {
        return GetConnect().GetSubscriber();
    }

    public Task<bool> ExistsAsync(string key)
    {
        return GetDatabase().KeyExistsAsync(key);
    }

    public async Task<T> GetAsync<T>(string key, CommandFlags flags = CommandFlags.None)
    {
        var cacheValue = await GetDatabase().StringGetAsync(key, flags);
        if (!cacheValue.HasValue)
        {
            return default;
        }

        bool b = JsonUtil.TryToObject<T>(cacheValue.ToString(), out T value, out Exception e);
        if (!b)
        {
            return default;
        }

        return value;
    }

    public async Task<T> GetAsync<T>(string key, Func<T> func, TimeSpan timeSpan, When when = When.Always,
        CommandFlags flags = CommandFlags.None)
    {
        try
        {
            var _ = await GetAsync<T>(key);
            if (_ != null && !_.Equals(default(T)))
            {
                return _;
            }
        }
        catch
        {
        }

        var obj = func();
        if (obj == null)
        {
            return obj;
        }

        try
        {
            await SetAsync(key, obj, timeSpan, when, flags);
        }
        catch
        {
        }

        return obj;
    }

    public async Task<T> GetAsync<T>(string key, Func<Task<T>> func, TimeSpan timeSpan, When when = When.Always,
        CommandFlags flags = CommandFlags.None)
    {
        try
        {
            var _ = await GetAsync<T>(key);
            if (_ != null && !_.Equals(default(T)))
            {
                return _;
            }


            var obj = await func();
            if (obj == null)
            {
                return obj;
            }

            await SetAsync(key, obj, timeSpan, when, flags);

            return obj;
        }
        catch(Exception e)
        {
            throw;
        }
    }

    public Task<bool> SetAsync<T>(string key, T obj, TimeSpan timeSpan, When when = When.Always,
        CommandFlags flags = CommandFlags.None)
    {
        if (obj == null)
        {
            return Task.FromResult(true);
        }

        var value = System.Text.Json.JsonSerializer.Serialize(obj);
        return GetDatabase().StringSetAsync(key, value, timeSpan, when, flags);
    }

    public Task<bool> RemoveAsync(string key, CommandFlags flags = CommandFlags.None)
    {
        return GetDatabase().KeyDeleteAsync(key, flags);
    }

    #region Hash

    public Task<bool> HashExistsAsync(string key, string field, CommandFlags flags = CommandFlags.None)
    {
        return GetDatabase().HashExistsAsync(key, field, flags);
    }

    public Task HSetAsync(string key, HashEntry[] fields, CommandFlags flags = CommandFlags.None)
    {
        return GetDatabase().HashSetAsync(key, fields, flags);
    }

    public Task<bool> HSetAsync<T>(string key, string field, T obj, When when = When.Always,
        CommandFlags flags = CommandFlags.None)
    {
        var value = System.Text.Json.JsonSerializer.Serialize(obj);
        return GetDatabase().HashSetAsync(key, field, value, when, flags);
    }

    public async Task<T> HGetAsync<T>(string key, string field, CommandFlags flags = CommandFlags.None)
    {
        var cacheValue = await GetDatabase().HashGetAsync(key, field, flags);
        if (!cacheValue.HasValue)
        {
            return default;
        }

        bool b = JsonUtil.TryToObject<T>(cacheValue.ToString(), out T value, out Exception e);
        if (!b)
        {
            return default;
        }

        return value;
    }

    public async Task<List<T>> HGetAsync<T>(string key, List<string> fields, CommandFlags flags = CommandFlags.None)
    {
        var hashFields = fields.Select(o => RedisValue.Unbox(o)).ToArray();
        var cacheValue = await GetDatabase().HashGetAsync(key, hashFields, flags);
        if (cacheValue == null || cacheValue.Length == 0)
        {
            return default;
        }

        var ret = cacheValue.Select(o =>
        {
            if (o.HasValue && JsonUtil.TryToObject(o.ToString(), out T obj, out Exception ex))
            {
                return obj;
            }
            else
            {
                return default;
            }
        }).ToList();

        return ret;
    }

    public async Task<T> HGetAsync<T>(string key, string field, Func<T> func, When when = When.Always,
        CommandFlags flags = CommandFlags.None)
    {
        var obj = await HGetAsync<T>(key, field, flags);
        if (obj == null || obj.Equals(default(T)))
        {
            obj = func();
            await HSetAsync(key, field, obj, when, flags);
        }

        return obj;
    }

    public async Task<T> HGetAsync<T>(string key, string field, Func<Task<T>> func, When when = When.Always,
        CommandFlags flags = CommandFlags.None)
    {
        var obj = await HGetAsync<T>(key, field, flags);
        if (obj == null || obj.Equals(default(T)))
        {
            obj = await func();
            await HSetAsync(key, field, obj, when, flags);
        }

        return obj;
    }

    public Task<bool> HRemoveAsync(string key, string field, CommandFlags flags = CommandFlags.None)
    {
        return GetDatabase().HashDeleteAsync(key, field, flags);
    }

    public async Task<bool> HRemoveAsync(string key, string[] fields, CommandFlags flags = CommandFlags.None)
    {
        if (fields == null || fields.Length == 0)
        {
            return true;
        }

        RedisValue[] redisValues = fields.Select(o => (RedisValue)o).ToArray();
        var l = await GetDatabase().HashDeleteAsync(key, redisValues, flags);

        return l > 0;
    }

    public async Task<HashEntry[]> HGetAllAsync<T>(string key, CommandFlags flags = CommandFlags.None)
    {
        var cachevalues = await GetDatabase().HashGetAllAsync(key, flags);
        return cachevalues;
    }

    #endregion

    #region List

    /// <summary>
    /// 获取队列
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="start"></param>
    /// <param name="stop"></param>
    /// <param name="flags"></param>
    /// <returns></returns>
    public async Task<List<T>> GetListRandgeAsync<T>(string key, long start = 0, long stop = -1,
        CommandFlags flags = CommandFlags.None)
    {
        List<T> list = new List<T>();

        var _ = await GetDatabase().ListRangeAsync(key, start, stop, flags);

        if (_ == null || _.Length == 0)
        {
            return list;
        }

        list = _.Select(o =>
        {
            if (!o.HasValue)
            {
                return default;
            }

            try
            {
                var obj = System.Text.Json.JsonSerializer.Deserialize<T>(o);
                return obj;
            }
            catch
            {
                return default;
            }
        }).ToList();

        return list;
    }

    /// <summary>
    /// 入队
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="flags"></param>
    /// <returns></returns>
    public async Task<bool> ListPushAsync<T>(string key, T value, CommandFlags flags = CommandFlags.None)
    {
        string _ = System.Text.Json.JsonSerializer.Serialize(value);
        var l = await GetDatabase().ListLeftPushAsync(key, _, When.Always, flags);

        return l != 0;
    }

    /// <summary>
    /// 出队
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="flags"></param>
    /// <returns></returns>
    public async Task<T> ListPopAsync<T>(string key, CommandFlags flags = CommandFlags.None)
    {
        var _ = await GetDatabase().ListRightPopAsync(key, flags);

        if (!_.HasValue)
        {
            return default;
        }

        var obj = System.Text.Json.JsonSerializer.Deserialize<T>(_);

        return obj;
    }

    /// <summary>
    /// 移除出队列
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="flags"></param>
    /// <returns></returns>
    public Task ListRemoveAsync<T>(string key, T value, CommandFlags flags = CommandFlags.None)
    {
        string _ = System.Text.Json.JsonSerializer.Serialize(value);

        return GetDatabase().ListRemoveAsync(key, _, 0, flags);
    }

    #endregion

    #region Lock

    public async Task<IRedLock> LockAsync(string resource, TimeSpan expiryTime)
    {
        try
        {
            var _lock = await GetRedLockFactory().CreateLockAsync(resource, expiryTime);
            return _lock;
        }
        catch (Exception e)
        {
            Log.Error($"{nameof(LockAsync)} redis 连接失败，{e.Message}", e);
            return null;
        }
    }

    public async Task<IRedLock> LockAsync(string resource, TimeSpan expiryTime, TimeSpan waitTime, TimeSpan retryTime,
        CancellationToken? cancellationToken = null)
    {
        try
        {
            var _lock = await GetRedLockFactory()
                .CreateLockAsync(resource, expiryTime, waitTime, retryTime, cancellationToken);
            ;
            return _lock;
        }
        catch (Exception e)
        {
            Log.Error($"{nameof(LockAsync)} redis 连接失败，{e.Message}", e);
            return null;
        }
    }

    private RedLockFactory GetRedLockFactory()
    {
        if (redLockFactory == null)
        {
            var existingConnectionMultiplexer = GetConnect();
            var multiplexers = new List<RedLockMultiplexer>
            {
                existingConnectionMultiplexer
            };
            redLockFactory = RedLockFactory.Create(multiplexers);
        }

        return redLockFactory;
    }

    #endregion

    #region Increment 计数器

    /// <summary>
    /// 设置计数器
    /// </summary>
    /// <param name="key">键</param>
    /// <param name="expiry">过期时间</param>
    /// <param name="initialValue">初始值，默认为0</param>
    /// <param name="keepTtl"></param>
    /// <param name="when"></param>
    /// <param name="flags"></param>
    /// <returns></returns>
    public bool SetIncrement(string key, TimeSpan? expiry, long initialValue = 0, bool keepTtl = false, When when = When.Always, CommandFlags flags = CommandFlags.None)
    {
        return GetDatabase().StringSet(key, initialValue, expiry, keepTtl, when, flags);
    }

    /// <summary>
    /// 计数器增加
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="flags"></param>
    /// <returns></returns>
    public Task<long> Increment(string key, long value, CommandFlags flags = CommandFlags.None)
    {
        return GetDatabase().StringIncrementAsync(key, value, flags);
    }

    /// <summary>
    /// 移除计数器
    /// </summary>
    /// <param name="key"></param>
    /// <param name="flags"></param>
    /// <returns></returns>
    public async Task<long> DeleteIncrement(string key, CommandFlags flags = CommandFlags.None)
    {
        var value = await  GetDatabase().StringGetDeleteAsync(key, flags);
        if (!value.HasValue)
        {
            return 0;
        }

        return value.ToLong();
    }

    #endregion

    public void Dispose()
    {
        if (_connections != null && _connections.Count > 0)
        {
            foreach (var item in _connections.Values)
            {
                item.Close();
            }
        }

        if (redLockFactory != null)
        {
            redLockFactory.Dispose();
        }
    }
}

public static class JsonUtil
{
    public static bool TryToObject<T>(string str, out T obj, out Exception e)
    {
        e = null;
        bool b = false;

        try
        {
            obj = System.Text.Json.JsonSerializer.Deserialize<T>(str);
            b = true;
        }
        catch (Exception ex)
        {
            b = false;
            e = ex;
            obj = default;
        }

        return b;
    }
}