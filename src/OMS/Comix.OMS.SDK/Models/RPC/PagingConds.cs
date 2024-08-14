using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comix.OMS.SDK.Models.RPC
{
    /// <summary>
    /// 分页条件
    /// </summary>
    public class PagingConds
    {

        /// <summary>
        /// 分页条件初始化
        /// </summary>
        public PagingConds()
        {
            Conds = new Dictionary<string, string>();
        }
        /// <summary>
        /// 分页信息
        /// </summary>
        public PageInfo PageInfo { get; set; }
        /// <summary>
        /// 本次查询配置的名称
        /// </summary>
        public string QueryName { get; set; }
        /// <summary>
        /// 查询条件
        /// "test_name": "3",                                         等于
        /// "test_int": "0->100",                                     值范围  适合整形或者浮点数
        /// "test_int_null": "3",                                     等于
        /// "test_dll": "[3],[4],[5]",                                in多个值  适合整形或者字符串
        /// "test_time": "2017-01-01 00:00:00->2019-01-01 00:00:00"   时间范围
        /// </summary>
        public Dictionary<string, string> Conds { get; set; }

    }

    /// <summary>
    /// 分页信息
    /// </summary>
    public class PageInfo
    {
        /// <summary>
        /// 每页记录条数（整形，不能为空）
        /// </summary>
        public int? PageSize { get; set; }
        /// <summary>
        /// 第几页（整形，不能为空）
        /// </summary>
        public int? PageIndex { get; set; }
        /// <summary>
        /// 排序字段（可以为空，默认按照创建时间排序）
        /// </summary>
        public string SortField { get; set; }
        /// <summary>
        /// 排序类型 ASC  DESC（为空默认ASC）
        /// </summary>
        public string SortType { get; set; }
        /// <summary>
        /// 共有多少页
        /// </summary>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public int GetTotalPageNum(long RecordCount)
        {
            var c = RecordCount / (long)PageSize.Value;
            if (c > 0)
            {
                c = c + 1;
            }
            return (int)c;
        }
    }
}
