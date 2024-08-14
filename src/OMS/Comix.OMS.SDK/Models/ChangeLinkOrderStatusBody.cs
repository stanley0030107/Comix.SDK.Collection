namespace Comix.OMS.SDK.Models;

public class ChangeLinkOrderStatusBody
{
    /// <summary>
    /// 应用ID
    /// </summary>
    public int AppID { get; set; }

    /// <summary>
    /// 来源单号
    /// </summary>
    public string SourceBillNo { get; set; } = "";

    /// <summary>
    /// 状态码
    /// </summary>
    public string StatusCode { get; set; } = "";

    /// <summary>
    /// 单号
    /// </summary>
    public string BillNo { get; set; } = "";

    /// <summary>
    /// 用户名
    /// </summary>
    public string UserName { get; set; } = "";

    /// <summary>
    /// 预计交付天数
    /// </summary>
    public int EstDeliveryDays { get; set; }

    /// <summary>
    /// 签署状态
    /// </summary>
    public string SignedStatus { get; set; }
}