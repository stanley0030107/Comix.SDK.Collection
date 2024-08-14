using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace ComixSAP.Common.SAP
{
    [DataContract]
    public class RFCValueRelationModel
    {
        [DataMember]
        public string FuncName { get; set; }

        [DataMember]
        public string Remark { get; set; }

        [DataMember]
        public string TableName { get; set; }

        [DataMember]
        public string ValueCode { get; set; }

        [DataMember]
        public string ValueCode2 { get; set; }
    }
}

