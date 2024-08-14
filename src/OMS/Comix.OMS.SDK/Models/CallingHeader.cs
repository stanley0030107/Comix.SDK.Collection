using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.OMS.SDK.Models
{
    public class CallingHeader
    {
        private string _systemId = "C00001";

        private string _systemName = "齐心OMS系统";

        private string _tokenStr = "";

        private string _userCode = "";

        private int _subSysType = 0;

        private string _loginIP = string.Empty;

        private string _loginComputerName = string.Empty;

        private string _operateTime = "";

        public string systemId
        {
            get
            {
                return _systemId;
            }
            set
            {
                _systemId = value;
            }
        }

        public string systemName
        {
            get
            {
                return _systemName;
            }
            set
            {
                _systemName = value;
            }
        }

        public string tokenStr
        {
            get
            {
                return _tokenStr;
            }
            set
            {
                _tokenStr = value;
            }
        }

        public string UserCode
        {
            get
            {
                return _userCode;
            }
            set
            {
                _userCode = value;
            }
        }

        public int SubSysType
        {
            get
            {
                return _subSysType;
            }
            set
            {
                _subSysType = value;
            }
        }

        public string LoginIP
        {
            get
            {
                return _loginIP;
            }
            set
            {
                _loginIP = value;
            }
        }

        public string LoginComputerName
        {
            get
            {
                return _loginComputerName;
            }
            set
            {
                _loginComputerName = value;
            }
        }

        public string OperateTime
        {
            get
            {
                return _operateTime;
            }
            set
            {
                _operateTime = value;
            }
        }
    }
}
