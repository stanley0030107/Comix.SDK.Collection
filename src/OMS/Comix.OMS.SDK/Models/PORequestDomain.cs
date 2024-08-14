using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComixCDP.Common.OMSMoldes
{
    public class PORequestDomain<T>
    {
        /// <summary>
        /// 系统编号
        /// </summary>
        public string SYSID { get; set; }

        /// <summary>
        /// 请求主体
        /// </summary>
        public T REQUEST { get; set; }
    }
}
