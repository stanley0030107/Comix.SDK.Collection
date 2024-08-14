using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common;
using ComixSAP.Common.SAP;

namespace ComixSAP.Common.Model
{
    [DataContract]
    public class CreateSapCustomerSalesOrgReturnModel : SapModelBase
    {
        public override void SetFieldNames()
        {
            this.PropertyNames = new List<string> { 
           "TCODE","DYNAME","DYNUMB","MSGTYP","MSGSPRA","MSGID","MSGNR","MSGV1","MSGV2","MSGV3","MSGV4","ENV","FLDNAME"};
        }

        [DataMember]
        //事务代码
        public string Tcode
        {
            get
            {
                return base.GetProperty<string>("TCODE");
            }
            set
            {
                base.SetProperty("TCODE", value);
            }
        }

        [DataMember]
        //批输入模块名称
        public string Dyname
        {
            get
            {
                return base.GetProperty<string>("DYNAME");
            }
            set
            {
                base.SetProperty("DYNAME", value);
            }
        }

        [DataMember]
        //批输入屏幕数字
        public string Dynumb
        {
            get
            {
                return base.GetProperty<string>("DYNUMB");
            }
            set
            {
                base.SetProperty("DYNUMB", value);
            }
        }

        [DataMember]
        //批输入信息类型
        public string Msgtyp
        {
            get
            {
                return base.GetProperty<string>("MSGTYP");
            }
            set
            {
                base.SetProperty("MSGTYP", value);
            }
        }

        [DataMember]
        //报文语言
        public decimal Msgspra
        {
            get
            {
                return base.GetProperty<decimal>("MSGSPRA");
            }
            set
            {
                base.SetProperty("MSGSPRA", value);
            }
        }

        [DataMember]
        //批输入信息ID
        public string Msgid
        {
            get
            {
                return base.GetProperty<string>("MSGID");
            }
            set
            {
                base.SetProperty("MSGID", value);
            }
        }

        [DataMember]
        //批输入信息数量
        public string Msgnr
        {
            get
            {
                return base.GetProperty<string>("MSGNR");
            }
            set
            {
                base.SetProperty("MSGNR", value);
            }
        }

        [DataMember]
        //信息的变量部分
        public string Msgv1
        {
            get
            {
                return base.GetProperty<string>("MSGV1");
            }
            set
            {
                base.SetProperty("MSGV1", value);
            }
        }

        [DataMember]
        //信息的变量部分
        public string Msgv2
        {
            get
            {
                return base.GetProperty<string>("MSGV2");
            }
            set
            {
                base.SetProperty("MSGV2", value);
            }
        }

        [DataMember]
        //信息的变量部分
        public string Msgv3
        {
            get
            {
                return base.GetProperty<string>("MSGV3");
            }
            set
            {
                base.SetProperty("MSGV3", value);
            }
        }

        [DataMember]
        //信息的变量部分
        public string Msgv4
        {
            get
            {
                return base.GetProperty<string>("MSGV4");
            }
            set
            {
                base.SetProperty("MSGV4", value);
            }
        }

        [DataMember]
        //活动的批输入监控
        public string Env
        {
            get
            {
                return base.GetProperty<string>("ENV");
            }
            set
            {
                base.SetProperty("ENV", value);
            }
        }

        [DataMember]
        //字段名
        public string Fldname
        {
            get
            {
                return base.GetProperty<string>("FLDNAME");
            }
            set
            {
                base.SetProperty("FLDNAME", value);
            }
        }

    }
}


