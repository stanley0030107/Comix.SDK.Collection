using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common.SAP;
using ComixSAP.Common.Model;
using Furion.JsonSerialization;
using Newtonsoft.Json;

namespace ComixSAP.Common.Entity
{
    public class PostDeliveryOrderEntity : SapEntityBase
    {
        public PostDeliveryOrderEntity()
        {
            base.FuncName = "ZWMS_RETURN_DELIVERY";
        }

        public override void SetFieldNames()
        {
            this.PropertyNames = new SortedDictionary<string, RFCParamater>();
            RFCParamater paramater = new RFCParamater {
                ParaDirection = Direction.InPut
            };
            this.PropertyNames.Add("IW_DELIVERY", paramater);

            RFCParamater paramater1 = new RFCParamater
            {
                ParaDirection = Direction.OutPut
            };
            this.PropertyNames.Add("IT_RETURN", paramater1);
        }

        public override void SetTableNames()
        {
            this.RfcTableNames = new List<RFCTableParameter>();
            RFCTableParameter item = new RFCTableParameter {
                RfcTableName = "IW_DELIVERY",
                PropertyName = "DeliveryOrders"
            };
            this.RfcTableNames.Add(item);

            RFCTableParameter item1 = new RFCTableParameter
            {
                RfcTableName = "IT_RETURN",
                PropertyName = "Result"
            };
            this.RfcTableNames.Add(item1);
        }
        
        public List<ZWMSDeliveryOrderModel> DeliveryOrders
        {
            get
            {
                return JsonConvert.DeserializeObject<List<ZWMSDeliveryOrderModel>>(base.GetProperty<string>("IW_DELIVERY").ConvertNull());
            }
            set
            {
                base.SetProperty("IW_DELIVERY", JsonConvert.SerializeObject(value.ConvertToDataTable<ZWMSDeliveryOrderModel>()));
            }
        }

        [DataMember]
        public List<ZWMSReturnModel> Result
        {
            get
            {
                return JsonConvert.DeserializeObject<List<ZWMSReturnModel>>(base.GetProperty<string>("IT_RETURN").ConvertNull());
            }
            set
            {
                base.SetProperty("IT_RETURN", JsonConvert.SerializeObject(value.ConvertToDataTable<ZWMSReturnModel>()));
            }
        }
    }
}

