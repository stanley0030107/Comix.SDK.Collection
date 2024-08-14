using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common;
using ComixSAP.Common.SAP;

namespace ComixSAP.Common.Model
{
    [DataContract]
    public class GetInvoiceReturnHeadModel : SapModelBase
    {
        public override void SetFieldNames()
        {
            this.PropertyNames = new List<string> { 
           "KUNNR","KUNNR_NAME","KUNRG","KUNRG_NAME","KUNRE","KUNRE_NAME","VBELN","VKORG","VTWEG","BUKRS","FKDAT","AMOUNT","WAERS","TDLINE","SFAKN"};
        }

        [DataMember]
        //售达方
        public string Soldtocode
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
        //售达方名称
        public string Soldtoname
        {
            get
            {
                return base.GetProperty<string>("KUNNR_NAME");
            }
            set
            {
                base.SetProperty("KUNNR_NAME", value);
            }
        }

        [DataMember]
        //付款方
        public string Paymentcode
        {
            get
            {
                return base.GetProperty<string>("KUNRG");
            }
            set
            {
                base.SetProperty("KUNRG", value);
            }
        }

        [DataMember]
        //付款方名称
        public string Paymentname
        {
            get
            {
                return base.GetProperty<string>("KUNRG_NAME");
            }
            set
            {
                base.SetProperty("KUNRG_NAME", value);
            }
        }

        [DataMember]
        //收票方
        public string Receivedinvoicecode
        {
            get
            {
                return base.GetProperty<string>("KUNRE");
            }
            set
            {
                base.SetProperty("KUNRE", value);
            }
        }

        [DataMember]
        //收票方名称
        public string Receivedinvoicename
        {
            get
            {
                return base.GetProperty<string>("KUNRE_NAME");
            }
            set
            {
                base.SetProperty("KUNRE_NAME", value);
            }
        }

        [DataMember]
        //发票编号
        public string Invoicecode
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
        //销售组织
        public string Salesorgcode
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
        public string Distchannelcode
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
        //公司代码
        public string Companycode
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
        //发票日期
        public DateTime Invoicedate
        {
            get
            {
                return base.GetProperty<DateTime>("FKDAT");
            }
            set
            {
                base.SetProperty("FKDAT", value);
            }
        }

        [DataMember]
        //发票金额
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
        //货币码
        public string Currency
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
        //备注
        public string Remark
        {
            get
            {
                return base.GetProperty<string>("TDLINE");
            }
            set
            {
                base.SetProperty("TDLINE", value);
            }
        }

        [DataMember]
        //已取消的出具发票凭证编号
        public string Vouchercode
        {
            get
            {
                return base.GetProperty<string>("SFAKN");
            }
            set
            {
                base.SetProperty("SFAKN", value);
            }
        }

    }
}


