using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common;
using ComixSAP.Common.SAP;

namespace ComixSAP.Common.Model
{
    [DataContract]
    public class SalesOrderHeadModel : SapModelBase
    {
        //2016-12-16
        //新增订单员信息 
        //ERNAM
        public override void SetFieldNames()
        {
            this.PropertyNames = new List<string> { 
                "VBELN", "AUART", "VKORG", "VTWEG", "SPART", "VKBUR", "VKGRP", "BSTNK", "BSTDK", "KUNNR", "KUNWE",
                "ZTERM", "AUDAT", "PRSDT", "GWLDT", "KNUMA_AG", 
                "AUGRU", "NOPRO", "DRPNO", "BNAME", "IHREZ", "HEADER_TEXT","KBETR_HB00",
                "KBETR_ZDS1","FLAG_HB00","FLAG_ZDS1","VBBK_004","KBETR_HD01","FLAG_HD01",
                "ERNAM","PLTYP","VBBK_005","ZMODEL","ZPROJECT1","ZPROJECT2","LIFNR","KUNRE","KUNRG"
             };
            //,"VBBK_005"
        }
        //20160708修改合约订单 新增付款方和发票接收方
        //新增发票收取方和付款方 
        //仅对合约订单有效
        /// <summary>
        /// 收取发票方
        /// </summary>
        [DataMember]
        public string InvoiceDeliveryCode
        {
            get
            {
                return base.GetProperty<string>("KUNRE");
            }
            set
            {
                base.SetProperty("KUNRE", value, 10);
            }
        }

        /// <summary>
        /// 付款方
        /// </summary>
        [DataMember]
        public string CustPaymentCode
        {
            get
            {
                return base.GetProperty<string>("KUNRG");
            }
            set
            {
                base.SetProperty("KUNRG", value, 10);
            }
        }


        [DataMember]
        public string OrderOperatorName
        {
            get
            {
                return base.GetProperty<string>("ERNAM");
            }
            set
            {
                base.SetProperty("ERNAM", value,12);
            }
        }

        [DataMember]
        public string IsFreeDelivery
        {
            get
            {
                return base.GetProperty<string>("VBBK_004");
            }
            set
            {
                base.SetProperty("VBBK_004", value);
            }
        }

        [DataMember]
        public string DiscountPercentFlag
        {
            get
            {
                return base.GetProperty<string>("FLAG_ZDS1");
            }
            set
            {
                base.SetProperty("FLAG_ZDS1", value);
            }
        }

        [DataMember]
        public string DiscountAmountFlag
        {
            get
            {
                return base.GetProperty<string>("FLAG_HB00");
            }
            set
            {
                base.SetProperty("FLAG_HB00", value);
            }
        }

        [DataMember]
        public decimal DiscountAmount
        {
            get
            {
                return base.GetProperty<decimal>("KBETR_HB00");
            }
            set
            {
                base.SetProperty("KBETR_HB00", value);
            }
        }

        [DataMember]
        public decimal DiscountPercent
        {
            get
            {
                return base.GetProperty<decimal>("KBETR_ZDS1");
            }
            set
            {
                base.SetProperty("KBETR_ZDS1", value);
            }
        }


        [DataMember]
        public string BillDate
        {
            get
            {
                return base.GetProperty<string>("AUDAT");
            }
            set
            {
                base.SetProperty("AUDAT", value, 8);
            }
        }

        [DataMember]
        public string BillNo
        {
            get
            {
                return base.GetProperty<string>("DRPNO");
            }
            set
            {
                base.SetProperty("DRPNO", value, 20);
            }
        }

        [DataMember]
        public string BillReason
        {
            get
            {
                return base.GetProperty<string>("AUGRU");
            }
            set
            {
                base.SetProperty("AUGRU", value, 3);
            }
        }

        [DataMember]
        public string ChannelCode
        {
            get
            {
                return base.GetProperty<string>("VTWEG");
            }
            set
            {
                base.SetProperty("VTWEG", value, 2);
            }
        }

        [DataMember]
        public string DistSchemeCode
        {
            get
            {
                return base.GetProperty<string>("KNUMA_AG");
            }
            set
            {
                base.SetProperty("KNUMA_AG", value, 10);
            }
        }

        [DataMember]
        public string IsPromotion
        {
            get
            {
                return base.GetProperty<string>("NOPRO");
            }
            set
            {
                base.SetProperty("NOPRO", value, 1);
            }
        }

        [DataMember]
        public string Name
        {
            get
            {
                return base.GetProperty<string>("BNAME");
            }
            set
            {
                base.SetProperty("BNAME", value, 0x23);
            }
        }

        [DataMember]
        public string OrderType
        {
            get
            {
                return base.GetProperty<string>("AUART");
            }
            set
            {
                base.SetProperty("AUART", value, 4);
            }
        }

