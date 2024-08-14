using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common;
using ComixSAP.Common.SAP;

namespace ComixSAP.Common.Model
{
    [DataContract]
    public class GetInvoiceInputModel : SapModelBase
    {
        public override void SetFieldNames()
        {
            this.PropertyNames = new List<string> { 
           "BUKRS","VTWEG"};
        }

        [DataMember]
        //公司代码
        public string SalesOrgCode
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
        //分销渠道
        public string DistChannelCode
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

    }
}


