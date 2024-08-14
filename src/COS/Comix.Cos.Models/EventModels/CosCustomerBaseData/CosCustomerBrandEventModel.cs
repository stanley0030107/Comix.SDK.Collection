namespace Comix.Cos.Models.EventModels.CosCustomerBaseData;

public class CosCustomerBrandEventModel
{
    public string BRAND_CODE { get; set; }
    public string BRAND_NAME { get; set; }
    public string CUSTOMER_CODE { get; set; }
    public int DISPLAY_SEQUENCE { get; set; }
    public int HOMEPAGE_SHOW_SEQUENCE { get; set; }
    public bool IS_HOMEPAGE_SHOW { get; set; }
    public int STATUS { get; set; }
    public string MESSAGE_ID { get; set; }
}