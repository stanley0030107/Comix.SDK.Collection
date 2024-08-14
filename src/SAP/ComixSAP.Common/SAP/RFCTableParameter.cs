using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace ComixSAP.Common.SAP
{
    [DataContract]
    public class RFCTableParameter
    {
        [DataMember]
        public string PropertyName { get; set; }

        [DataMember]
        public string RfcTableName { get; set; }
    }
}

