namespace Comix.OMS.SDK.Models.RPC;

public class SeOrderLink
{
    /// <summary>
    /// ������ʽ
    /// </summary>
    public string VoucherType { get; set; }

    /// <summary>
    /// OMS������
    /// </summary>
    public string BillNo { get; set; }

    /// <summary>
    /// ������˰�ܽ��
    /// </summary>
    public decimal TotalTaxAmount { get; set; }

    /// <summary>
    /// sap�������
    /// </summary>
    public string SAPBillNo { get; set; }

    /// <summary>
    /// ��Ӫģʽ
    /// </summary>
    public string BussinessModel { get; set; }

    /// <summary>
    /// ����Ա
    /// </summary>
    public string OrderProcessorName { get; set; }

    /// <summary>
    /// ��Ʊ״̬
    /// </summary>
    public string InvoiceStatus { get; set; }

    /// <summary>
    /// �ɹ�������
    /// </summary>
    public string SapPoBillNo { get; set; }

    /// <summary>
    /// �ɹ���˰���
    /// </summary>
    public decimal? PoOrderTaxAmount { get; set; }

    /// <summary>
    /// �����̺�������
    /// </summary>
    public decimal? PurchasePoint { get; set; }

    /// <summary>
    /// LINK����
    /// </summary>
    public string SourceBillNo { get; set; }

    /// <summary>
    /// ������
    /// </summary>
    public List<SeDoO2O> DeliveryOrders { get; set; }
}