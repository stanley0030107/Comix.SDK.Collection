using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.WOS.Model.RespModels
{    
    /// <summary>
    /// 客诉统计待办 结果
    /// </summary>
    public class RespComplaintsStatistics
    {
        public int pendingNum { get; set; }
        public int waitReturnVisitNum { get; set; }
    }
}
