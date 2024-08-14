using Comix.Core.Enum;
using Comix.Core.Option;
using RedLockNet.SERedis;
using RedLockNet.SERedis.Configuration;
using StackExchange.Redis;

namespace Comix.Core.Cache;

public static class CacheSetup
{
    /// <summary>
    /// 缓存注册（新生命Redis组件）
    /// </summary>
    /// <param name="services"></param>
    public static IServiceCollection AddCache(this IServiceCollection services)
    {
        services.AddSingleton(options =>
        {
            var cacheOptions = App.GetOptions<CacheOptions>();
            var helper = new Helpers.RedisHelper(cacheOptions.RedisConnectionString, cacheOptions.CacheType,
                cacheOptions.DefaultDB);

            return helper;
        });

        return services;
    }
}