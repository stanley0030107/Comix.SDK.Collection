using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common.SAP;
using ComixSAP.Common.Model;
using Furion.JsonSerialization;
using Newtonsoft.Json;

namespace ComixSAP.Common.Entity
{
    [DataContract]
    public class SalesOrderEntity : SapEntityBase
    {
        public SalesOrderEntity()
        {
            base.FuncName = "ZDRP_CREATE_SALES_ORDER";
        }

        public override void SetFieldNames()
        {
            this.PropertyNames = new SortedDictionary<string, RFCParamater>();
            RFCParamater paramater = new RFCParamater {
                ParaDirection = Direction.InPut
            };
            this.PropertyNames.Add("IW_VBAK", paramater);
            RFCParamater paramater2 = new RFCParamater {
                ParaDirection = Direction.InPut
            };
            this.PropertyNames.Add("IT_VBAP", paramater2);
            RFCParamater paramater3 = new RFCParamater {
                ParaDirection = Direction.OutPut
            };
            this.PropertyNames.Add("EW_VBAK", paramater3);
            RFCParamater paramater4 = new RFCParamater {
                ParaDirection = Direction.OutPut
            };
            this.PropertyNames.Add("ET_VBAP", paramater4);
            RFCParamater paramater5 = new RFCParamater {
                ParaDirection = Direction.OutPut
            };
            this.PropertyNames.Add("EV_TYPE", paramater5);
            RFCParamater paramater6 = new RFCParamater {
                ParaDirection = Direction.OutPut
            };
            this.PropertyNames.Add("EV_VBELN", paramater6);
            RFCParamater paramater7 = new RFCParamater {
                ParaDirection = Direction.OutPut
            };
            this.PropertyNames.Add("IT_RETURN", paramater7);
        }

        public override void SetStructNames()
        {
            this.RfcStructNames = new List<RFCStructParameter>();
            RFCStructParameter item = new RFCStructParameter {
                RfcStructName = "IW_VBAK",
                PropertyName = "SalesHeadImport"
            };
            this.RfcStructNames.Add(item);
            RFCStructParameter parameter2 = new RFCStructParameter {
                RfcStructName = "EW_VBAK",
                PropertyName = "SalesHeadExport"
            };
            this.RfcStructNames.Add(parameter2);
        }

        public override void SetTableNames()
        {
            this.RfcTableNames = new List<RFCTableParameter>();
            RFCTableParameter item = new RFCTableParameter {
                RfcTableName = "IT_VBAP",
                PropertyName = "SalesOrderDetailsImport"
            };
            this.RfcTableNames.Add(item);
            RFCTableParameter parameter2 = new RFCTableParameter {
                RfcTableName = "ET_VBAP",
                PropertyName = "SalesOrderDetailsExport"
            };
            this.RfcTableNames.Add(parameter2);
            RFCTableParameter parameter3 = new RFCTableParameter {
                RfcTableName = "IT_RETURN",
                PropertyName = "MessageList"
            };
            this.RfcTableNames.Add(parameter3);
        }

        [DataMember]
        public List<MessageModel> MessageList
        {
            get
            {
                if (base.PropertyList("IT_RETURN") == null)
                {
                    return new List<MessageModel>();
                }

                return JsonConvert.DeserializeObject<List<MessageModel>>(base.GetProperty<string>("IT_RETURN")
                    .ConvertNull());

                //return JsonDataService.DeserializeList<MessageModel>(new StringBuilder(base.GetProperty<string>("IT_RETURN").ConvertNull()));                 
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
                base.SetProperty("EV_TYPE", value, 11);
            }
        }

        [DataMember]
        public SalesOrderHeadModel SalesHeadExport
        {
            get
            {
                if (base.PropertyList("EW_VBAK") == null)
                {
                    return new SalesOrderHeadModel();
                }

                return JsonConvert.DeserializeObject<SalesOrderHeadModel>(base.GetProperty<string>("EW_VBAK"));
               // return JsonDataService.Deserialize<SalesOrderHeadModel>(new StringBuilder(base.GetProperty<string>("EW_VBAK")));                 
            }
            set
            {
                base.SetProperty("EW_VBAK", JsonConvert.SerializeObject(value)); 
               // base.SetProperty("EW_VBAK", JsonDataService.ObjectToJSON(value));
            }
        }

        [DataMember]
        public SalesOrderHeadModel SalesHeadImport
        {
            get
            {
                if (base.PropertyList("IW_VBAK") == null)
                {
                    return new SalesOrderHeadModel();
                }

                return JsonConvert.DeserializeObject<SalesOrderHeadModel>(base.GetProperty<string>("IW_VBAK"));
               // return JsonDataService.Deserialize<SalesOrderHeadModel>(new StringBuilder(base.GetProperty<string>("IW_VBAK"))); 
            }
            set
            {
                base.SetProperty("IW_VBAK", JsonConvert.SerializeObject(value));
                //base.SetProperty("IW_VBAK", JsonDataService.ObjectToJSON(value));
            }
        }

        [DataMember]
        public List<SalesOrderDetailModel> SalesOrderDetailsExport
        {
            get
            {
                if (base.PropertyList("ET_VBAP") == null)
                {
                    return new List<SalesOrderDetailModel>();
                }

                return JsonConvert.DeserializeObject<List<SalesOrderDetailModel>>(base.GetProperty<string>("ET_VBAP").ConvertNull());
              //  return JsonDataService.DeserializeList<SalesOrderDetailModel>(new StringBuilder(base.GetProperty<string>("ET_VBAP").ConvertNull())); 
            }
            set
            {
                base.SetProperty("ET_VBAP", JsonConvert.SerializeObject(value.ConvertToDataTable<SalesOrderDetailModel>()));
               // base.SetProperty("ET_VBAP", JsonDataService.DataTableToJSON(value.ConvertToDataTable<SalesOrderDetailModel>()));
            }
        }

        [DataMember]
        public List<SalesOrderDetailModel> SalesOrderDetailsImport
        {
            get
            {
                if (base.PropertyList("IT_VBAP") == null)
                {
                    return new List<SalesOrderDetailModel>();
                }

                return JsonConvert.DeserializeObject<List<SalesOrderDetailModel>>(base.GetProperty<string>("IT_VBAP").ConvertNull());
               // return JsonDataService.DeserializeList<SalesOrderDetailModel>(new StringBuilder(base.GetProperty<string>("IT_VBAP").ConvertNull())); 
            }
            set
            {
                base.SetProperty("IT_VBAP", JsonConvert.SerializeObject(value.ConvertToDataTable<SalesOrderDetailModel>()));
               // base.SetProperty("IT_VBAP", JsonDataService.DataTableToJSON(value.ConvertToDataTable<SalesOrderDetailModel>()));
            }
        }

        [DataMember]
        public string SAPBillNo
        {
            get
            {
                return base.GetProperty<string>("EV_VBELN");
            }
            set
            {
                base.SetProperty("EV_VBELN", value, 10);
            }
        }
    }
}

