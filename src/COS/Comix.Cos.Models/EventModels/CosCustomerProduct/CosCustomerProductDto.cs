namespace Comix.Cos.Models.EventModels.CosCustomerProduct;

public class CosCustomerProductDto
{
    /// <summary>
    /// 1只推link
    /// </summary>
    public string isApi { get; set; }
    /// <summary>
    /// 1推送cdp和qop
    /// 0只推cdp
    /// </summary>
    public string apiType { get; set; }
    public bool IsSkuAttrs { get; set; }
    
    /// <summary>
    /// 属性值数据
    /// </summary>
    public List<SkuAttrs> SkuAttrsList { get; set; }
    
    public string b2bCategory3Name { get; set; }
    public string b2bCategory3Number { get; set; }
    public string b2bModel { get; set; }
    public string b2bProductNumber { get; set; }
    public string[] baseChange { get; set; }
    public string basicUnit { get; set; }
    public string chineseUnit { get; set; }
    public string comixBrand { get; set; }
    public string conProductFlag { get; set; }
    public string contractProductNumber { get; set; }
    public string contractTaxRate { get; set; }
    public string cusCategory3Name { get; set; }
    public string cusCategory3Number { get; set; }
    public decimal cusNakedPrice { get; set; }
    public decimal cusTaxPrice { get; set; }
    public string customLogoFlag { get; set; }
    public string customerCode { get; set; }
    public int customerProductId { get; set; }
    public string customerProductName { get; set; }
    public string discountRate { get; set; }
    public string extendAttribute1 { get; set; }
    public string extendAttribute2 { get; set; }
    public string extendAttribute3 { get; set; }
    public string extendAttribute4 { get; set; }
    public string extendAttribute5 { get; set; }
    public string extendAttribute6 { get; set; }
    public string extendAttribute7 { get; set; }
    public int historyCount { get; set; }
    public int historyId { get; set; }
    public int historyIndex { get; set; }
    public string messageId { get; set; }
    public string minChineseUnit { get; set; }
    public string minOrderQuantity { get; set; }
    public string minPurchasePrice { get; set; }
    public string orderQuickly { get; set; }
    public string proModel { get; set; }
    public string proName { get; set; }
    public string proSpecification { get; set; }
    public string productName { get; set; }
    public string purchaseFlag { get; set; }
    public int recordId { get; set; }
    public string retailPrice { get; set; }
    public string sau { get; set; }
    public string settlementPrice { get; set; }
    public string shelfFlag { get; set; }
    public string shelfStatus { get; set; }
    public string spuAttribute { get; set; }
    public decimal standardNakedPrice { get; set; }
    public string standardPrice { get; set; }
    public decimal standardTaxPrice { get; set; }
    public string standardTaxRate { get; set; }
    public string taxClass { get; set; }


    public string attribute2 { get; set; }
    public string attribute3 { get; set; }

    /// <summary>
    /// 规格参数
    /// </summary>
    public string specification { get; set; }

    public string unsalableExpired { get; set; }
    public string thirdClass { get; set; }
    public string enaQuaTypeFlag { get; set; }
    public string newContractNum { get; set; }
    public string contractBrand { get; set; }
    public string customerProductShortName { get; set; }
    
    public string jdUrl { get; set; }
    public string sellingPoint { get; set; }
    public string platformUrl { get; set; }
    public string store { get; set; }
    public string cusProductDes { get; set; }
    public string packingList { get; set; }
    public string extendAttribute8 { get; set; }
    public string extendAttribute9 { get; set; }
    public string extendAttribute10 { get; set; }
    public string envFlag { get; set; }
    public string envModel { get; set; }
    public string environmentalListPages { get; set; }
    public string esModel { get; set; }
    public string esListPages { get; set; }
    public string customerProductEnglishName { get; set; }
    public string esValidUntil { get; set; }
    public string envValidUntil { get; set; }
    public string esBrand { get; set; }
    public string envBrand { get; set; }
    public string esCertificate { get; set; }
    public string envCertificate { get; set; }
    public string esPictureUrl { get; set; }
    public string envPictureUrl { get; set; }
    public string esCerBody { get; set; }
    public string envCerBody { get; set; }
    public string eanUpc { get; set; }
    public string proColor { get; set; }
    public string nationalStandard { get; set; }
    public string suiModel { get; set; }
    public string quaType { get; set; }
    public string lockPriceFlag { get; set; }
    public string ancProductFlag { get; set; }
    public string pictureFlag { get; set; }

}


public class SkuAttrs
{
    /// <summary>
    /// 客编
    /// </summary>
    public string CustomerCode { get; set; }

    /// <summary>
    /// 合约编码
    /// </summary>
    public string CustomerSkuCode { get; set; }

    /// <summary>
    /// 属性id
    /// </summary>
    public string CategoryAttrId { get; set; }

    /// <summary>
    /// 属性名称
    /// </summary>
    public string AttrName { get; set; }

    /// <summary>
    /// 属性值
    /// </summary>
    public string AttrValue { get; set; }

    /// <summary>
    /// 属性值ID
    /// </summary>
    public string AttrValueId { get; set; }

    /// <summary>
    /// 属性编码
    /// </summary>
    public string CategoryAttrCode { get; set; }
}