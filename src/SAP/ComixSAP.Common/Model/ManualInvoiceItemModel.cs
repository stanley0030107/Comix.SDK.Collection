using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common;
using ComixSAP.Common.SAP;

namespace ComixSAP.Common.Model
{
    [DataContract]
    public class ManualInvoiceItemModel : SapModelBase
    {
        public override void SetFieldNames()
        {
            this.PropertyNames = new List<string> { 
           "ORDERNO","POSNR","MATNR","MAKTX","UNIT","PACKING_SIZE","SALES_QTY","AMOUNT","NETWR","MWSBP","DISCOUNT_AMOUNT","DISCOUNT_TAX_AMT","RATE"};
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
        //行项目
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
        //物料号 （商城订单号的物料编码）
        public string Matnr
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
        //物料描述（短文本） 
        public string Maktx
        {
            get
            {
                return base.GetProperty<string>("MAKTX");
            }
            set
            {
                base.SetProperty("MAKTX", value);
            }
        }

        [DataMember]
        //计量单位
        public string Unit
        {
            get
            {
                return base.GetProperty<string>("UNIT");
            }
            set
            {
                base.SetProperty("UNIT", value);
            }
        }

        [DataMember]
        //规格
        public string PackingSize
        {
            get
            {
                return base.GetProperty<string>("PACKING_SIZE");
            }
            set
            {
                base.SetProperty("PACKING_SIZE", value);
            }
        }

        [DataMember]
        //数量
        public decimal SalesQty
        {
            get
            {
                return base.GetProperty<decimal>("SALES_QTY");
            }
            set
            {
                base.SetProperty("SALES_QTY", value);
            }
        }

        [DataMember]
        //含税金额
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
        //净值
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
        //折扣金额
        public decimal DiscountAmount
        {
            get
            {
                return base.GetProperty<decimal>("DISCOUNT_AMOUNT");
            }
            set
            {
                base.SetProperty("DISCOUNT_AMOUNT", value);
            }
        }

        [DataMember]
        //折扣税额
        public decimal DiscountTaxAmt
        {
            get
            {
                return base.GetProperty<decimal>("DISCOUNT_TAX_AMT");
            }
            set
            {
                base.SetProperty("DISCOUNT_TAX_AMT", value);
            }
        }

        [DataMember]
        //税率
        public decimal Rate
        {
            get
            {
                return base.GetProperty<decimal>("RATE");
            }
            set
            {
                base.SetProperty("RATE", value);
            }
        }

    }
}


