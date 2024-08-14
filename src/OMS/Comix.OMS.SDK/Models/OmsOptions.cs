using Furion.ConfigurableOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.OMS.SDK.Models
{
    public class OmsOptions : IConfigurableOptions
    {
        /// <summary>
        /// Oms请求地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Oms请求地址
        /// </summary>
        public string FxUrl { get; set; }
    }
}
