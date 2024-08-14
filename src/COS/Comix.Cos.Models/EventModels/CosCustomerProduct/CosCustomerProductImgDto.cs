namespace Comix.Cos.Models.EventModels.CosCustomerProduct;

public class CosCustomerProductImgDto
{
    /// <summary>
    /// 客户编码
    /// </summary>
    public string customerCode { get; set; }

    /// <summary>
    /// sku
    /// </summary>
    public string customerProductCode { get; set; }

    /// <summary>
    /// B2B商品编码(官网编码) 
    /// </summary>
    public string b2bProductNumber { get; set; }

    /// <summary>
    /// 专有图片800
    /// </summary>
    public string customer_img800 { get; set; }

    /// <summary>
    /// 专有图片750
    /// </summary>
    public string customer_img750 { get; set; }

    /// <summary>
    /// 是否专有图片
    /// </summary>

    public string customer_img_flag { get; set; }

    /// <summary>
    /// 消息Id
    /// </summary>
    public string messageId { get; set; }
}