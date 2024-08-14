namespace Comix.COS.Model.RespModels
{
    public class QuerySapCodeOutput
    {
        /// <summary>
        /// 物料编码
        /// </summary>
        public string materialCode { get; set; }
        /// <summary>
        /// 税率
        /// </summary>
        public decimal? vat { get; set; }
    }
}