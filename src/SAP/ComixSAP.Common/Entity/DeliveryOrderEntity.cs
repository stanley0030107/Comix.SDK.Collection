using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common.SAP;
using ComixSAP.Common.Model;
using Furion.JsonSerialization;
using Newtonsoft.Json;

namespace ComixSAP.Common.Entity
{
    [DataContract]
    public class DeliveryOrderEntity : SapEntityBase
    {
        public DeliveryOrderEntity()
        {
            base.FuncName = "ZDRP_CREATE_DELIVERY";
        }

        public override void SetFieldNames()
        {
            this.PropertyNames = new SortedDictionary<string, RFCParamater>();
            RFCParamater paramater = new RFCParamater {
                ParaDirection = Direction.InPut
            };
            this.PropertyNames.Add("IW_LIKP", paramater);
            RFCParamater paramater2 = new RFCParamater {
                ParaDirection = Direction.InPut
            };
            this.PropertyNames.Add("IT_LIPS", paramater2);
            RFCParamater paramater3 = new RFCParamater {
                ParaDirection = Direction.OutPut
            };
            this.PropertyNames.Add("EW_LIKP", paramater3);
            RFCParamater paramater4 = new RFCParamater {
                ParaDirection = Direction.OutPut
            };
            this.PropertyNames.Add("ET_LIPS", paramater4);
            RFCParamater paramater5 = new RFCParamater {
                ParaDirection = Direction.OutPut
            };
            this.PropertyNames.Add("EV_TYPE", paramater5);
            RFCParamater paramater6 = new RFCParamater {
                ParaDirection = Direction.OutPut
            };
            this.PropertyNames.Add("EV_GOODS_ISSUE", paramater6);
            RFCParamater paramater7 = new RFCParamater {
                ParaDirection = Direction.OutPut
            };
            this.PropertyNames.Add("EV_CREDIT", paramater7);
            RFCParamater paramater8 = new RFCParamater {
                ParaDirection = Direction.OutPut
            };
            this.PropertyNames.Add("EV_DELIVERY", paramater8);
            RFCParamater paramater9 = new RFCParamater {
                ParaDirection = Direction.OutPut
            };
            this.PropertyNames.Add("ET_RETURN", paramater9);
            RFCParamater paramater10 = new RFCParamater {
                ParaDirection = Direction.OutPut
            };
            this.PropertyNames.Add("EV_CREDIT_TEXT", paramater10);
        }

        public override void SetStructNames()
        {
            this.RfcStructNames = new List<RFCStructParameter>();
            RFCStructParameter item = new RFCStructParameter {
                RfcStructName = "IW_LIKP",
                PropertyName = "DeliveryOrderHeadImport"
            };
            this.RfcStructNames.Add(item);
            RFCStructParameter parameter2 = new RFCStructParameter {
                RfcStructName = "EW_LIKP",
                PropertyName = "DeliveryOrderHeadExport"
            };
            this.RfcStructNames.Add(parameter2);
        }

        public override void SetTableNames()
        {
            this.RfcTableNames = new List<RFCTableParameter>();
            RFCTableParameter item = new RFCTableParameter {
                RfcTableName = "IT_LIPS",
                PropertyName = "DeliveryOrderDetailsImport"
            };
            this.RfcTableNames.Add(item);
            RFCTableParameter parameter2 = new RFCTableParameter {
                RfcTableName = "ET_LIPS",
                PropertyName = "DeliveryOrderDetailsExport"
            };
            this.RfcTableNames.Add(parameter2);
            RFCTableParameter parameter3 = new RFCTableParameter {
                RfcTableName = "ET_RETURN",
                PropertyName = "MessageList"
            };
            this.RfcTableNames.Add(parameter3);
        }

        [DataMember]
        public string CreditStatus
        {
            get
            {
                return base.GetProperty<string>("EV_CREDIT");
            }
            set
            {
                base.SetProperty("EV_CREDIT", value, 1);
            }
        }

        [DataMember]
        public string CreditStatusMessage
        {
            get
            {
                return base.GetProperty<string>("EV_CREDIT_TEXT");
            }
            set
            {
                base.SetProperty("EV_CREDIT_TEXT", value, 220);
            }
        }

        [DataMember]
        public string DeliveryNo
        {
            get
            {
                return base.GetProperty<string>("EV_DELIVERY");
            }
            set
            {
                base.SetProperty("EV_DELIVERY", value, 10);
            }
        }

