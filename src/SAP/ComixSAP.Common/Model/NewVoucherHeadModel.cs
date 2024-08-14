using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common.SAP;
 
namespace ComixSAP.Common
{
    [DataContract]
    public class NewVoucherHeadModel : SapModelBase
    {
        public override void SetFieldNames()
        {
            this.PropertyNames = new List<string> { 
                "BELNR","BUKRS","BLART","WAERS","KURSF","BLDAT","BUDAT","GJAHR","MONAT","BKTXT","XBLNR","ORDERNO","MESSAGEID","USERNAME"};
        }

        [DataMember]
        public string Belnr
        {
            get
            {
                return base.GetProperty<string>("BELNR");
            }
            set
            {
                base.SetProperty("BELNR", value);
            }
        }

        [DataMember]
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
        public string Blart
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

        [DataMember]
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
        public decimal Kursf
        {
            get
            {
                return base.GetProperty<decimal>("KURSF");
            }
            set
            {
                base.SetProperty("KURSF", value);
            }
        }

        [DataMember]
        public string Bldat
        {
            get
            {
                return base.GetProperty<string>("BLDAT");
            }
            set
            {
                base.SetProperty("BLDAT", value);
            }
        }

        [DataMember]
        public string Budat
        {
            get
            {
                return base.GetProperty<string>("BUDAT");
            }
            set
            {
                base.SetProperty("BUDAT", value);
            }
        }

        [DataMember]
        public decimal Gjahr
        {
            get
            {
                return base.GetProperty<decimal>("GJAHR");
            }
            set
            {
                base.SetProperty("GJAHR", value);
            }
        }

        [DataMember]
        public decimal Monat
        {
            get
            {
                return base.GetProperty<decimal>("MONAT");
            }
            set
            {
                base.SetProperty("MONAT", value);
            }
        }

        [DataMember]
        public string Bktxt
        {
            get
            {
                return base.GetProperty<string>("BKTXT");
            }
            set
            {
                base.SetProperty("BKTXT", value);
            }
        }

        [DataMember]
        public string Xblnr
        {
            get
            {
                return base.GetProperty<string>("XBLNR");
            }
            set
            {
                base.SetProperty("XBLNR", value);
            }
        }

        [DataMember]
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
        public string Messageid
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
    }
}
