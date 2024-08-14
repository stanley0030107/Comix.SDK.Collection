using System;
using System.Runtime.Serialization;

namespace ComixSAP.Common.SAP
{
    [DataContract]
    public enum Direction
    {
        [EnumMember]
        Dual = 3,
        [EnumMember]
        InPut = 1,
        [EnumMember]
        OutPut = 2
    }
}

