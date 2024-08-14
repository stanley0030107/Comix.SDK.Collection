namespace Comix.Core.Entity;

/// <summary>
/// 单据流水号类型
/// </summary>
public enum CodeType
{
    [Description("TrackingLog")] TrackingLog = 1,

    [Description("ServiceLog")] ServiceLog = 2,

    [Description("SrcFinPayment")] SrcFinPayment = 13,

    [Description("PaymentCode")] PaymentCode = 14,

    /// <summary>
    /// 统一支付平台
    /// </summary>
    [Description("PayCode")] PayCode = 15,

    [Description("MonitorLog")] MonitorLog = 18,

    [Description("新版付款流水号")] NewPayCode = 20,

    [Description("余单取消单号")] CancelRestOrderCode = 21,

    CopLogCode = 22,
    CopOrderCode = 23,
    CopRtnCode = 24,
    CopRtaCode = 25,

    [Description("重筹项目单号")] ProjectCode = 26,

    [Description("COP发货单号")] DeliveryCode = 27,

    JDLogCode = 28,
    KplLogCode = 29,
    PurchaseOrder = 30,
    InvoiceCode = 31,
    JGZCode = 32,

    [Description("合约商品编码")] SAPLINKProductCode = 33,

    [Description("虚拟物料编码")] DProductCode = 34,

    [Description("合约物料编码")] CustomerSkuCode = 35,
    [Description("平台编码")] PlatformCode = 37,
    [Description("平台物料编码")] PlatformSkuCode = 38,
    [Description("平台项目物料编码")] PlatformCustomerSkuCode = 39,
    [Description("O2O服务商发起的结算单号")] O2ODistributorBillNo = 41,
    [Description("O2O取消单号")] O2OCancelOrderCode = 42,
    [Description("CDP拆单编码")] ComposeCode = 60,
    [Description("电子签章")] ElectronicSeal = 65
}