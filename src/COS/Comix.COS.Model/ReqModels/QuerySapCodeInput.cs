namespace Comix.COS.Model.ReqModels
{
    public class QuerySapCodeInput
    {
        /// <summary>
        /// 物料商品全称
        /// </summary>
        public string productName { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        public string categoryName { get; set; }
        /// <summary>
        /// 商品销售单位
        /// </summary>
        public string unit { get; set; }
        /// <summary>
        /// 品牌
        /// </summary>
        public string brandName { get; set; }
        /// <summary>
        /// 型号
        /// </summary>
        public string model { get; set; }
    }
}