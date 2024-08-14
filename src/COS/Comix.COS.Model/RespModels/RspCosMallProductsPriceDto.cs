using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.COS.Model.RespModels
{ 
    public class RspCosMallProductsPriceDto
    {
        /// <summary>
        /// 商品编码
        /// </summary>
        public string mallProductCode { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>
        public string mallPrice { get; set; }
    }
     
}
