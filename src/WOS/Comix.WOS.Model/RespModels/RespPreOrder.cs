using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.WOS.Model.RespModels
{
    /// <summary>
    /// 请求发起工单 返回的结果
    /// </summary>
    public class RespPreOrder
    {
        private bool _success = false;
        public bool success
        {
            get
            {
                if (code != "200")
                {
                    return false;
                }
                return _success;
            }
            set
            {
                _success = value;
            }
        }
        public string code { get; set; }
        public string msg { get; set; }
        public string traceId { get; set; }
        public Data data { get; set; }
    }

    /// <summary>
    /// 单据信息
    /// </summary>
    public class Data
    {
        public string token { get; set; }
    }

}
