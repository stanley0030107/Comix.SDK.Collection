using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common;
using ComixSAP.Common.SAP;

namespace ComixSAP.Common.Model
{
    [DataContract]
    public class ZWMSDeliveryOrderModel : SapModelBase
    {

        public override void SetFieldNames()
        {
            this.PropertyNames = new List<string> {
           "VBELN","POSNR","MATNR","LFIMG","MEINS","DOCTYPE","WERKS","LGORT","WHSEID","WMSDATE","WMSKEY","WMSLINE"};
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
        public string Posnr
        {
            get
            {
                return base.GetProperty<string>("POSNR");
            }
            set
            {
                base.SetProperty("POSNR", value);
            }
        }

        [DataMember]
        //物料号 
        public string Prodcode
        {
            get
            {
                return base.GetProperty<string>("MATNR");
            }
            set
            {
                base.SetProperty("MATNR", value);
            }
        }

        [DataMember]
        //实际已交货量（按销售单位）
        public string Postqty
        {
            get
            {
                return base.GetProperty<string>("LFIMG");
            }
            set
            {
                base.SetProperty("LFIMG", value);
            }
        }

        [DataMember]
        //基本计量单位
        public string Baseunit
        {
            get
            {
                return base.GetProperty<string>("MEINS");
            }
            set
            {
                base.SetProperty("MEINS", value);
            }
        }

        [DataMember]
        //销售凭证类型 
        public string Vouchertype
        {
            get
            {
                return base.GetProperty<string>("DOCTYPE");
            }
            set
            {
                base.SetProperty("DOCTYPE", value);
            }
        }

        [DataMember]
        //工厂
        public string Factorycode
        {
            get
            {
                return base.GetProperty<string>("WERKS");
            }
            set
            {
                base.SetProperty("WERKS", value);
            }
        }

        [DataMember]
        //库存地点
        public string Stockcode
        {
            get
            {
                return base.GetProperty<string>("LGORT");
            }
            set
            {
                base.SetProperty("LGORT", value);
            }
        }

        [DataMember]
        //仓库标识
        public string Stockflag
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
        //创建日期
        public string Createdate
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
        public string Itemno
        {
            get
            {
                return base.GetProperty<string>("WMSLINE");
            }
            set
            {
                base.SetProperty("WMSLINE", value);
            }
        }

    }
}
