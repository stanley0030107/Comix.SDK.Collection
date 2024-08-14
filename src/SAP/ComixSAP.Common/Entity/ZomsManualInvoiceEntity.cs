using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common.SAP;
using ComixSAP.Common.Model;
using Furion.JsonSerialization;
using Newtonsoft.Json;

namespace ComixSAP.Common.Entity
{
    public class ZomsManualInvoiceEntity : SapEntityBase
    {
        public ZomsManualInvoiceEntity()
        {
            base.FuncName = "ZOMS_MANUAL_INVOICE";
        }

        public override void SetFieldNames()
        {
            this.PropertyNames = new SortedDictionary<string, RFCParamater>();
            RFCParamater paramater = new RFCParamater {
                ParaDirection = Direction.InPut
            };
            this.PropertyNames.Add("IW_HEAD", paramater);

            RFCParamater paramater2 = new RFCParamater
            {
                ParaDirection = Direction.InPut
            };
            this.PropertyNames.Add("IT_ITEM", paramater2);

            RFCParamater paramater3 = new RFCParamater
            {
                ParaDirection = Direction.OutPut
            };
            this.PropertyNames.Add("IT_RETURN", paramater3);
        }

        public override void SetStructNames()
        {
            this.RfcStructNames = new List<RFCStructParameter>();
            RFCStructParameter item = new RFCStructParameter {
                RfcStructName = "IW_HEAD",
                PropertyName = "InvoiceHead"
            };
            this.RfcStructNames.Add(item);
        }

        public override void SetTableNames()
        {
            this.RfcTableNames = new List<RFCTableParameter>();
            RFCTableParameter item = new RFCTableParameter
            {
                RfcTableName = "IT_RETURN",
                PropertyName = "ReturnMessageList"
            };
            this.RfcTableNames.Add(item);
            
            RFCTableParameter item2 = new RFCTableParameter
            {
                RfcTableName = "IT_ITEM",
                PropertyName = "InvoiceItemList"
            };

            this.RfcTableNames.Add(item2);
        }

        [DataMember]
        public List<ManualInvoiceItemModel> InvoiceItemList
        {
            get
            {
                if (base.PropertyList("IT_ITEM") == null)
                {
                    return new List<ManualInvoiceItemModel>();
                }
                return JsonConvert.DeserializeObject<List<ManualInvoiceItemModel>>(base.GetProperty<string>("IT_ITEM"));
            }
            set
            {
                var datatable = value.ConvertToDataTable<ManualInvoiceItemModel>();
                var json = JsonConvert.SerializeObject(datatable);// JsonConvert.SerializeObject(datatable);
                base.SetProperty("IT_ITEM", json);
            }
        }

        [DataMember]
        public List<ErrorLogModel> ReturnMessageList
        {
            get
            {
                if (base.PropertyList("IT_RETURN") == null)
                {
                    return new List<ErrorLogModel>();
                }

                return JsonConvert.DeserializeObject<List<ErrorLogModel>>(base.GetProperty<string>("IT_RETURN"));
            }
            set
            {
                base.SetProperty("IT_RETURN", JsonConvert.SerializeObject(value.ConvertToDataTable<ErrorLogModel>()));               
            }
        }

        [DataMember]
        public ManualInvoiceHeadModel InvoiceHead
        {
            get
            {
                if (base.PropertyList("IW_HEAD") == null)
                {
                    return new ManualInvoiceHeadModel();
                }

                return JsonConvert.DeserializeObject<ManualInvoiceHeadModel>(base.GetProperty<string>("IW_HEAD"));
            }
            set
            {
                base.SetProperty("IW_HEAD", JsonConvert.SerializeObject(value)); 
            }
        }
    }
}
