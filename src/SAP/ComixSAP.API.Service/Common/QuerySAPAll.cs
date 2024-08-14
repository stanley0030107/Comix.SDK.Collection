using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComixSAP.API.Service
{
    /// <summary>
    /// 查询主体
    /// </summary>
    public class QuerySAPALLRequestBody
    {
        /// <summary>
        /// 编码
        /// </summary>
        public string FIELDID { get; set; }

    }

    /// <summary>
    /// 查询集合
    /// </summary>
    public class QuerySAPALLRequestDomain
    {
        /// <summary>
        /// 编码
        /// </summary>
        public string SYSID { get; set; } = "CDP";
        /// <summary>
        /// 名称 CLIENT1 为1 时表示名称 无1的时候表示编码
        /// </summary>
        public string KEYNAME { get; set; }

        public List<QuerySAPALLRequestBody> ID_TABLE { get; set; }

    }
}
