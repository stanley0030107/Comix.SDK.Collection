using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace ComixSAP.Common.SAP
{
    [DataContract]
    public class RFCStructParameter
    {
        [DataMember]
        public string PropertyName { get; set; }

        [DataMember]
        public string RfcStructName { get; set; }
    }
}

