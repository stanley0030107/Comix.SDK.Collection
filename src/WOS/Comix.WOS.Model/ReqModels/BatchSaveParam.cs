using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.WOS.Model.ReqModels
{
    /// <summary>
    /// 
    /// </summary>
    public class BatchSaveParam
    {
        /// <summary>
        /// 平台类型 O2O QF
        /// </summary>
        public string platform { get; set; }

        /// <summary>
        /// 当前用户ID
        /// </summary>
        public int curUserId { get; set; }

        /// <summary>
        /// 当前用户名
        /// </summary>
        public string curUsername { get; set; }

        /// <summary>
        /// 数据范围1所有数据权限2自定义数据权限3本部门数据权限4本部门及以下数据权限5仅本人数据权限6Qx数据权限
        /// </summary>
        public string dataScope { get; set; }

        /// <summary>
        /// 工单类型1全部2订单模块3结算模块4商品上下架5投诉建议6其他
        /// </summary>
        public int modelType { get; set; }

        /// <summary>
        /// 受理人
        /// </summary>
        public List<string> acceptor { get; set; }

        /// <summary>
        /// 工单内容
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// 附件链接
        /// </summary>
        public string attachmentUrls { get; set; }

        /// <summary>
        /// 扩展字段
        /// </summary>
        public Dictionary<string,string> feature { get; set; }
    }
}
