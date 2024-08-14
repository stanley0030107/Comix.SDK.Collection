using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.SAP.SDK.Models
{
    public class PORequestDomain<T>
    {
        /// <summary>
        /// 系统编号
        /// </summary>
        public string SYSID { get; set; }

        /// <summary>
        /// 优先级规则(Y001>Z001>Z004>Y009),传了之后按优先级取一条
        /// </summary>
        public string? PRIORITY_VALUE { get; set; }
        /// <summary>
        /// 请求主体
        /// </summary>
        public T REQUEST { get; set; }
    }
}
