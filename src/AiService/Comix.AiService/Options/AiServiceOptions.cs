using Furion.ConfigurableOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.AiService.Options
{
    public class AiServiceOptions: IConfigurableOptions
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public string Url { get; set; }
    }
}
