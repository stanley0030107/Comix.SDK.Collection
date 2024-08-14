using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using ComixSAP.Common.SAP;

namespace ComixSAP.Common.Model
{
    [DataContract]
    public class MessageModel : SapModelBase
    {
        public override void SetFieldNames()
        {
            this.PropertyNames = new List<string> { "MESSAGE" };
        }

        [DataMember]
        public string Message
        {
            get
            {
                return base.GetProperty<string>("MESSAGE");
            }
            set
            {
                base.SetProperty("MESSAGE", value, 220);
            }
        }
    }
}

