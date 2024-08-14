using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.WOS.Model.ReqModels
{
    /// <summary>
    /// 请求发起工单
    /// </summary>
    public class CommentStaticsParam
    {
        /// <summary>
        /// 请求接口的平台编码
        /// </summary>
        public string platform { get; set; }

        /// <summary>
        /// 业务单据数据
        /// </summary>
        public int curUserId { get; set; }

    }


}
