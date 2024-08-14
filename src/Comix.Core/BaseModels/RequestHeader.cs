using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.Core.BaseModels
{
    public class RequestHeader
    {
        public string SystemId { get; set; }
        public string SystemName { get; set; }
        public string TokenStr { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string LoginIP { get; set; }
        public string LoginComputerName { get; set; }
        public string OperateTime { get; set; } = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
    }
}