        [DataMember]
        public string PaymentCode
        {
            get
            {
                return base.GetProperty<string>("ZTERM");
            }
            set
            {
                base.SetProperty("ZTERM", value, 10);
            }
        }

        [DataMember]
        public string PriceFixDate
        {
            get
            {
                return base.GetProperty<string>("PRSDT");
            }
            set
            {
                base.SetProperty("PRSDT", value, 8);
            }
        }

        [DataMember]
        public string ProdGroup
        {
            get
            {
                return base.GetProperty<string>("SPART");
            }
            set
            {
                base.SetProperty("SPART", value, 2);
            }
        }

        [DataMember]
        public string PurchaseBillDate
        {
            get
            {
                return base.GetProperty<string>("BSTDK");
            }
            set
            {
                base.SetProperty("BSTDK", value, 8);
            }
        }

        [DataMember]
        public string PurchaseNo
        {
            get
            {
                return base.GetProperty<string>("BSTNK");
            }
            set
            {
                base.SetProperty("BSTNK", value, 0x23);
            }
        }

        [DataMember]
        public string RefRemark
        {
            get
            {
                return base.GetProperty<string>("IHREZ");
            }
            set
            {
                base.SetProperty("IHREZ", value, 12);
            }
        }

        [DataMember]
        public string Remark
        {
            get
            {
                return base.GetProperty<string>("HEADER_TEXT");
            }
            set
            {
                base.SetProperty("HEADER_TEXT", value, 200);
            }
        }

        //VBBK_005
        [DataMember]
        public string AddressRemark
        {
            get
            {
                return base.GetProperty<string>("VBBK_005");
            }
            set
            {
                base.SetProperty("VBBK_005", value, 200);
            }
        }


        [DataMember]
        public string SalesDept
        {
            get
            {
                return base.GetProperty<string>("VKBUR");
            }
            set
            {
                base.SetProperty("VKBUR", value, 4);
            }
        }

        [DataMember]
        public string SalesGroup
        {
            get
            {
                return base.GetProperty<string>("VKGRP");
            }
            set
            {
                base.SetProperty("VKGRP", value, 3);
            }
        }

        [DataMember]
        public string SalesOrg
        {
            get
            {
                return base.GetProperty<string>("VKORG");
            }
            set
            {
                base.SetProperty("VKORG", value, 4);
            }
        }

        [DataMember]
        public string SAPBillNo
        {
            get
            {
                return base.GetProperty<string>("VBELN");
            }
            set
            {
                base.SetProperty("VBELN", value, 10);
            }
        }

        [DataMember]
        public string SendCustCode
        {
            get
            {
                return base.GetProperty<string>("KUNWE");
            }
            set
            {
                base.SetProperty("KUNWE", value, 10);
            }
        }

        [DataMember]
        public string SoldCustCode
        {
            get
            {
                return base.GetProperty<string>("KUNNR");
            }
            set
            {
                base.SetProperty("KUNNR", value, 10);
            }
        }

        [DataMember]
        public string WarrantDate
        {
            get
            {
                return base.GetProperty<string>("GWLDT");
            }
            set
            {
                base.SetProperty("GWLDT", value, 8);
            }
        }
        [DataMember]
        public decimal Freight
        {
            get
            {
                return base.GetProperty<decimal>("KBETR_HD01");
            }
            set
            {
                base.SetProperty("KBETR_HD01", value);
            }
        }
        [DataMember]
        public string FreightFlag
        {
            get
            {
                return base.GetProperty<string>("FLAG_HD01");
            }
            set
            {
                base.SetProperty("FLAG_HD01", value);
            }
        }
        [DataMember]
        public string PLTYP
        {
            get
            {
                return base.GetProperty<string>("PLTYP");
            }
            set
            {
                base.SetProperty("PLTYP", value);
            }
        }
        /// <summary>
        /// 经营模式
        /// </summary>
        [DataMember]
        public string BussinessModel
        {
            get
            {
                return base.GetProperty<string>("ZMODEL");
            }
            set
            {
                base.SetProperty("ZMODEL", value);
            }
        }
        /// <summary>
        /// 合同1
        /// </summary>
        [DataMember]
        public string ZPROJECT1
        {
            get
            {
                return base.GetProperty<string>("ZPROJECT1");
            }
            set
            {
                base.SetProperty("ZPROJECT1", value);
            }
        }
        /// <summary>
        /// 合同2
        /// </summary>
        [DataMember]
        public string ZPROJECT2
        {
            get
            {
                return base.GetProperty<string>("ZPROJECT2");
            }
            set
            {
                base.SetProperty("ZPROJECT2", value);
            }
        }
        /// <summary>
        /// 合同2
        /// </summary>
        [DataMember]
        public string DistributeCode
        {
            get
            {
                return base.GetProperty<string>("LIFNR");
            }
            set
            {
                base.SetProperty("LIFNR", value);
            }
        }

       
    }
}

