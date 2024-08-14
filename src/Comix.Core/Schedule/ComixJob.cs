using Grpc.Core.Logging;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comix.Core.Helpers;
using RedLockNet.SERedis;

namespace Comix.Core.Schedule
{
    public abstract class ComixJob : IJob
    {
        protected StringBuilder _result;
        protected readonly ILogger<ComixJob> _logger;
        protected readonly RedisHelper _redisHelper;
        protected Guid _key;

        protected ComixJob(ILogger<ComixJob> logger, RedisHelper redisHelper)
        {
            _logger = logger;
            _redisHelper = redisHelper;
        }

        protected abstract Task<bool> DoExecuteAsync(JobExecutingContext context, CancellationToken stoppingToken);

        public async Task ExecuteAsync(JobExecutingContext context, CancellationToken stoppingToken)
        {
            _result = new StringBuilder();
            _key = Guid.NewGuid();

            Log($"开始{this.GetType().Name}, ", addResult: true);

            var key = $"Comix:Job:{this.GetType().Name}";
            await using var redLock = await _redisHelper.LockAsync(key, TimeSpan.FromHours(1));
            if (!redLock.IsAcquired)
            {
                Log($"执行结束，分布式锁没有释放，本次不执行", addResult: true);
                context.Result = _result.ToString();
                return;
            }
            
            try
            {
                var success = await DoExecuteAsync(context, stoppingToken);
                Log($"执行{(success ? "成功" : "失败")}", addResult: true);
                context.Result = _result.ToString();
            }
            catch (Exception ex)
            {
                Log($"执行异常", ex, addResult: true);
                context.Result = _result.ToString();
            }
        }

        /// <summary>
        /// 添加日志
        /// 调用此方法记录的日志会添加到jod的执行结果中
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="logLevel"></param>
        /// <param name="addResult"></param>
        protected void Log(string msg, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information, bool addResult = false)
        {
            msg = $"执行编码{_key} {msg}";
            _logger.Log(logLevel, msg);
            if (addResult)
            {
                _result.AppendLine(msg);
            }
        }

        /// <summary>
        /// 添加日志
        /// 调用此方法记录的日志会添加到jod的执行结果中
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        /// <param name="logLevel"></param>
        /// <param name="addResult"></param>
        public void Log(string msg, Exception ex, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Error, bool addResult = false)
        {
            msg = $"执行编码{_key} {msg} 异常信息：{ex.Message}";
            _logger.Log(logLevel, ex, msg);
            if (addResult)
            {
                _result.AppendLine(msg);
            }
        }
    }
}
