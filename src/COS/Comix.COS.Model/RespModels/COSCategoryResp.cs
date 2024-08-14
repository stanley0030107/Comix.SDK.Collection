using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.COS.Model.RespModels
{
  public   class COSCategoryResp
    {
        /// <summary>
        /// 合约商品数量	
        /// </summary>
        public string productCount { get; set; }

        /// <summary>
        /// 分类状态	
        /// </summary>
        public string categoryStatus { get; set; }

        /// <summary>
        /// 分类级别	
        /// </summary>
        public int categoryLevel { get; set; }

        /// <summary>
        /// 客户分类Id	
        /// </summary>
        public string customerCategoryId { get; set; }

        /// <summary>
        /// 齐心分类Id或Id集合	
        /// </summary>
        public string categoryId { get; set; }

        /// <summary>
        /// 客户id	
        /// </summary>
        public string customerId { get; set; }

        /// <summary>
        /// 客户编码	
        /// </summary>
        public string customerCode { get; set; }

        /// <summary>
        /// 齐心分类名称	
        /// </summary>
        public string categoryName { get; set; }

        /// <summary>
        /// 类别编码	
        /// </summary>
        public string categoryCode { get; set; }

        /// <summary>
        /// 分类图片地址	
        /// </summary>
        public string imageUrl { get; set; }

        /// <summary>
        /// 子类目
        /// </summary>
        public List<COSCategoryResp> children { get; set; }
    }
}
