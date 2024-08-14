namespace Comix.COS.Model.EventModels
{
    public class EventName
    {
        #region 官网商品

        public const string MallProductEvent = "TOPIC-COS-MALL-PRODUCT-UAT@mall-product";
        public const string MallProductCallbackEvent = "TOPIC-COS-MALL-PRODUCT-FEEDBACK-UAT@mall-product-feedback";
        public const string MallProductQualificationEvent = "TOPIC-COS-MALL-PRODUCT-UAT@qualification";

        public const string MallBaseDataBrandEvent = "TOPIC-COS-MALL-BASE-DATA-UAT@brand";
        public const string MallBaseDataCategoryEvent = "TOPIC-COS-MALL-BASE-DATA-UAT@category";

        #endregion

        #region 合约商品

        public const string CustomerProductImgEvent = "TOPIC-COS-CUSTOMER-PRODUCT-UAT@product-image";
        public const string CustomerProductEvent = "TOPIC-COS-CUSTOMER-PRODUCT-UAT@product";
        public const string CustomerProductCallbackEvent = "TOPIC-COS-PROJECT-PRODUCT-FEEDBACK-UAT@product";

        public const string CustomerBaseDataBrandEvent = "TOPIC-UAT-COS-CON-SERVICE@concustomerbrands";
        public const string CustomerBaseDataCategoryEvent = "TOPIC-UAT-COS-CON-SERVICE@concustomercategories";

        #endregion


        #region 官网商品

        public const string MallProductEvent_Release = "TOPIC-COS-MALL-PRODUCT-PRD@mall-product";

        public const string MallProductCallbackEvent_Release =
            "TOPIC-COS-MALL-PRODUCT-FEEDBACK-PRD@mall-product-feedback";

        public const string MallProductQualificationEvent_Release = "TOPIC-COS-MALL-PRODUCT-PRD@qualification";

        public const string MallBaseDataBrandEvent_Release = "TOPIC-COS-MALL-BASE-DATA-PRD@brand";
        public const string MallBaseDataCategoryEvent_Release = "TOPIC-COS-MALL-BASE-DATA-PRD@category";

        #endregion

        #region 合约商品

        public const string CustomerProductImgEvent_Release = "TOPIC-COS-CUSTOMER-PRODUCT@product-image";
        public const string CustomerProductEvent_Release = "TOPIC-COS-CUSTOMER-PRODUCT@product";
        public const string CustomerProductCallbackEvent_Release = "TOPIC-COS-PROJECT-PRODUCT-FEEDBACK-PRD@product";

        public const string CustomerBaseDataBrandEvent_Release = "TOPIC-COS-CON-PRODUCT@concustomerbrands";
        public const string CustomerBaseDataCategoryEvent_Release = "TOPIC-COS-CON-PRODUCT@concustomercategories";

        #endregion
    }
}