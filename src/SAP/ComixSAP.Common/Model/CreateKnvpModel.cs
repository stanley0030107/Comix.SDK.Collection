using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common;
using ComixSAP.Common.SAP;

namespace ComixSAP.Common.Model
{
    [DataContract]
    public class CreateKnvpModel : SapModelBase
    {
        public override void SetFieldNames()
        {
            this.PropertyNames = new List<string> { 
           "PARVW","KUNN2"};
        }

        [DataMember]
        //合作伙伴功能
        public string Parvw
        {
            get
            {
                return base.GetProperty<string>("PARVW");
            }
            set
            {
                base.SetProperty("PARVW", value);
            }
        }

        [DataMember]
        //送达方编号
        public string Kunn2
        {
            get
            {
                return base.GetProperty<string>("KUNN2");
            }
            set
            {
                base.SetProperty("KUNN2", value);
            }
        }

    }
}


