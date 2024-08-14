using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ComixSAP.Common.SAP
{
    public interface ISapEntity
    {
        object PropertyList(string propertyName);

        [DataMember]
        string FuncName { get; set; }

        [DataMember]
        SortedDictionary<string, RFCParamater> PropertyNames { get; }

        [DataMember]
        List<RFCStructParameter> RfcStructNames { get; }

        [DataMember]
        List<RFCTableParameter> RfcTableNames { get; }
    }
}

