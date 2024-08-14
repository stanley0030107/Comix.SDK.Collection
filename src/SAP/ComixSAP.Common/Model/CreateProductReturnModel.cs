using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common;
using ComixSAP.Common.SAP;

namespace ComixSAP.Common.Model
{
    [DataContract]
    public class CreateProductReturnModel : SapModelBase
    {
        public override void SetFieldNames()
        {
            this.PropertyNames = new List<string> { 
           "MESSAGEID","TYPE","ID","NUM","MESSAGE","LOG_NO","LOG_MSG_NO","MESSAGE_V1","MESSAGE_V2","MESSAGE_V3","MESSAGE_V4","PAR_NAME","FIELD"};
        }

        [DataMember]
        //物料流水号 
        public string Messageid
        {
            get
            {
                return base.GetProperty<string>("MESSAGEID");
            }
            set
            {
                base.SetProperty("MESSAGEID", value);
            }
        }

        [DataMember]
        //消息类型: S 成功,E 错误,W 警告,I 信息,A 中断
        public string Type
        {
            get
            {
                return base.GetProperty<string>("TYPE");
            }
            set
            {
                base.SetProperty("TYPE", value);
            }
        }

        [DataMember]
        //消息, 消息类 
        public string Id
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
        //消息, 消息编号
        public decimal Num
        {
            get
            {
                return base.GetProperty<decimal>("NUM");
            }
            set
            {
                base.SetProperty("NUM", value);
            }
        }

        [DataMember]
        //消息文本
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
        //应用程序日志: 日志号 
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
        //应用日志：内部邮件序列号
        public decimal LogMsgNo
        {
            get
            {
                return base.GetProperty<decimal>("LOG_MSG_NO");
            }
            set
            {
                base.SetProperty("LOG_MSG_NO", value);
            }
        }

        [DataMember]
        //消息,消息变量
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
        //消息,消息变量
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
        //消息,消息变量
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
        //消息,消息变量
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
        //参数名称
        public string ParName
        {
            get
            {
                return base.GetProperty<string>("PAR_NAME");
            }
            set
            {
                base.SetProperty("PAR_NAME", value);
            }
        }

        [DataMember]
        //参数中的字段
        public string Field
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

    }
}


