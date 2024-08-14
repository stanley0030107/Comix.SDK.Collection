using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.Cics.Model.ReqModels
{
    public class NotifyCallBackParam
    {
        public string bizCode { get; set; }

        public List<string> workOrderCodes { get; set; }

        /// <summary>
        /// 处理状态 2转工单 3转人工 4处理完成 5处理失败
        /// </summary>
        public int handleStatus { get; set; }

        public string remark { get; set; }
    }
}
