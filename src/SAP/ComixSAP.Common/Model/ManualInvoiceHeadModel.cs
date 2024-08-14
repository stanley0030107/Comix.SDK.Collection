using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common;
using ComixSAP.Common.SAP;

namespace ComixSAP.Common.Model
{
    [DataContract]
    public class ManualInvoiceHeadModel : SapModelBase
    {
        public override void SetFieldNames()
        {
            this.PropertyNames = new List<string> { 
           "ORDERNO","MESSAGEID","BUKRS","VKORG","VTWEG","SPART","KUNNR","ZTERM","FKDAT","AMOUNT","NETWR","MWSBP","DIS_VALUE","WAERS","TOTAL_ITEM","RENARK"};
        }

        [DataMember]
        //商城订单号 
        public string Orderno
        {
            get
            {
                return base.GetProperty<string>("ORDERNO");
            }
            set
            {
                base.SetProperty("ORDERNO", value);
            }
        }

        [DataMember]
        //商城订单号 
        public string MessageId
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
        //公司代码
        public string Bukrs
        {
            get
            {
                return base.GetProperty<string>("BUKRS");
            }
            set
            {
                base.SetProperty("BUKRS", value);
            }
        }

        [DataMember]
        //销售组织 
        public string Vkorg
        {
            get
            {
                return base.GetProperty<string>("VKORG");
            }
            set
            {
                base.SetProperty("VKORG", value);
            }
        }

        [DataMember]
        //分销渠道
        public string Vtweg
        {
            get
            {
                return base.GetProperty<string>("VTWEG");
            }
            set
            {
                base.SetProperty("VTWEG", value);
            }
        }

        [DataMember]
        //产品组 
        public string Spart
        {
            get
            {
                return base.GetProperty<string>("SPART");
            }
            set
            {
                base.SetProperty("SPART", value);
            }
        }

        [DataMember]
        //购方编号
        public string Kunnr
        {
            get
            {
                return base.GetProperty<string>("KUNNR");
            }
            set
            {
                base.SetProperty("KUNNR", value);
            }
        }

        [DataMember]
        //付款条件编码
        public string Zterm
        {
            get
            {
                return base.GetProperty<string>("ZTERM");
            }
            set
            {
                base.SetProperty("ZTERM", value);
            }
        }

        [DataMember]
        //出具发票索引和打印的出具发票日期
        public string Fkdat
        {
            get
            {
                return base.GetProperty<string>("FKDAT");
            }
            set
            {
                base.SetProperty("FKDAT", value);
            }
        }

        [DataMember]
        //总金额
        public decimal Amount
        {
            get
            {
                return base.GetProperty<decimal>("AMOUNT");
            }
            set
            {
                base.SetProperty("AMOUNT", value);
            }
        }

        [DataMember]
        //净价值 （不含税的金额）
        public decimal Netwr
        {
            get
            {
                return base.GetProperty<decimal>("NETWR");
            }
            set
            {
                base.SetProperty("NETWR", value);
            }
        }

        [DataMember]
        //税额
        public decimal Mwsbp
        {
            get
            {
                return base.GetProperty<decimal>("MWSBP");
            }
            set
            {
                base.SetProperty("MWSBP", value);
            }
        }

        [DataMember]
        //总折扣价
        public string DisValue
        {
            get
            {
                return base.GetProperty<string>("DIS_VALUE");
            }
            set
            {
                base.SetProperty("DIS_VALUE", value);
            }
        }

        [DataMember]
        //货币码 
        public string Waers
        {
            get
            {
                return base.GetProperty<string>("WAERS");
            }
            set
            {
                base.SetProperty("WAERS", value);
            }
        }

        [DataMember]
        //合计行 （计算该单行项目的条目数）
        public decimal TotalItem
        {
            get
            {
                return base.GetProperty<decimal>("TOTAL_ITEM");
            }
            set
            {
                base.SetProperty("TOTAL_ITEM", value);
            }
        }

        [DataMember]
        //备注
        public string Remark
        {
            get
            {
                return base.GetProperty<string>("RENARK");
            }
            set
            {
                base.SetProperty("RENARK", value);
            }
        }

    }
}


