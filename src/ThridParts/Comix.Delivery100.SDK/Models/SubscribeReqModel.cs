using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.Delivery100.SDK.Models
{
    public class SubscribeReqModel
    {
        /// <summary>
        /// 返回数据格式(json、xml、text)
        /// </summary>
        public string schema { get; set; }
        /// <summary>
        /// 其他参数
        /// </summary>
        public MainParas param { get; set; }
    }
}
