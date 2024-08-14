using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ComixSAP.Common.SAP
{
    public interface ISapModel
    {
        object PropertyList(string propertyName);

        [DataMember]
        List<string> PrimaryKeys { get; set; }

        [DataMember]
        List<string> PropertyNames { get; set; }

        [DataMember]
        Dictionary<string, string> PropertyRelation { get; set; }

        [DataMember]
        string TableName { get; set; }
    }
}

