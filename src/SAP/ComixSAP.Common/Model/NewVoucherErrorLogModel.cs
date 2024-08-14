using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using ComixSAP.Common.SAP;
 

namespace ComixSAP.Common
{
    [DataContract]
    public class NewVoucherErrorLogModel : SapModelBase
    {
        public override void SetFieldNames()
        {
            this.PropertyNames = new List<string> { 
                "TYPE", "ID", "NUMBER", "MESSAGE", "LOG_NO", "LOG_MSG_NO", "MESSAGE_V1", "MESSAGE_V2","MESSAGE_V3","MESSAGE_V4","PARAMETER","ROW","FIELD","SYSTEM"};
        }

        [DataMember]
        public string ReturnType
        {
            get
            {
                return base.GetProperty<string>("TYPE");
            }
            set
            {
                base.SetProperty("TYPE", value, 1);
            }
        }

        [DataMember]
        public string ReturnID
        {
            get
            {
                return base.GetProperty<string>("ID");
            }
            set
            {
                base.SetProperty("ID", value);
            }
        }

        [DataMember]
        public int ReturnNumber
        {
            get
            {
                return base.GetProperty<int>("NUMBER");
            }
            set
            {
                base.SetProperty("NUMBER", value);
            }
        }
        [DataMember]
        public string Message
        {
            get
            {
                return base.GetProperty<string>("MESSAGE");
            }
            set
            {
                base.SetProperty("MESSAGE", value);
            }
        }

        [DataMember]
        public string LogNo
        {
            get
            {
                return base.GetProperty<string>("LOG_NO");
            }
            set
            {
                base.SetProperty("LOG_NO", value);
            }
        }

        [DataMember]
        public string LogMsgNo
        {
            get
            {
                return base.GetProperty<string>("LOG_MSG_NO");
            }
            set
            {
                base.SetProperty("LOG_MSG_NO", value);
            }
        }

        [DataMember]
        public string MessageV1
        {
            get
            {
                return base.GetProperty<string>("MESSAGE_V1");
            }
            set
            {
                base.SetProperty("MESSAGE_V1", value);
            }
        }

        [DataMember]
        public string MessageV2
        {
            get
            {
                return base.GetProperty<string>("MESSAGE_V2");
            }
            set
            {
                base.SetProperty("MESSAGE_V2", value);
            }
        }

        [DataMember]
        public string MessageV3
        {
            get
            {
                return base.GetProperty<string>("MESSAGE_V3");
            }
            set
            {
                base.SetProperty("MESSAGE_V3", value);
            }
        }

        [DataMember]
        public string MessageV4
        {
            get
            {
                return base.GetProperty<string>("MESSAGE_V4");
            }
            set
            {
                base.SetProperty("MESSAGE_V4", value);
            }
        }

        [DataMember]
        public string ReturnParameter
        {
            get
            {
                return base.GetProperty<string>("PARAMETER");
            }
            set
            {
                base.SetProperty("PARAMETER", value);
            }
        }

        [DataMember]
        public int ReturnRow
        {
            get
            {
                return base.GetProperty<int>("ROW");
            }
            set
            {
                base.SetProperty("ROW", value);
            }
        }

        [DataMember]
        public string ReturnField
        {
            get
            {
                return base.GetProperty<string>("FIELD");
            }
            set
            {
                base.SetProperty("FIELD", value);
            }
        }

        [DataMember]
        public string ReturnSystem
        {
            get
            {
                return base.GetProperty<string>("SYSTEM");
            }
            set
            {
                base.SetProperty("SYSTEM", value);
            }
        }
    }
}

