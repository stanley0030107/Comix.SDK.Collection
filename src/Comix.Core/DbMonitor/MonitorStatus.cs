namespace Comix.Core.DbMonitor;

public enum MonitorStatus
{
    /// <summary>
    /// 执行中
    /// </summary>
    Todo = 0,
    /// <summary>
    /// 完成
    /// </summary>
    Complete = 1,
    /// <summary>
    /// 失败
    /// </summary>
    Fail = 2
}