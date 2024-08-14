using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.Cics.Model.RespModels
{
    public class ResponseBase<T>
    {
        public ResponseBase() { }

        public bool success { get; set; }

        public string code { get; set; }

        public string msg { get; set; }

        public string traceId { get; set; }

        public T data { get; set; }
    }
}
