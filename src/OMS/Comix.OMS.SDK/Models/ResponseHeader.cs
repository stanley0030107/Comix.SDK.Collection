using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.OMS.SDK.Models
{
    public class ResponseHeader
    {
        private string _retCode = "Y";

        private string _retMessage = string.Empty;

        private string _retErrCode = string.Empty;

        public string retCode
        {
            get
            {
                return _retCode;
            }
            set
            {
                _retCode = value;
            }
        }

        public string retMessage
        {
            get
            {
                return _retMessage;
            }
            set
            {
                _retMessage = value;
            }
        }

        public string retErrCode
        {
            get
            {
                return _retErrCode;
            }
            set
            {
                _retErrCode = value;
            }
        }
    }
}
