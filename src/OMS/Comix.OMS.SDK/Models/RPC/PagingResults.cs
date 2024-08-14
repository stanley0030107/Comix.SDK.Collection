using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.OMS.SDK.Models.RPC
{
    public class PagingResults<T>
    {
        /// <summary>
        /// 分页数据
        /// </summary>
        public List<T> PageData { get; set; }

        /// <summary>
        /// 满足条件的记录总数
        /// </summary>
        public Int64 RecordCount { get; set; }

        /// <summary>
        /// 当前页数
        /// </summary>
        public Int64 PageIndex { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public Int64 TotalPage { get; set; }

        /// <summary>
        /// 是否查询成功
        /// </summary>
        public Boolean Success { get; set; }

        /// <summary>
        /// 异常描述
        /// </summary>
        public String ErrorMsg { get; set; }
    }

}
