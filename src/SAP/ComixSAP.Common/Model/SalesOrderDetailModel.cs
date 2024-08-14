using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common;
using ComixSAP.Common.SAP;

namespace ComixSAP.Common.Model
{

    [DataContract]
    public class SalesOrderDetailModel : SapModelBase
    {
        public override void SetFieldNames()
        {
            this.PropertyNames = new List<string> { 
                "POSNR", "WERKS", "LGORT", "MATNR", "KBETR_ZPR4", "FLAG_ZPR4", "KBETR_ZTS1", "FLAG_ZTS1", "KWMENG", "VRKME", "BMENG", "ZTERM", "EDATU", "PSTYV", "CHGID", "UEPOS", 
                "PRSDT", "ABGRU", "SPART", "ITEM_TEXT", "BDDAT", "FREE", "MWSBP", "NETWR","KBETR_ZPR5","FLAG_ZPR5",
                "KWERT_K004","FLAG_K004","FLAG_ZTS2","KBETR_ZTS2","PLTYP","VALID_DATE","QXB_K007","FLAG_K007","YHQ_K006","FLAG_K006","BANFN","TAXM1"

             };
        }

        /// <summary>
        /// 采购申请编号
        /// </summary>
        [DataMember]
        public string PurchaseApplyCode
        {
            get { return GetProperty<string>("BANFN"); }
            set { SetProperty("BANFN", value); }
        }

        /// <summary>
        /// 行优惠券
        /// </summary>
        [DataMember]
        public decimal YhCouponAmount
        {
            get { return GetProperty<decimal>("YHQ_K006"); }
            set { SetProperty("YHQ_K006", value); }
        }

        /// <summary>
        /// 行优惠券标记
        /// </summary>
        [DataMember]
        public string YhCouponFlag
        {
            get
            {
                return GetProperty<string>("FLAG_K006");
            }
            set
            {
                SetProperty("FLAG_K006", value, 1);
            }
        }

        /// <summary>
        /// 齐心币
        /// </summary>
        [DataMember]
        public decimal QxCoinAmount
        {
            get { return GetProperty<decimal>("QXB_K007"); }
            set { SetProperty("QXB_K007", value); }
        }

        /// <summary>
        /// 齐心币标记
        /// </summary>
        [DataMember]
        public string QxCoinFlag
        {
            get
            {
                return GetProperty<string>("FLAG_K007");
            }
            set
            {
                SetProperty("FLAG_K007", value, 1);
            }
        }


        /// <summary>
        /// 是否传递行项目折扣额
        /// </summary>
        [DataMember]
        public string ItemDiscountAmountFlag
        {
            get
            {
                return base.GetProperty<string>("FLAG_K004");
            }
            set
            {
                base.SetProperty("FLAG_K004", value);
            }
        }

        /// <summary>
        /// 行项目折扣额
        /// </summary>
        [DataMember]
        public decimal ItemDiscountAmount
        {
            get
            {
                return base.GetProperty<decimal>("KWERT_K004");
            }
            set
            {
                base.SetProperty("KWERT_K004", value);
            }
        }

        /// <summary>
        /// 标记当前行项目的活动价格
        /// </summary>
        [DataMember]
        public decimal SpecialOrderPrice
        {
            get
            {
                return base.GetProperty<decimal>("KBETR_ZPR5");
            }
            set
            {
                base.SetProperty("KBETR_ZPR5", value);
            }
        }

        /// <summary>
        /// 标记当前行项目是否参加活动(包括秒杀单,和行项目满减活动)
        /// </summary>
        [DataMember]
        public string IsSpecialOrder
        {
            get
            {
                return base.GetProperty<string>("FLAG_ZPR5");
            }
            set
            {
                base.SetProperty("FLAG_ZPR5", value);
            }
        }
        //Evan 2017/02/22
        //阶梯折扣Flag
        [DataMember]
        public string ZTS2Flag
        {
            get
            {
                return base.GetProperty<string>("FLAG_ZTS2");
            }
            set
            {
                base.SetProperty("FLAG_ZTS2", value);
            }
        }
        //Evan 2017/02/22
        //阶梯折扣值
        [DataMember]
        public decimal ZTS2Value
        {
            get
            {
                return base.GetProperty<decimal>("KBETR_ZTS2");
            }
            set
            {
                base.SetProperty("KBETR_ZTS2", value);
            }
        }

        [DataMember]
        public decimal ConfirmQuantity
        {
            get
            {
                return base.GetProperty<decimal>("BMENG");
            }
            set
            {
                base.SetProperty("BMENG", value);
            }
        }

