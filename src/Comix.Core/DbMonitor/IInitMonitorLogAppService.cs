namespace Comix.Core.DbMonitor;

public interface IInitMonitorLogAppService:IScoped
{
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
    Task<InitMonitorLog?> InitMonitorLog(MonitorType type, Func<DateTime, DateTime, Task<int>> getTotal,
        int lastDay = 12 * 30, int initYear = -4, int finishMinutes = -10);

    /// <summary>
    /// 当前页数增加
    /// </summary>
    /// <param name="logId"></param>
    /// <param name="currentPage"></param>
    Task AddCurrentPage(Guid logId, int? currentPage = null);

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
    Task SetStatus(Guid logId, MonitorStatus status, string? remark);
}