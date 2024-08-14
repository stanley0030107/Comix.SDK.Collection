using Comix.Core.Entity;
using Comix.Core.Helpers;
using Comix.Core.Sqlsugar;
using Furion.DistributedIDGenerator;
using Microsoft.Extensions.Logging;

namespace Comix.Core.Util;

public class CodeGenerater : IScoped
{
    private readonly RedisHelper _cache;
    private readonly SqlSugarRepository<SysCodeRule> _codeRuleRepo;
    private readonly IDistributedIDGenerator _distributedID;
    private readonly ILogger<CodeGenerater> _logger;

    public CodeGenerater(RedisHelper cache,
        IDistributedIDGenerator distributedID,
        SqlSugarRepository<SysCodeRule> codeRuleRepo,
        ILogger<CodeGenerater> logger)
    {
        _cache = cache;
        _distributedID = distributedID;
        _codeRuleRepo = codeRuleRepo;
        _logger = logger;
    }

    /// <summary>
    ///     生成编码(带分布式锁)
    /// </summary>
    /// <param name="codeType"></param>
    /// <returns></returns>
    public async Task<string?> NewCodeAsync(CodeType codeType)
    {
        try
        {
            using (var _lock = await _cache.LockAsync($"GetCode:{codeType}", 
                       TimeSpan.FromSeconds(5), 
                       TimeSpan.FromSeconds(15), 
                       TimeSpan.FromMilliseconds(200)))
            {
                if (!_lock.IsAcquired)
                {
                    return _distributedID.Create().ToString();
                }
                var code = await NewCodeNoLockAsync(codeType);
                return code;
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, $"生成编码失败， codeType：{codeType}");
            return _distributedID.Create().ToString();
        }
    }

    /// <summary>
    ///     生成编码(不带分布式锁)
    /// </summary>
    /// <param name="codeType"></param>
    /// <returns></returns>
    private async Task<string?> NewCodeNoLockAsync(CodeType codeType)
    {
        var rule = await _codeRuleRepo.GetByIdAsync(codeType);
        if (rule == null) return _distributedID.Create().ToString();

        var newMidCode = rule.GetMidCode();
        var oldMidCode = rule.MidCode;
        if (oldMidCode == null || !oldMidCode.Equals(newMidCode)) rule.WaterNum = 0;

        rule.MidCode = newMidCode;
        rule.WaterNum++;
        await _codeRuleRepo.AsUpdateable()
            .SetColumns(o => o.MidCode == rule.MidCode)
            .SetColumns(o => o.WaterNum == rule.WaterNum)
            .Where(o => o.CodeType == codeType)
            .ExecuteCommandAsync();

        var strCode = $"{rule.PreCode}{newMidCode}{rule.WaterNum.ToString().PadLeft(rule.WaterNumLength.Value, '0')}";
        return strCode;
    }

    /// <summary>
    /// 计数器
    /// </summary>
    /// <param name="type">类型</param>
    /// <param name="padLeftNum">左边补全位数</param>
    /// <returns></returns>
    public async Task<string> GetCode(CodeType type, string prefix = "", int padLeftNum = 8)
    {
        prefix = $"{prefix}0{DateTime.Now.ToString("yyyyMMdd")}";

        var key = $"incr:{type}:{prefix}";
        long waterNum = 0;

        try
        {
            waterNum = await _cache.Increment(key, 1);
        }
        catch (Exception ex)
        {
            _logger.LogError($"生成编码失败 {type}", ex);
            var snow = new SnowflakeIdGenerator();
            waterNum = snow.NextId();
        }


        return prefix + waterNum.ToString().PadLeft(padLeftNum, '0');
    }

    /// <summary>
    /// 计数器
    /// </summary>
    /// <param name="type">类型</param>
    /// <param name="padLeftNum">左边补全位数</param>
    /// <returns></returns>
    public async Task<string> GetCode(string type, string prefix = "", int padLeftNum = 8)
    {
        var key = $"incr:{type}:{prefix}";
        long waterNum = 0;

        try
        {
            waterNum = await _cache.Increment(key, 1);
        }
        catch (Exception ex)
        {
            _logger.LogError($"生成编码失败 {type}", ex);
            var snow = new SnowflakeIdGenerator();
            waterNum = snow.NextId();
        }


        return prefix + waterNum.ToString().PadLeft(padLeftNum, '0');
    }
}