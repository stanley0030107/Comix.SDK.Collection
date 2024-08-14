using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.COS.Model.RespModels
{
    public class Rootobject
    {
        public Msgheader msgHeader { get; set; }
        public Msgbody msgBody { get; set; }
    }

    public class Msgheader
    {
        public string origin { get; set; }
        public string action { get; set; }
        public string customerCode { get; set; }
        public string customerSkuCode { get; set; }
        public string messageId { get; set; }
        public string time { get; set; }
    }

    public class Msgbody
    {
        public MST_B2C_CUSTOMER_SKUS MST_B2C_CUSTOMER_SKUS { get; set; }
        public MST_B2C_CUSTOMER_PRODUCTS MST_B2C_CUSTOMER_PRODUCTS { get; set; }
        public MST_B2C_CUSTOMER_SKU_ATTRS MST_B2C_CUSTOMER_SKU_ATTRS { get; set; }
        public SYS_DATA_SYNC_OBJECT SYS_DATA_SYNC_OBJECT { get; set; }
    }

    public class MST_B2C_CUSTOMER_SKUS
    {
        public B2C_CUSTOMER_SKUS data { get; set; }
    }

    public class B2C_CUSTOMER_SKUS
    {
        public string CUSTOMER_SKU_ID { get; set; }
        public string CUSTOMER_SKU_CODE { get; set; }
        public string CUSTOMER_SKU_NAME { get; set; }
        public string CUSTOMER_SHORT_SKU_NAME { get; set; }
        public string CUSTOMER_PRODUCT_ID { get; set; }
        public string CUSTOMER_PRODUCT_CODE { get; set; }
        public int? CATEGORY_ID { get; set; }
        public string CATEGORY_CODE { get; set; }
        public int SKU_ID { get; set; }
        public string SKU_CODE { get; set; }
        public string SKU_NAME { get; set; }
        public int PRODUCT_ID { get; set; }
        public string PRODUCT_CODE { get; set; }
        public int STOCK { get; set; }
        public float PX_SALE_PRICE { get; set; }
        public float PX_TAX_PRICE { get; set; }
        public float PX_NAKED_PRICE { get; set; }
        public float? PX_TAX_RATE { get; set; }
        public string UPC { get; set; }
        public string ATTRIBUTE1 { get; set; }
        public string ATTRIBUTE2 { get; set; }
        public string ATTRIBUTE3 { get; set; }
        public string SAU { get; set; }
        public string SKU_PACKAGEPES { get; set; }
        public string SKU_PACKAGEPAC { get; set; }
        public string SKU_PACKAGEBOX { get; set; }
        public string SKU_PACKAGECAR { get; set; }
        public string JDSKU { get; set; }
        public string JDURL { get; set; }
        public float? JDPRICE { get; set; }
        public string PRODUCT_SPEC { get; set; }
        public string COLOR_RGB { get; set; }
        public int WEIGHT { get; set; }
        public int ALERT_STOCK { get; set; }
        public string COLOR_ID { get; set; }
        public string COLOR_VALUE { get; set; }
        public string SIZE_ID { get; set; }
        public string SIZE_VALUE { get; set; }
        public string SUITABLE_TYPE { get; set; }
        public string SKUIMAGE_URL { get; set; }
        public string B2BSKU { get; set; }
        public float SKU_RETAIL_PRICE { get; set; }
        public float SKU_SALE_UNIT_PRICE { get; set; }
        public string EAN { get; set; }
        public string SKU_SALE_UNIT_NAME { get; set; }
        public string SKU_SALE_ATTRIBUTE { get; set; }
        public string SKU_ATTRIBUTE1 { get; set; }
        public string SKU_ATTRIBUTE2 { get; set; }
        public string SOURCE_SKU { get; set; }
        public string GOOD_TYPE { get; set; }
        public string PRODUCT_MODEL { get; set; }
        public string LOGO_FLAG { get; set; }
        public string REPLACE_CUSTOMER_SKU_CODE { get; set; }
        public string EXTSKUATTR1 { get; set; }
        public string EXTSKUATTR2 { get; set; }
        public string EXTSKUATTR3 { get; set; }
        public string EXTSKUATTR4 { get; set; }
        public string EXTSKUATTR5 { get; set; }
        public string EXTSKUATTR6 { get; set; }
        public string EXTSKUATTR7 { get; set; }
        public string EXTSKUATTR8 { get; set; }
        public string EXTSKUATTR9 { get; set; }
        public string EXTSKUATTR10 { get; set; }
        public bool IS_DEFAULT { get; set; }
        public int CUSTOMER_ID { get; set; }
        public string CUSTOMER_CODE { get; set; }
        public int SUPPLIER_ID { get; set; }
        public string SUPPLIER_CODE { get; set; }
        public int STATUS { get; set; }
        public string REMARK { get; set; }
        public string CREATED_BY { get; set; }
        public string CREATED_TIME { get; set; }
        public string MODIFIED_BY { get; set; }
        public string MODIFIED_TIME { get; set; }
        public string JDTYPE { get; set; }
        public string TAX_CATEGORY_CODE { get; set; }
        public int IS_LOCK_PRICE { get; set; }
        public string NATIONAL_STANDARD { get; set; }
        public string PRODUCT_PARAMETER { get; set; }
        public string PACKING_LIST { get; set; }
        public string DESCRIPTION { get; set; }
        public string BRAND_CODE { get; set; }
        public string SALE_UNIT_NAME { get; set; }
        public int MIN_QUANTITY { get; set; }
        public string ENERGY_ID { get; set; }
        public string ENERGY_ID_TIME { get; set; }
        public float MARKET_PRICE { get; set; }
        public int IS_QUALIFICATIAN { get; set; }
        public string QUALIFICATIAN_TYPE { get; set; }
        public string QUALIFICATIONINFO { get; set; }
        
        public string CUSTOMER_IMG750 { get; set; }
        public string CUSTOMER_IMG800 { get; set; }
        public string CUSTOMER_IMG_FLAG { get; set; }
        public float? DISCOUNT { get; set; }
        public string SUBMIT_BY { get; set; }
        public string SUPPLIER_NAME { get; set; }
    }

    public class MST_B2C_CUSTOMER_PRODUCTS
    {
        public B2C_CUSTOMER_PRODUCTS data { get; set; }
    }

    public class B2C_CUSTOMER_PRODUCTS
    {
        public string CUSTOMER_PRODUCT_ID { get; set; }
        public string CUSTOMER_PRODUCT_CODE { get; set; }
        public string CUSTOMER_PRODUCT_NAME { get; set; }
        public string CUSTOMER_SHORT_PRODUCT_NAME { get; set; }
        public string SHORT_DESCRIPTION { get; set; }
        public int? CUSTOMER_CATEGORY_ID { get; set; }
        public string CUSTOMER_CATEGORY_CODE { get; set; }
        public int? FIRST_CATEGORY_ID { get; set; }
        public string FIRST_CATEGORY_CODE { get; set; }
        public int PRODUCT_ID { get; set; }
        public string PRODUCT_CODE { get; set; }
        public float LIST_PRICE { get; set; }
        public float MARKET_PRICE { get; set; }
        public float LOWEST_SALE_PRICE { get; set; }
        public float PX_NAKED_PRICE { get; set; }
        public float PX_TAX_PRICE { get; set; }
        public string RELATION_ID { get; set; }
        public int TYPE_ID { get; set; }
        public int BRAND_ID { get; set; }
        public string BRAND_CODE { get; set; }
        public int REGION_ID { get; set; }
        public string UNIT { get; set; }
        public string DESCRIPTION { get; set; }
        public string META_TITLE { get; set; }
        public string META_DESCRIPTION { get; set; }
        public string META_KEYWORDS { get; set; }
        public int SALE_COUNTS { get; set; }
        public int STOCK { get; set; }
        public int DISPLAY_SEQUENCE { get; set; }
        public bool HAS_SKU { get; set; }
        public float POINTS { get; set; }
        public string IMAGE_URL { get; set; }
        public int THUMBNAIL_COUNT { get; set; }
        public string THUMBNAIL_URL1 { get; set; }
        public string THUMBNAIL_URL2 { get; set; }
        public string THUMBNAIL_URL3 { get; set; }
        public string THUMBNAIL_URL4 { get; set; }
        public string THUMBNAIL_URL5 { get; set; }
        public string THUMBNAIL_URL6 { get; set; }
        public string THUMBNAIL_URL7 { get; set; }
        public string THUMBNAIL_URL8 { get; set; }
        public string THUMBNAIL_URL9 { get; set; }
        public string THUMBNAIL_URL10 { get; set; }
        public string THUMBNAIL_URL11 { get; set; }
        public string THUMBNAIL_URL12 { get; set; }
        public string THUMBNAIL_URL13 { get; set; }
        public int MAX_QUANTITY { get; set; }
        public int MIN_QUANTITY { get; set; }
        public string TAGS { get; set; }
        public string SEO_URL { get; set; }
        public string SEO_IMAGE_ALT { get; set; }
        public string SEO_IMAGE_TITLE { get; set; }
        public int SALES_TYPE { get; set; }
        public int RESTRICTION_COUNT { get; set; }
        public string DELIVERY_TIP { get; set; }
        public string OMS_GROUP { get; set; }
        public string PACKAG1 { get; set; }
        public string PACKAG2 { get; set; }
        public string PACKAG3 { get; set; }
        public string PACKAG0 { get; set; }
        public string PRODUCT_MODEL { get; set; }
        public string WAP_DESCRIPTION { get; set; }
        public string UNIT_NAME { get; set; }
        public string SALE_UNIT_NAME { get; set; }
        public string PRODUCT_SALE_ATTRIBUTE { get; set; }
        public float PRODUCT_RETAIL_PRICE { get; set; }
        public float PRODUCT_SALE_UNIT_PRICE { get; set; }
        public string PACKAGE_SAU { get; set; }
        public string JD_SKU { get; set; }
        public string JD_URL { get; set; }
        public float? JD_PRICE { get; set; }
        public string JDTYPE { get; set; }
        public string PRODUCT_PARAMETER { get; set; }
        public string PAIR_PRODUCT_PARAMETER { get; set; }
        public string PACKING_LIST { get; set; }
        public bool IS_MASTER { get; set; }
        public int TAG { get; set; }
        public bool IS_DEFAULT { get; set; }
        public bool IS_SINGLE_BUY { get; set; }
        public string ADDED_DATE { get; set; }
        public string EXATTRIBUTE { get; set; }
        public string GOOD_TYPE { get; set; }
        public string PRODUCT_SPEC { get; set; }
        public string LOGO_FLAG { get; set; }
        public string ATTRIBUTE1 { get; set; }
        public string ATTRIBUTE2 { get; set; }
        public string ATTRIBUTE3 { get; set; }
        public string EXTPROATTR1 { get; set; }
        public string EXTPROATTR2 { get; set; }
        public string EXTPROATTR3 { get; set; }
        public string EXTPROATTR4 { get; set; }
        public string EXTPROATTR5 { get; set; }
        public string EXTPROATTR6 { get; set; }
        public string EXTPROATTR7 { get; set; }
        public string EXTPROATTR8 { get; set; }
        public string EXTPROATTR9 { get; set; }
        public string EXTPROATTR10 { get; set; }
        public int SUPPLIER_ID { get; set; }
        public string SUPPLIER_CODE { get; set; }
        public int CUSTOMER_ID { get; set; }
        public string CUSTOMER_CODE { get; set; }
        public int STATUS { get; set; }
        public string REMARK { get; set; }
        public string CREATED_USER { get; set; }
        public string CREATED_TIME { get; set; }
        public string MODIFIED_USER { get; set; }
        public string MODIFIED_TIME { get; set; }
        public string ENERGY_ID { get; set; }
        public string ENERGY_ID_TIME { get; set; }
        public string CUSTOMER_PRODUCT_EN_NAME { get; set; }
        public int IS_ENVIRONMENT_PROTECT { get; set; }
        public string ENVIRONMENT_PROTECT_MODEL { get; set; }
        public string ENVIRONMENT_PROTECT_PAGE { get; set; }
        public string ENGERY_PAGE { get; set; }
        public string ENGERY_MODEL { get; set; }
        public string ENVIRONMENT_PROTECT_EXPIRE { get; set; }
        public int THIRD_CATEGORY_ID { get; set; }
        public string ENGERY_BRAND { get; set; }
        public string ENVIRONMENT_BRAND { get; set; }
        public string ENVIRONMENT_SN { get; set; }
        public string ENGERY_SN { get; set; }
        public string SPU_ATTRS { get; set; }
        public string ENVIRONMENT_PROTECT_PICTURE_ADDRESS { get; set; }
        public string ENGERY_PICTURE_ADDRESS { get; set; }
        public string ENGERY_ORG { get; set; }
        public string ENVIRONMENT_ORG { get; set; }

    }




    public class MST_B2C_CUSTOMER_SKU_ATTRS
    {
        public List<CUSTOMER_SKU_ATTRS> data { get; set; }
    }

    public class CUSTOMER_SKU_ATTRS
    {
        public string SKU_ATTR_ID { get; set; }
        public string CUSTOMER_CODE { get; set; }
        public string CUSTOMER_SKU_CODE { get; set; }
        public int CATEGORY_ATTR_ID { get; set; }
        public string ATTR_NAME { get; set; }
        public string ATTR_VALUE { get; set; }
        public bool STATUS { get; set; }
        public bool IS_DELETE { get; set; }
        public string CREATED_BY { get; set; }
        public string CREATED_TIME { get; set; }
        public string MODIFIED_BY { get; set; }
        public string MODIFIED_TIME { get; set; }
        public string ATTR_VALUE_ID { get; set; }
        public string CATEGORY_ATTR_CODE { get; set; }
    }


    public class SYS_DATA_SYNC_OBJECT
    {
        public List<DATA_SYNC_OBJECT> data { get; set; }
    }

    public class DATA_SYNC_OBJECT
    {
        public string ID { get; set; }
        public string SYNC_ID { get; set; }
        public string SYSTEM_NAME { get; set; }
        public string OBJECT_ID { get; set; }
        public string OBJECT_CODE { get; set; }
        public string OBJECT_TYPE { get; set; }
        public string SYNC_TYPE { get; set; }
        public bool SYNC_STATUS { get; set; }
        public string SYNC_TIME { get; set; }
        public int SYNC_TIMES { get; set; }
        public string REMARK { get; set; }
        public string CREATE_TIME { get; set; }
        public string CHANGE_TYPE_CODE { get; set; }
        public string CHANGE_TYPE { get; set; }
        public string STATUS { get; set; }
        public PRICE_TAB PRICE_TAB { get; set; } 
        public PIC_TAB PIC_TAB { get; set; }

    }

    public class PRICE_TAB
    {
        /// <summary>
        /// 标准价
        /// </summary>
        public float STANDARD_PRICE { get; set; }
        /// <summary>
        /// 标准裸价
        /// </summary>
        public float STANDARD_NAKED_PRICE { get; set; }
        /// <summary>
        /// 标准税价
        /// </summary>
        public float STANDARD_TAX_PRICE { get; set; }
        /// <summary>
        /// 客户裸价
        /// </summary>
        public float CUS_NAKED_PRICE { get; set; }
        /// <summary>
        /// 客户税价
        /// </summary>
        public float CUS_TAX_PRICE { get; set; }
        /// <summary>
        /// 客户结算价
        /// </summary>
        public float SETTLEMENT_PRICE { get; set; }
    }

     

    public class PIC_TAB
    {
        public bool CUSTOMER_IMG_FLAG { get; set; }
        public string SKUIMAGE_URL { get; set; }
        public string CUSTOMER_IMG800 { get; set; }
        public string CUSTOMER_IMG750 { get; set; }
        public string DESCRIPTION { get; set; }
        public string IMAGE_URL { get; set; }
        public int THUMBNAIL_COUNT { get; set; }
        public string THUMBNAIL_URL1 { get; set; }
        public string THUMBNAIL_URL2 { get; set; }
        public string THUMBNAIL_URL3 { get; set; }
        public string THUMBNAIL_URL4 { get; set; }
        public string THUMBNAIL_URL5 { get; set; }
        public string THUMBNAIL_URL6 { get; set; }
        public string THUMBNAIL_URL7 { get; set; }
        public string THUMBNAIL_URL8 { get; set; }
        public string THUMBNAIL_URL9 { get; set; }
        public string THUMBNAIL_URL10 { get; set; }
        public string THUMBNAIL_URL11 { get; set; }
        public string THUMBNAIL_URL12 { get; set; }
        public string THUMBNAIL_URL13 { get; set; }
    }



}