namespace Comix.OMS.SDK.Models.RPC;

/// <summary>
/// O2O查询OMS订单提供给工单系统
/// </summary>
public class OrderInfoForWOS
{
    /// <summary>
    /// 结算员
    /// </summary>
    //[Display(Name = "结算员")]
    public virtual string SettlerNo { get; set; }

    /// <summary>
    /// 订单员
    /// </summary>
    //[Display(Name = "订单员")]
    public virtual string OrderProcessor { get; set; }

    /// <summary>
    /// 默认员工编号
    /// </summary>
    //[Display(Name = "默认员工编号")]
    public virtual string DefaultUserNo { get; set; }

    /// <summary>
    /// 合同项目
    /// </summary>
    //[Display(Name = "合同项目")]
    public virtual string ContractSysId { get; set; }

    /// <summary>
    /// 合同项目名称
    /// </summary>
    //[Display(Name = "合同项目名称")]
    public virtual string ContractSysName { get; set; }
}