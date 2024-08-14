using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common;
using ComixSAP.Common.SAP;

namespace ComixSAP.Common.Model
{
    [DataContract]
    public class AutoVoucherModel : SapModelBase
    {
        public override void SetFieldNames()
        {
            this.PropertyNames = new List<string> { 
                "BUKRS", "KUNNR", "PAYMENTDATE", "PAYMENTAMOUNT", "PAYMENTNAME", "PAYMENTTYPE","PREFUND_FLAG","KUNNR_TO","ITEMTEXT", "ORDERNO","MESSAGEID","RACCT","FLAG","USERNAME","PAYMENTID"
                ,"BLART"
            };
        }

        [DataMember]
        public string CompanyCode
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
        public string EnterpriseCode
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
        public string AdjustEnterpriseCode
        {
            get
            {
                return base.GetProperty<string>("KUNNR_TO");
            }
            set
            {
                base.SetProperty("KUNNR_TO", value);
            }
        }

        [DataMember]
        public string PaymentDate
        {
            get
            {
                return base.GetProperty<string>("PAYMENTDATE");
            }
            set
            {
                base.SetProperty("PAYMENTDATE", value);
            }
        }

        [DataMember]
        public decimal PaymentAmount
        {
            get
            {
                return base.GetProperty<decimal>("PAYMENTAMOUNT");
            }
            set
            {
                base.SetProperty("PAYMENTAMOUNT", value);
            }
        }

        [DataMember]
        public string PaymentName
        {
            get
            {
                return base.GetProperty<string>("PAYMENTNAME");
            }
            set
            {
                base.SetProperty("PAYMENTNAME", value);
            }
        }

        [DataMember]
        public string PaymentType
        {
            get
            {
                return base.GetProperty<string>("PAYMENTTYPE");
            }
            set
            {
                base.SetProperty("PAYMENTTYPE", value);
            }
        }

        [DataMember]
        public string PrefundFlag
        {
            get
            {
                return base.GetProperty<string>("PREFUND_FLAG");
            }
            set
            {
                base.SetProperty("PREFUND_FLAG", value);
            }
        }

        [DataMember]
        public string ItemText
        {
            get
            {
                return base.GetProperty<string>("ITEMTEXT");
            }
            set
            {
                base.SetProperty("ITEMTEXT", value);
            }
        }

        [DataMember]
        public string OrderNo
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
        public string RAcct
        {
            get
            {
                return base.GetProperty<string>("RACCT");
            }
            set
            {
                base.SetProperty("RACCT", value);
            }
        }

        [DataMember]
        public string Flag
        {
            get
            {
                return base.GetProperty<string>("FLAG");
            }
            set
            {
                base.SetProperty("FLAG", value);
            }
        }
        [DataMember]
        public string UserName
        {
            get
            {
                return base.GetProperty<string>("USERNAME");
            }
            set
            {
                base.SetProperty("USERNAME", value);
            }
        }
        [DataMember]
        public string PaymentID
        {
            get
            {
                return base.GetProperty<string>("PAYMENTID");
            }
            set
            {
                base.SetProperty("PAYMENTID", value);
            }
        }
        [DataMember]
        public string PayPurpose
        {
            get
            {
                return base.GetProperty<string>("BLART");
            }
            set
            {
                base.SetProperty("BLART", value);
            }
        }
    }
}

