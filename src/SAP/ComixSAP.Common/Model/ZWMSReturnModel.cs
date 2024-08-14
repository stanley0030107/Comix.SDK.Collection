using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common;
using ComixSAP.Common.SAP;

namespace ComixSAP.Common.Model
{
    [DataContract]
    public class ZWMSReturnModel : SapModelBase
    {

        public override void SetFieldNames()
        {
            this.PropertyNames = new List<string> {
           "MANDT","UUID","VBELN","POSNR","WMSKEY","WMSLINE","MDOC","MDOCLINENO","TYPE","STATUS","MESSAGE","WMSDATE","WHSEID","RFCNAME","UNAME","CREATDATE","CREATTIME"};
        }

        [DataMember]
        //集团
        public string Mandt
        {
            get
            {
                return base.GetProperty<string>("MANDT");
            }
            set
            {
                base.SetProperty("MANDT", value);
            }
        }

        [DataMember]
        //数据范围标识
        public string Uuid
        {
            get
            {
                return base.GetProperty<string>("UUID");
            }
            set
            {
                base.SetProperty("UUID", value);
            }
        }

        [DataMember]
        //销售和分销凭证号 
        public string Vbeln
        {
            get
            {
                return base.GetProperty<string>("VBELN");
            }
            set
            {
                base.SetProperty("VBELN", value);
            }
        }

        [DataMember]
        //销售和分销凭证的项目号
        public decimal Posnr
        {
            get
            {
                return base.GetProperty<decimal>("POSNR");
            }
            set
            {
                base.SetProperty("POSNR", value);
            }
        }

        [DataMember]
        //销售和分销凭证号 
        public string Wmskey
        {
            get
            {
                return base.GetProperty<string>("WMSKEY");
            }
            set
            {
                base.SetProperty("WMSKEY", value);
            }
        }

        [DataMember]
        //行号
        public decimal Wmsline
        {
            get
            {
                return base.GetProperty<decimal>("WMSLINE");
            }
            set
            {
                base.SetProperty("WMSLINE", value);
            }
        }

        [DataMember]
        //物料凭证编号
        public string Mdoc
        {
            get
            {
                return base.GetProperty<string>("MDOC");
            }
            set
            {
                base.SetProperty("MDOC", value);
            }
        }

        [DataMember]
        //物料凭证中的项目
        public string Mdoclineno
        {
            get
            {
                return base.GetProperty<string>("MDOCLINENO");
            }
            set
            {
                base.SetProperty("MDOCLINENO", value);
            }
        }

        [DataMember]
        //销售凭证类型 
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
        //消息类型: S 成功,E 错误,W 警告,I 信息,A 中断
        public string Status
        {
            get
            {
                return base.GetProperty<string>("STATUS");
            }
            set
            {
                base.SetProperty("STATUS", value);
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
        //凭证中的凭证日期
        public string Wmsdate
        {
            get
            {
                return base.GetProperty<string>("WMSDATE");
            }
            set
            {
                base.SetProperty("WMSDATE", value);
            }
        }

        [DataMember]
        //仓库标识
        public string Whseid
        {
            get
            {
                return base.GetProperty<string>("WHSEID");
            }
            set
            {
                base.SetProperty("WHSEID", value);
            }
        }

        [DataMember]
        //接口名称
        public string Rfcname
        {
            get
            {
                return base.GetProperty<string>("RFCNAME");
            }
            set
            {
                base.SetProperty("RFCNAME", value);
            }
        }

        [DataMember]
        //用户名 
        public string Uname
        {
            get
            {
                return base.GetProperty<string>("UNAME");
            }
            set
            {
                base.SetProperty("UNAME", value);
            }
        }

        [DataMember]
        //创建日期
        public string Creatdate
        {
            get
            {
                return base.GetProperty<string>("CREATDATE");
            }
            set
            {
                base.SetProperty("CREATDATE", value);
            }
        }

        [DataMember]
        //日历：创建或更改时间
        public string Creattime
        {
            get
            {
                return base.GetProperty<string>("CREATTIME");
            }
            set
            {
                base.SetProperty("CREATTIME", value);
            }
        }

    }
}