        [DataMember]
        public string FactoryName
        {
            get
            {
                return base.GetProperty<string>("WERKS");
            }
            set
            {
                base.SetProperty("WERKS", value, 4);
            }
        }

        [DataMember]
        public string IsFree
        {
            get
            {
                return base.GetProperty<string>("FREE");
            }
            set
            {
                base.SetProperty("FREE", value, 1);
            }
        }

        [DataMember]
        public string IsModify
        {
            get
            {
                return base.GetProperty<string>("CHGID");
            }
            set
            {
                base.SetProperty("CHGID", value, 1);
            }
        }

        [DataMember]
        public string ItemNo
        {
            get
            {
                return base.GetProperty<string>("POSNR");
            }
            set
            {
                base.SetProperty("POSNR", value, 6);
            }
        }

        [DataMember]
        public string Location
        {
            get
            {
                return base.GetProperty<string>("LGORT");
            }
            set
            {
                base.SetProperty("LGORT", value, 4);
            }
        }

        [DataMember]
        public decimal NoIncludeTaxAmount
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
        public string ParentItemNo
        {
            get
            {
                return base.GetProperty<string>("UEPOS");
            }
            set
            {
                base.SetProperty("UEPOS", value, 6);
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
                base.SetProperty("ZTERM", value, 4);
            }
        }

        [DataMember]
        public decimal Price
        {
            get
            {
                return base.GetProperty<decimal>("KBETR_ZPR4");
            }
            set
            {
                base.SetProperty("KBETR_ZPR4", value);
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
        public string PriceFlag
        {
            get
            {
                return base.GetProperty<string>("FLAG_ZPR4");
            }
            set
            {
                base.SetProperty("FLAG_ZPR4", value, 1);
            }
        }

        [DataMember]
        public string ProdCode
        {
            get
            {
                return base.GetProperty<string>("MATNR");
            }
            set
            {
                base.SetProperty("MATNR", value, 0x12);
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
        public decimal Quantity
        {
            get
            {
                return base.GetProperty<decimal>("KWMENG");
            }
            set
            {
                base.SetProperty("KWMENG", value);
            }
        }

        [DataMember]
        public string RejectReason
        {
            get
            {
                return base.GetProperty<string>("ABGRU");
            }
            set
            {
                base.SetProperty("ABGRU", value, 2);
            }
        }

        [DataMember]
        public string Remark
        {
            get
            {
                return base.GetProperty<string>("ITEM_TEXT");
            }
            set
            {
                base.SetProperty("ITEM_TEXT", value, 200);
            }
        }

        [DataMember]
        public string ScheduleConfirmDate
        {
            get
            {
                return base.GetProperty<string>("BDDAT");
            }
            set
            {
                base.SetProperty("BDDAT", value, 8);
            }
        }

        [DataMember]
        public string ScheduleDeliveryDate
        {
            get
            {
                return base.GetProperty<string>("EDATU");
            }
            set
            {
                base.SetProperty("EDATU", value, 8);
            }
        }

        [DataMember]
        public decimal SpecialPrice
        {
            get
            {
                return base.GetProperty<decimal>("KBETR_ZTS1");
            }
            set
            {
                base.SetProperty("KBETR_ZTS1", value);
            }
        }

        [DataMember]
        public string SpecialPriceFlag
        {
            get
            {
                return base.GetProperty<string>("FLAG_ZTS1");
            }
            set
            {
                base.SetProperty("FLAG_ZTS1", value, 1);
            }
        }

        [DataMember]
        public decimal TaxAmount
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
        public string Unit
        {
            get
            {
                return base.GetProperty<string>("VRKME");
            }
            set
            {
                base.SetProperty("VRKME", value, 3);
            }
        }

        [DataMember]
        public string VoucherType
        {
            get
            {
                return base.GetProperty<string>("PSTYV");
            }
            set
            {
                base.SetProperty("PSTYV", value, 4);
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

        [DataMember]
        public string ValidDays
        {
            get
            {
                return base.GetProperty<string>("VALID_DATE");
            }
            set
            {
                base.SetProperty("VALID_DATE", value);
            }
        }

        /// <summary>
        /// 税率
        /// </summary>
        [DataMember]
        public string TaxRate
        {
            get
            {
                return base.GetProperty<string>("TAXM1");
            }
            set
            {
                base.SetProperty("TAXM1", value, 10);
            }
        }
    }
}

