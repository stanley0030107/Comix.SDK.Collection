using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.OMS.SDK.Models
{
    public class ResponseBase
    {
        public ResponseHeader MsgHeader { get; set; } = new ResponseHeader();
    }

    public class ResponseBase<T> : ResponseBase where T : new() 
    {
        public T MsgBody { get; set; } = new T();
    }
}
