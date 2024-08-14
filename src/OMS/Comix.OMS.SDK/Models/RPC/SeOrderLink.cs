namespace Comix.OMS.SDK.Models.RPC;

public class SeOrderLink
{
    /// <summary>
    /// 交付方式
    /// </summary>
    public string VoucherType { get; set; }

    /// <summary>
    /// OMS订单号
    /// </summary>
    public string BillNo { get; set; }

    /// <summary>
    /// 订单含税总金额
    /// </summary>
    public decimal TotalTaxAmount { get; set; }

    /// <summary>
    /// sap订单编号
    /// </summary>
    public string SAPBillNo { get; set; }

    /// <summary>
    /// 经营模式
    /// </summary>
    public string BussinessModel { get; set; }

    /// <summary>
    /// 订单员
    /// </summary>
    public string OrderProcessorName { get; set; }

    /// <summary>
    /// 发票状态
    /// </summary>
    public string InvoiceStatus { get; set; }

    /// <summary>
    /// 采购订单号
    /// </summary>
    public string SapPoBillNo { get; set; }

    /// <summary>
    /// 采购含税金额
    /// </summary>
    public decimal? PoOrderTaxAmount { get; set; }

    /// <summary>
    /// 服务商合作点数
    /// </summary>
    public decimal? PurchasePoint { get; set; }

    /// <summary>
    /// LINK单号
    /// </summary>
    public string SourceBillNo { get; set; }

    /// <summary>
    /// 交货单
    /// </summary>
    public List<SeDoO2O> DeliveryOrders { get; set; }
}