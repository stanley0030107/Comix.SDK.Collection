using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.KuaiDi100.SDK.Models
{
    public class KuaiDi100AddressParseConfig
    {
        /// <summary>
        /// 授权key
        /// </summary>
        public string key { get; set; }
        /// <summary>
        /// secret
        /// </summary>
        public string secret { get; set; }
        /// <summary>
        /// customer
        /// </summary>
        public string secret_sign { get; set; }
    }
}
