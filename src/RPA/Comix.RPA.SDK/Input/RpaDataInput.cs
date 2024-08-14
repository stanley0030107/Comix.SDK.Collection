using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.RPA.SDK.Input
{
    /// <summary>
    /// RPA请求实体
    /// </summary>
    public class RpaDataInput
    {
        /// <summary>
        /// 业务单号
        /// </summary>
        [Required]
        public string code { get; set; }
        /// <summary>
        /// 业务类型标记，没有就不填
        /// </summary>
        public string codeType { get; set; } 
        /// <summary>
        /// / 是否重复爬取,1:重复爬取 ；不传或其他：不重复爬取
        /// </summary>
        public string repeat { get; set; }

        /// <summary>
        /// json字符串，子系统推送到rpa，附加信息，例如发票号码等
        /// </summary>
        public string additionalInfo { get; set; }
    }
}
