using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.OMS.SDK.Models
{
    public class RequestBase<T> where T : new()
    {
        private CallingHeader _msgHeader = new CallingHeader();

        private T _msgBody = new T();

        public CallingHeader MsgHeader
        {
            get
            {
                return _msgHeader;
            }
            set
            {
                _msgHeader = value;
            }
        }

        public T MsgBody
        {
            get
            {
                return _msgBody;
            }
            set
            {
                _msgBody = value;
            }
        }
    }
}
