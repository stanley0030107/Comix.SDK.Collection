namespace Comix.Core.DbMonitor;

[SugarTable("InitMonitorLog")]
public class InitMonitorLog
{
    [SugarColumn(IsPrimaryKey = true)]
    public Guid Id { get; set; }

    [SugarColumn(Length = 128, IsNullable = false, ColumnName = "Type")]
    public MonitorType Type { get; set; }

    /// <summary>
    /// 总数
    /// </summary>
    [SugarColumn(IsNullable = false, ColumnName = "Total")]
    public int Total { get; set; }

    /// <summary>
    /// 总页数
    /// </summary>
    [SugarColumn(IsNullable = false, ColumnName = "TotalPage")]
    public int TotalPage { get; set; }

    /// <summary>
    /// 当前页数
    /// </summary>
    [SugarColumn(IsNullable = false, ColumnName = "CurrentPage")]
    public int CurrentPage { get; set; } = 0;

    /// <summary>
    /// 开始时间
    /// </summary>
    [SugarColumn(IsNullable = false, ColumnName = "StartTime")]
    public DateTime StartTime { get; set; }

    /// <summary>
    /// 结束时间
    /// </summary>
    [SugarColumn(IsNullable = false, ColumnName = "EndTime")]
    public DateTime EndTime { get; set; }

    /// <summary>
    /// 最后更新时间
    /// </summary>
    [SugarColumn(IsNullable = false, ColumnName = "LastTime")]
    public DateTime LastTime { get; set; } = DateTime.Now;

    /// <summary>
    /// 状态
    /// 0：同步中
    /// 1：同步完成
    /// 2：同步异常
    /// </summary>
    [SugarColumn(IsNullable = false, ColumnName = "Status")]
    public MonitorStatus Status { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [SugarColumn(IsNullable = true, ColumnName = "Remark")]
    public string? Remark { get; set; }

    /// <summary>
    /// 是否首次执行
    /// 首次执行按照创建时间排序
    /// 否则按照修改时间排序
    /// </summary>
    [SugarColumn(IsNullable = false, ColumnName = "First")]
    public bool First { get; set; }
}