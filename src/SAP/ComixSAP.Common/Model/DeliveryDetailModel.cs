using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using ComixSAP.Common.SAP;

namespace ComixSAP.Common.Model
{
    [DataContract]
    public class SAPDeliveryDetailModel : SapModelBase
    {
        public override void SetFieldNames()
        {
            this.PropertyNames = new List<string> { 
                "VGBEL", "VGPOS", "VBELN", "POSNR", "WERKS", "LGORT", "MATNR", "LFIMG", "MEINS", "VRKME", "UMVKZ", "UMVKN", "PIKMG", "NTGEW", "BRGEW", "GEWEI", 
                "VOLUM", "VOLEH", "XCHPF", "XCHAR", "CHARG", "UEPOS", "UPDKZ", "FAKSP"
             };
        }

        [DataMember]
        public string BaseUnit
        {
            get
            {
                return base.GetProperty<string>("MEINS");
            }
            set
            {
                base.SetProperty("MEINS", value, 3);
            }
        }

        [DataMember]
        public string DeliveryItemNo
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
        public string DeliveryNo
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
        public decimal DeliveryQuantity
        {
            get
            {
                return base.GetProperty<decimal>("LFIMG");
            }
            set
            {
                base.SetProperty("LFIMG", value);
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
        public decimal GloassWeight
        {
            get
            {
                return base.GetProperty<decimal>("BRGEW");
            }
            set
            {
                base.SetProperty("BRGEW", value);
            }
        }

        [DataMember]
        public string IsLock
        {
            get
            {
                return base.GetProperty<string>("FAKSP");
            }
            set
            {
                base.SetProperty("FAKSP", value, 3);
            }
        }

        [DataMember]
        public string IsModify
        {
            get
            {
                return base.GetProperty<string>("UPDKZ");
            }
            set
            {
                base.SetProperty("UPDKZ", value, 3);
            }
        }

        [DataMember]
        public string ItemNo
        {
            get
            {
                return base.GetProperty<string>("VGPOS");
            }
            set
            {
                base.SetProperty("VGPOS", value, 6);
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
        public string LotFlag
        {
            get
            {
                return base.GetProperty<string>("XCHAR");
            }
            set
            {
                base.SetProperty("XCHAR", value, 1);
            }
        }

        [DataMember]
        public string LotNo
        {
            get
            {
                return base.GetProperty<string>("CHARG");
            }
            set
            {
                base.SetProperty("CHARG", value, 10);
            }
        }

        [DataMember]
        public string LotRequireFlag
        {
            get
            {
                return base.GetProperty<string>("XCHPF");
            }
            set
            {
                base.SetProperty("XCHPF", value, 1);
            }
        }

        [DataMember]
        public decimal NetWeight
        {
            get
            {
                return base.GetProperty<decimal>("NTGEW");
            }
            set
            {
                base.SetProperty("NTGEW", value);
            }
        }

        [DataMember]
        public decimal PickingQuantity
        {
            get
            {
                return base.GetProperty<decimal>("PIKMG");
            }
            set
            {
                base.SetProperty("PIKMG", value);
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
        public string RefItemNo
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
        public string SalesUnit
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
        public string SAPBillNo
        {
            get
            {
                return base.GetProperty<string>("VGBEL");
            }
            set
            {
                base.SetProperty("VGBEL", value, 10);
            }
        }

        [DataMember]
        public decimal Traffic
        {
            get
            {
                return base.GetProperty<decimal>("VOLUM");
            }
            set
            {
                base.SetProperty("VOLUM", value);
            }
        }

        [DataMember]
        public string TrafficUnit
        {
            get
            {
                return base.GetProperty<string>("VOLEH");
            }
            set
            {
                base.SetProperty("VOLEH", value, 3);
            }
        }

        [DataMember]
        public decimal UnitConvDenominator
        {
            get
            {
                return base.GetProperty<decimal>("UMVKN");
            }
            set
            {
                base.SetProperty("UMVKN", value);
            }
        }

        [DataMember]
        public decimal UnitConvMolecular
        {
            get
            {
                return base.GetProperty<decimal>("UMVKZ");
            }
            set
            {
                base.SetProperty("UMVKZ", value);
            }
        }

        [DataMember]
        public string WeightUnit
        {
            get
            {
                return base.GetProperty<string>("GEWEI");
            }
            set
            {
                base.SetProperty("GEWEI", value, 3);
            }
        }
    }
}

