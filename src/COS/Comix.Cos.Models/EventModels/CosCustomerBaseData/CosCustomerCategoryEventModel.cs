namespace Comix.Cos.Models.EventModels.CosCustomerBaseData;

public class CosCustomerCategoryEventModel
{
    public string CATEGORY_CODE { get; set; }
    public string CATEGORY_NAME { get; set; }
    public string CUSTOMER_CODE { get; set; }
    public int DEPTH { get; set; }
    public int DISPLAY_SEQUENCE { get; set; }
    public string PARENT_CATEGORY_CODE { get; set; }
    public decimal PRICE_DISCOUNT_RATE { get; set; }
    public bool STATUS { get; set; }
    public string MESSAGE_ID { get; set; }
}