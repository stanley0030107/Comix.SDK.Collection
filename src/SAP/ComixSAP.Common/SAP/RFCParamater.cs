using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace ComixSAP.Common.SAP
{
    [DataContract]
    public class RFCParamater
    {
        public RFCParamater()
        {
            this.ParaDirection = Direction.InPut;
        }

        [DataMember]
        public Direction ParaDirection { get; set; }
    }
}

