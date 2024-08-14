using Comix.Core.Option;
using RedLockNet.SERedis;
using RedLockNet.SERedis.Configuration;
using StackExchange.Redis;

namespace Comix.Core.Cache;

public static class RedLockSetup
{
    public static IServiceCollection AddRedLock(this IServiceCollection services)
    {
        services.AddSingleton(options =>
        {
            var cacheOptions = App.GetOptions<CacheOptions>();
            var existingConnectionMultiplexer1 = ConnectionMultiplexer.Connect(cacheOptions.RedisConnectionString);
            var multiplexers = new List<RedLockMultiplexer>
            {
                existingConnectionMultiplexer1,
            };
            var redlockFactory = RedLockFactory.Create(multiplexers);
            return redlockFactory;
        });

        return services;
    }
}