using System;
using System.Collections.Generic;
using System.Text;
using Furion.ConfigurableOptions;

namespace Comix.RPA.SDK.Options
{
    public class RpaOptions : IConfigurableOptions
    {
        /// <summary>
        /// RPA请求地址
        /// 测试地址：http: / 172.18.10.16:8989/rpa/data
        /// 生产地址：http: / 172.17.8.108:8989/rpa/data
        /// </summary>
        public string Url { get; set; }
    }
}
