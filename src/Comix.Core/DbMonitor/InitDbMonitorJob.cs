using Comix.Core.Helpers;
using Comix.Core.Schedule;
using Microsoft.Extensions.Logging;

namespace Comix.Core.DbMonitor;

public abstract class InitDbMonitorJob : ComixJob
{
    private readonly MonitorType _monitorType;
    protected readonly IInitMonitorLogAppService _initMonitorLogAppService;

    public InitDbMonitorJob(ILogger<InitDbMonitorJob> logger, RedisHelper redisHelper,
        MonitorType monitorType) : base(logger, redisHelper)
    {
        _monitorType = monitorType;
        _initMonitorLogAppService = App.GetService<IInitMonitorLogAppService>();
    }

    /// <summary>
    /// 获取指定时间内的消息总数
    /// </summary>
    /// <param name="startTime"></param>
    /// <param name="endTime"></param>
    /// <param name="syncStatus">同步结果</param>
    /// <returns></returns>
    protected abstract Task<int> GetTotal(DateTime startTime, DateTime endTime, bool? syncStatus = null);
    
    protected override async Task<bool> DoExecuteAsync(JobExecutingContext context, CancellationToken stoppingToken)
    {
        DateTime lastEndTime;
        do
        {
            try
            {
                var monitorLog = await _initMonitorLogAppService.InitMonitorLog(_monitorType,
                    (startTime, endTime) => GetTotal(startTime, endTime), 15,-2);
                if (monitorLog == null)
                {
                    return true;
                }

                await ExcuteLog(monitorLog);

                lastEndTime = monitorLog.EndTime;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"初始化监控数据异常");
                throw;
            }
        } while (lastEndTime < DateTime.Now.AddHours(-1));

        return true;
    }
    
    private async Task ExcuteLog(InitMonitorLog monitorLog)
    {
        try
        {
            while (monitorLog.CurrentPage < monitorLog.TotalPage)
            {
                await Excute(monitorLog.StartTime, monitorLog.EndTime, monitorLog.CurrentPage,
                    monitorLog.First);
                monitorLog.CurrentPage++;
                await _initMonitorLogAppService.AddCurrentPage(monitorLog.Id);
                _logger.LogDebug("{Key} {S} 初始化监控数据，{MonitorLogId}，{MonitorLogCurrentPage}",
                    _key, monitorLog.Type.ToString(), monitorLog.Id, monitorLog.CurrentPage);
            }

            await _initMonitorLogAppService.SetStatus(monitorLog.Id, MonitorStatus.Complete, null);
            _logger.LogDebug("{Key} {S} 完成初始化监控数据，{MonitorLogId}",
                _key, monitorLog.Type.ToString(), monitorLog.Id);
        }
        catch (Exception e)
        {
            await _initMonitorLogAppService.SetStatus(monitorLog.Id, MonitorStatus.Fail, e.Message);
            _logger.LogError(e, "{Key} {S} 初始化监控数据失败，{MonitorLogId}",
                _key, monitorLog.Type.ToString(), monitorLog.Id);
        }
    }

    /// <summary>
    /// 执行
    /// </summary>
    /// <param name="startTime"></param>
    /// <param name="endTime"></param>
    /// <param name="currentPage"></param>
    /// <param name="first"></param>
    /// <returns></returns>
    protected abstract Task Excute(DateTime startTime, DateTime endTime, int currentPage,
        bool first);
}