using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.Core.BaseModels
{
    public class ResponseHeader
    {
        public string RetCode { get; set; }
        public string RetMessage { get; set; }
        public string RetErrCode { get; set; }

        public bool Success => !string.IsNullOrEmpty(RetCode) && RetCode.Equals("Y");
    }
}
