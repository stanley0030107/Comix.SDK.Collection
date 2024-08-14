using Comix.Core.Entity;
using Comix.Core.Sqlsugar;
using Furion.Schedule;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Threading;

namespace Comix.Core.LogFilter
{
    /// <summary>
    /// 系统日志任务
    /// 
    /// 批量记录日志定时任务
    /// </summary>
    public class SysLogJob : IHostedService
    {
        /// <summary>
        /// 日志队列
        /// </summary>
        public static ConcurrentQueue<SysReqLog> LogQueue = new ConcurrentQueue<SysReqLog>();
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<SysLogJob> _logger;

        private Timer _timer;
        private bool _polling;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="logRepo"></param>
        /// <param name="logger"></param>
        public SysLogJob(
            IServiceProvider serviceProvider,
            ILogger<SysLogJob> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        /// <summary>
        /// 程序启动
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(async x =>
            {
                if (_polling)
                {
                    return;
                }
                try
                {
                    _polling = true;

                    var logs = new List<SysReqLog>();

                    //循环取日志记录，直到队列为空，或者要写入的日志超过1000条
                    while (logs.Count <= 1000 && LogQueue.TryDequeue(out var log))
                    {
                        logs.Add(log);
                    }

                    //如果存在要写入的日志，插入数据库
                    if (logs.Count > 0)
                    {
                        await DoWork(logs);
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError(e, $"持久化请求日志异常");
                }
                finally
                {
                    _polling = false;
                }

            }, null, TimeSpan.FromSeconds(20), TimeSpan.FromSeconds(20));

            return Task.CompletedTask;
        }

        /// <summary>
        /// 程序停止
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("持久化请求日志退出");
            //程序停止时存在还没保存的日志，马上保存
            if (LogQueue.Count > 0)
            {
                await DoWork(LogQueue.ToList());
            }
        }

        /// <summary>
        /// 保存日志到数据库
        /// </summary>
        /// <param name="logs"></param>
        /// <returns></returns>
        private async Task DoWork(List<SysReqLog> logs)
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var _logRepo = scope.ServiceProvider.GetService<SqlSugarRepository<SysReqLog>>();
                    await _logRepo.InsertRangeAsync(logs);
                }       
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "持久化请求日志异常");
            }
        }
    }
}
