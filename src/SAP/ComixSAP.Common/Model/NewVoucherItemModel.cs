using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common.SAP;

namespace ComixSAP.Common
{
    [DataContract]
    public class NewVoucherItemModel : SapModelBase
    {
        public override void SetFieldNames()
        {
            this.PropertyNames = new List<string> { 
                "BELNR","BSCHL","HKONT","WRBTR","KURSR","ZLSCH","KUNNR","LIFNR","ZTERM","MWSKZ","SGTXT","ZUONR","XREF1","XREF2","XREF3","KOSTL","PRCTR","ZFBDT","VALUT","XNEGP","RSTGR","GSBER","SPART","VKORG","VTWEG","KNDNR","WERKS","WW003","VBUND","ZZHKONT","ZZPOSID","ZZCHGTY","ZZINVES"};
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
        public string Bschl
        {
            get
            {
                return base.GetProperty<string>("BSCHL");
            }
            set
            {
                base.SetProperty("BSCHL", value);
            }
        }
        [DataMember]
        public string Hkont
        {
            get
            {
                return base.GetProperty<string>("HKONT");
            }
            set
            {
                base.SetProperty("HKONT", value);
            }
        }
        [DataMember]
        public string Wrbtr
        {
            get
            {
                return base.GetProperty<string>("WRBTR");
            }
            set
            {
                base.SetProperty("WRBTR", value);
            }
        }
        [DataMember]
        public string Kursr
        {
            get
            {
                return base.GetProperty<string>("KURSR");
            }
            set
            {
                base.SetProperty("KURSR", value);
            }
        }
        [DataMember]
        public string Zlsch
        {
            get
            {
                return base.GetProperty<string>("ZLSCH");
            }
            set
            {
                base.SetProperty("ZLSCH", value);
            }
        }
        [DataMember]
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
        public string Lifnr
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
        [DataMember]
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
        public string Mwskz
        {
            get
            {
                return base.GetProperty<string>("MWSKZ");
            }
            set
            {
                base.SetProperty("MWSKZ", value);
            }
        }
        [DataMember]
        public string Sgtxt
        {
            get
            {
                return base.GetProperty<string>("SGTXT");
            }
            set
            {
                base.SetProperty("SGTXT", value);
            }
        }
        [DataMember]
        public string Zuonr
        {
            get
            {
                return base.GetProperty<string>("ZUONR");
            }
            set
            {
                base.SetProperty("ZUONR", value);
            }
        }
        [DataMember]
        public string Xref1
        {
            get
            {
                return base.GetProperty<string>("XREF1");
            }
            set
            {
                base.SetProperty("XREF1", value);
            }
        }
        [DataMember]
        public string Xref2
        {
            get
            {
                return base.GetProperty<string>("XREF2");
            }
            set
            {
                base.SetProperty("XREF2", value);
            }
        }
        [DataMember]
        public string Xref3
        {
            get
            {
                return base.GetProperty<string>("XREF3");
            }
            set
            {
                base.SetProperty("XREF3", value);
            }
        }
        [DataMember]
        public string Kostl
        {
            get
            {
                return base.GetProperty<string>("KOSTL");
            }
            set
            {
                base.SetProperty("KOSTL", value);
            }
        }
        [DataMember]
        public string Prctr
        {
            get
            {
                return base.GetProperty<string>("PRCTR");
            }
            set
            {
                base.SetProperty("PRCTR", value);
            }
        }
        [DataMember]
        public string Zfbdt
        {
            get
            {
                return base.GetProperty<string>("ZFBDT");
            }
            set
            {
                base.SetProperty("ZFBDT", value);
            }
        }
        [DataMember]
        public string Valut
        {
            get
            {
                return base.GetProperty<string>("VALUT");
            }
            set
            {
                base.SetProperty("VALUT", value);
            }
        }
        [DataMember]
        public string Xnegp
        {
            get
            {
                return base.GetProperty<string>("XNEGP");
            }
            set
            {
                base.SetProperty("XNEGP", value);
            }
        }
        [DataMember]
        public string Rstgr
        {
            get
            {
                return base.GetProperty<string>("RSTGR");
            }
            set
            {
                base.SetProperty("RSTGR", value);
            }
        }
        [DataMember]
        public string Gsber
        {
            get
            {
                return base.GetProperty<string>("GSBER");
            }
            set
            {
                base.SetProperty("GSBER", value);
            }
        }
        [DataMember]
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
        public string Kndnr
        {
            get
            {
                return base.GetProperty<string>("KNDNR");
            }
            set
            {
                base.SetProperty("KNDNR", value);
            }
        }
        [DataMember]
        public string Werks
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
        public string Ww003
        {
            get
            {
                return base.GetProperty<string>("WW003");
            }
            set
            {
                base.SetProperty("WW003", value);
            }
        }
        [DataMember]
        public string Vbund
        {
            get
            {
                return base.GetProperty<string>("VBUND");
            }
            set
            {
                base.SetProperty("VBUND", value);
            }
        }
        [DataMember]
        public string Zzhkont
        {
            get
            {
                return base.GetProperty<string>("ZZHKONT");
            }
            set
            {
                base.SetProperty("ZZHKONT", value);
            }
        }
        [DataMember]
        public string Zzposid
        {
            get
            {
                return base.GetProperty<string>("ZZPOSID");
            }
            set
            {
                base.SetProperty("ZZPOSID", value);
            }
        }
        [DataMember]
        public string Zzchgty
        {
            get
            {
                return base.GetProperty<string>("ZZCHGTY");
            }
            set
            {
                base.SetProperty("ZZCHGTY", value);
            }
        }
        [DataMember]
        public string Zzinves
        {
            get
            {
                return base.GetProperty<string>("ZZINVES");
            }
            set
            {
                base.SetProperty("ZZINVES", value);
            }
        }
    }
}
