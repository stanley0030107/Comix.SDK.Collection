namespace Comix.Core.Entity;

[SugarTable(null, "系统请求日志表")]
public class SysReqLog
{
    [SugarColumn(ColumnDescription = "主键", IsPrimaryKey = true)]
    public Guid Id { get; set; }

    [SugarColumn(ColumnDescription = "请求方向，1:外面系统请求本地系统，2本系统请求外部系统")]
    public int Direction { get; set; }

    [SugarColumn(ColumnDescription = "请求主机")]
    public string RequestHost { get; set; }

    [SugarColumn(ColumnDescription = "请求端口")]
    public int RequestPort { get; set; }

    [SugarColumn(ColumnDescription = "请求地址")]
    public string RequestUrl { get; set; }

    [SugarColumn(ColumnDescription = "请求参数")]
    public string ReqParams { get; set; }

    [SugarColumn(ColumnDescription = "请求时间")]
    public DateTime RequestTime { get; set; }

    [SugarColumn(ColumnDescription = "请求类名")]
    public string ClassName { get; set; }

    [SugarColumn(ColumnDescription = "请求方法")]
    public string Method { get; set; }

    [SugarColumn(ColumnDescription = "请求用户")]
    public string UserId { get; set; }

    [SugarColumn(ColumnDescription = "响应编码")]
    public int ResponseCode { get; set; }

    [SugarColumn(ColumnDescription = "响应时间")]
    public DateTime ResponseTime { get; set; }

    [SugarColumn(ColumnDescription = "响应参数")]
    public string RespParams { get; set; }
}