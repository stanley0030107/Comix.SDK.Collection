using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common;
using ComixSAP.Common.SAP;

namespace ComixSAP.Common.Model
{
    [DataContract]
    public class GetFBL5NInputModel : SapModelBase
    {
        public override void SetFieldNames()
        {
            this.PropertyNames = new List<string> { 
           "VTWEG","BUKRS","HKONT"};
        }

        [DataMember]
        //客户编码
        public string distChannleCode
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
        public string companyCode
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
        //总分类帐帐目
        public string HKONT
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

    }
}


