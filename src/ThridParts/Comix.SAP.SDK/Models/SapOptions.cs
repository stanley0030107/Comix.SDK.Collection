using Furion.ConfigurableOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.SAP.SDK.Models
{
    public class SapOptions : IConfigurableOptions
    {
        /// <summary>
        /// SAP请求地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 生成Token得User
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// 生成Token得Password
        /// </summary>
        public string Password { get; set; }    
    }
}
