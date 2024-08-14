using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.COS.Model.ReqModels
{ 

    public class PacketListCosRoot
    {
        //暂时注释不需要
        public string groupId { get; set; }
        public string customerCode { get; set; }
        public List<Datum> data { get; set; }
    }

    public class Datum
    {
        public string customerSkuCode { get; set; }
        public string[] changeTypes { get; set; }
    }

    public class DataDatum
    {
        public string customerSkuCode { get; set; }
        public string[] changeTypes { get; set; }
        public string Oid { get; set; }
    }

}
