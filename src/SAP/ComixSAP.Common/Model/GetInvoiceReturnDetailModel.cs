using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common;
using ComixSAP.Common.SAP;

namespace ComixSAP.Common.Model
{
    [DataContract]
    public class GetInvoiceReturnDetailModel : SapModelBase
    {
        public override void SetFieldNames()
        {
            this.PropertyNames = new List<string> { 
           "VBELN","POSNR","MATNR","MAKTX","MEINS","VRKME","FKLMG","FKIMG","AMOUNT","KURRF","PRICE","COST_PRICE","AMOUNT_CNY","WERKS"};

        }
        [DataMember]
        //发票编码
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
        //行项目号
        public string Itemno
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
        //物料编码
        public string Productcode
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
        //物料名称
        public string Productname
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
        //基本单位
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
        //销售单位
        public string Salesunit
        {
            get
            {
                return base.GetProperty<string>("VRKME");
            }
            set
            {
                base.SetProperty("VRKME", value);
            }
        }

        [DataMember]
        //基本单位数量
        public decimal Baseunitqty
        {
            get
            {
                return base.GetProperty<decimal>("FKLMG");
            }
            set
            {
                base.SetProperty("FKLMG", value);
            }
        }

        [DataMember]
        //销售单位数量
        public decimal Salesunitqty
        {
            get
            {
                return base.GetProperty<decimal>("FKIMG");
            }
            set
            {
                base.SetProperty("FKIMG", value);
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
        //税率
        public decimal Taxrate
        {
            get
            {
                return base.GetProperty<decimal>("KURRF");
            }
            set
            {
                base.SetProperty("KURRF", value);
            }
        }

        [DataMember]
        //单价
        public decimal Price
        {
            get
            {
                return base.GetProperty<decimal>("PRICE");
            }
            set
            {
                base.SetProperty("PRICE", value);
            }
        }

        [DataMember]
        //成本价
        public decimal Costprice
        {
            get
            {
                return base.GetProperty<decimal>("COST_PRICE");
            }
            set
            {
                base.SetProperty("COST_PRICE", value);
            }
        }
        [DataMember]
        //成本价
        public decimal AmountCny
        {
            get
            {
                return base.GetProperty<decimal>("AMOUNT_CNY");
            }
            set
            {
                base.SetProperty("AMOUNT_CNY", value);
            }
        }

        [DataMember]
        //工厂
        public string FactoryCode
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
        
    }
}