        [DataMember]
        public List<SAPDeliveryDetailModel> DeliveryOrderDetailsExport
        {
            get
            {
                if (base.PropertyList("ET_LIPS") == null)
                {
                    return new List<SAPDeliveryDetailModel>();
                }

                return JsonConvert.DeserializeObject<List<SAPDeliveryDetailModel>>(base.GetProperty<string>("ET_LIPS")
                    .ConvertNull());
                //return JsonDataService.Deserialize<List<DeliveryDetailModel>>(base.GetProperty<string>("ET_LIPS")); 
            }
            set
            {
                base.SetProperty("ET_LIPS", JsonConvert.SerializeObject(value.ConvertToDataTable<SAPDeliveryDetailModel>())); 
             //   base.SetProperty("ET_LIPS", JsonDataService.DataTableToJSON(value.ConvertToDataTable<DeliveryDetailModel>()));
            }
        }

        [DataMember]
        public List<SAPDeliveryDetailModel> DeliveryOrderDetailsImport
        {
            get
            {
                if (base.PropertyList("IT_LIPS") == null)
                {
                    return new List<SAPDeliveryDetailModel>();
                }

                return JsonConvert.DeserializeObject<List<SAPDeliveryDetailModel>>(base.GetProperty<string>("IT_LIPS")
                    .ConvertNull());
            }
            set
            {
                base.SetProperty("IT_LIPS", JsonConvert.SerializeObject(value.ConvertToDataTable<SAPDeliveryDetailModel>())); 
               // base.SetProperty("IT_LIPS", JsonDataService.DataTableToJSON(value.ConvertToDataTable<DeliveryDetailModel>()));
            }
        }

        [DataMember]
        public SAPDeliveryHeadModel DeliveryOrderHeadExport
        {
            get
            {
                if (base.PropertyList("EW_LIKP") == null)
                {
                    return new SAPDeliveryHeadModel();
                }

                return JsonConvert.DeserializeObject<SAPDeliveryHeadModel>(base.GetProperty<string>("EW_LIKP")
                    .ConvertNull());
               // return JsonDataService.Deserialize<DeliveryHeadModel>(new StringBuilder(base.GetProperty<string>("EW_LIKP")));                 
            }
            set
            {
                base.SetProperty("EW_LIKP", JsonConvert.SerializeObject(value));
               // base.SetProperty("EW_LIKP", JsonDataService.ObjectToJSON(value));
            }
        }

        [DataMember]
        public SAPDeliveryHeadModel DeliveryOrderHeadImport
        {
            get
            {
                if (base.PropertyList("IW_LIKP") == null)
                {
                    return new SAPDeliveryHeadModel();
                }

                return JsonConvert.DeserializeObject<SAPDeliveryHeadModel>(base.GetProperty<string>("IW_LIKP"));
                //return JsonDataService.Deserialize<DeliveryHeadModel>(new StringBuilder(base.GetProperty<string>("IW_LIKP")));                 
            }
            set
            {
                base.SetProperty("IW_LIKP", JsonConvert.SerializeObject(value));
               // base.SetProperty("IW_LIKP", JsonDataService.ObjectToJSON(value));
            }
        }

        [DataMember]
        public string DeliverySatus
        {
            get
            {
                return base.GetProperty<string>("EV_GOODS_ISSUE");
            }
            set
            {
                base.SetProperty("EV_GOODS_ISSUE", value, 1);
            }
        }

        [DataMember]
        public List<MessageModel> MessageList
        {
            get
            {
                if (base.PropertyList("ET_RETURN") == null)
                {
                    return new List<MessageModel>();
                }

                return JsonConvert.DeserializeObject<List<MessageModel>>(base.GetProperty<string>("ET_RETURN").ConvertNull());                
            }
            set
            {
                base.SetProperty("IT_RETURN", JsonConvert.SerializeObject(value.ConvertToDataTable<MessageModel>()));
               // base.SetProperty("IT_RETURN", JsonDataService.DataTableToJSON(value.ConvertToDataTable<MessageModel>()));
            }
        }

        [DataMember]
        public string MessageType
        {
            get
            {
                return base.GetProperty<string>("EV_TYPE");
            }
            set
            {
                base.SetProperty("EV_TYPE", value, 1);
            }
        }
    }
}

