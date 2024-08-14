using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.Core.Enum
{
    /// <summary>
    /// 数据来源
    /// </summary>
    public enum DataSourceType
    {
        /// <summary>
        /// PC
        /// </summary>
        [Description("电脑端")]
        PC = 0,
        /// <summary>
        /// PC
        /// </summary>
        [Description("移动端")]
        MOBILE = 1,
        /// <summary>
        /// HD
        /// </summary>
        [Description("HD")]
        HD = 2,
        /// <summary>
        /// WAP
        /// </summary>
        [Description("WAP")]
        WAP = 3,
        /// <summary>
        /// H5
        /// </summary>
        [Description("H5")]
        H5 = 4,
        /// <summary>
        /// APP
        /// </summary>
        [Description("APP")]
        APP = 5
    }
}
