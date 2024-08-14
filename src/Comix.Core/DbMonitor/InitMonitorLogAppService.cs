using Furion.DistributedIDGenerator;
using Microsoft.Extensions.Logging;

namespace Comix.Core.DbMonitor;

public class InitMonitorLogAppService : IInitMonitorLogAppService
{
    private readonly ILogger<InitMonitorLogAppService> _logger;
    private readonly ISqlSugarClient _db;
    private readonly IDistributedIDGenerator _idGenerator;

    public InitMonitorLogAppService(ILogger<InitMonitorLogAppService> logger,
        ISqlSugarClient db,
        IDistributedIDGenerator idGenerator)
    {
        _logger = logger;
        _db = db;
        _idGenerator = idGenerator;
    }

    /// <summary>
    /// 初始化监控日志
    /// 如果 监控日志表为空，则同步最近一年的数据
    /// 如果 监控日志表不为空 + 存在未同步完成的日志，则取出未完成的进行同步
    /// 如果 监控日志表不为空 + 全部同步完成 + 最后同步时间没超过1个小时，则新建同步日志
    /// 否则返回空
    /// </summary>
    /// <param name="type">log名称</param>
    /// <param name="getTotal">创建新纪录时，通过委托获取总数</param>
    /// <param name="lastDay">每次兜底执行多少天的数据，单位天</param>
    /// <param name="initYear">第一次执行从多少年前开始处理数据，单位年</param>
    /// <param name="finishMinutes">执行结束时间，单位分钟</param>
    /// <returns></returns>
    public async Task<InitMonitorLog?> InitMonitorLog(MonitorType type, Func<DateTime, DateTime, Task<int>> getTotal,
        int lastDay = 12 * 30, int initYear = -4, int finishMinutes = -10)
    {
        var nullTable = await _db.Queryable<InitMonitorLog>().Where(o => o.Type == type).FirstAsync();
        if (nullTable == null)
        {
            var startTime = DateTime.Now.AddYears(initYear);
            var endTime = startTime.AddMonths(1);
            var newLog = await CreateNewMonitorLog(type, startTime, endTime, getTotal, true);
            return newLog;
        }

        var now = DateTime.Now;

        var lastEndTime = await _db.Queryable<InitMonitorLog>()
            .Where(o => o.Type == type)
            .MaxAsync(o => o.EndTime);
        var finishTime = now.AddMinutes(finishMinutes);
        if (lastEndTime < finishTime)
        {
            var newStartTime = lastEndTime;//开始时间是最后一次的结束时间
            var newEndTime = newStartTime.AddMonths(1);//结束时间是开始时间往后一个月
            newEndTime = newEndTime > finishTime ? finishTime : newEndTime;//如果结束时间大于当前时间，结束时间取当前时间
            newStartTime = newEndTime == finishTime ? newEndTime.AddDays(-lastDay) : newStartTime;//如果结束时间是当前时间，开始时间是结束时间往前12个月
            if (lastEndTime.Date != newEndTime.Date)
            {
                var log = await CreateNewMonitorLog(type, newStartTime, newEndTime, getTotal, true);
                return log;
            }
        }

        //最近数据已经执行到当前时间10十分钟前

        //开始修复之前执行失败的任务
        var notCompleteLog = await _db.Queryable<InitMonitorLog>()
            .Where(o => o.Type == type)
            .Where(o => o.Status != MonitorStatus.Complete)
            .OrderBy(o => o.LastTime)
            .FirstAsync();
        if (notCompleteLog != null && notCompleteLog.LastTime < now.AddMinutes(-1))
        {
            //存在执行失败的记录，且1分钟前没有执行过
            //取出数据开始执行
            return notCompleteLog;
        }

        //返回空不执行，本次任务结束
        return null;
    }
    
    /// <summary>
    /// 根据开始结束时间创建数据监控日志
    /// </summary>
    /// <param name="type"></param>
    /// <param name="startTime"></param>
    /// <param name="endTime"></param>
    /// <param name="getTotal">委托，获取订单总数</param>
    /// <param name="first">是否首次执行</param>
    /// <returns></returns>
    private async Task<InitMonitorLog> CreateNewMonitorLog(MonitorType type, DateTime startTime, DateTime endTime,
        Func<DateTime, DateTime,
            Task<int>> getTotal, bool first = false)
    {
        var pageSize = App.GetConfig<int>("InitDataPageSize");
        var total = await getTotal(startTime, endTime);
        double result = (double)total / pageSize;
        int totalPage = (int)Math.Ceiling(result);

        var newData = new InitMonitorLog
        {
            Id = (Guid)_idGenerator.Create(),
            StartTime = startTime,
            EndTime = endTime,
            Status = 0,
            Total = total,
            TotalPage = totalPage,
            CurrentPage = 0,
            LastTime = DateTime.Now,
            Type = type,
            First = first
        };

        await _db.Insertable(newData).ExecuteCommandAsync();
        return newData;
    }

    /// <summary>
    /// 当前页数增加
    /// </summary>
    /// <param name="logId"></param>
    /// <param name="currentPage"></param>
    public async Task AddCurrentPage(Guid logId, int? currentPage = null)
    {
        await _db.Updateable<InitMonitorLog>()
            .SetColumnsIF(currentPage.HasValue, o => o.CurrentPage == currentPage)
            .SetColumnsIF(!currentPage.HasValue, o => o.CurrentPage == o.CurrentPage + 1)
            .SetColumns(o => o.LastTime == DateTime.Now)
            .Where(o => o.Id == logId)
            .ExecuteCommandAsync();
    }

    /// <summary>
    /// 设置状态
    /// </summary>
    /// <param name="logId"></param>
    /// <param name="status">
    /// 状态
    /// 0：同步中
    /// 1：同步完成
    /// 2：同步异常
    /// </param>
    /// <param name="remark"></param>
    public async Task SetStatus(Guid logId, MonitorStatus status, string? remark)
    {
        await _db.Updateable<InitMonitorLog>()
            .SetColumns(o => o.Status == status)
            .SetColumns(o => o.Remark == remark)
            .SetColumns(o => o.LastTime == DateTime.Now)
            .Where(o => o.Id == logId)
            .ExecuteCommandAsync();
    }
}