using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common.SAP;
using ComixSAP.Common.Model;
using Furion.JsonSerialization;
using Newtonsoft.Json;

namespace ComixSAP.Common.Entity
{
    public class GetInvoiceEntity : SapEntityBase
    {
        public GetInvoiceEntity()
        {
            base.FuncName = "ZCRM_READ_INVOICE";
        }

        public override void SetFieldNames()
        {
            this.PropertyNames = new SortedDictionary<string, RFCParamater>();
            RFCParamater paramater = new RFCParamater {
                ParaDirection = Direction.InPut
            };
            this.PropertyNames.Add("IT_BUKRS", paramater);

            RFCParamater paramater1 = new RFCParamater
            {
                ParaDirection = Direction.OutPut
            };
            this.PropertyNames.Add("EW_VBRK", paramater1);
            RFCParamater paramater2 = new RFCParamater
            {
                ParaDirection = Direction.OutPut
            };
            this.PropertyNames.Add("EW_VBRP", paramater2);

            RFCParamater paramater3 = new RFCParamater
            {
                ParaDirection = Direction.InPut
            };
            this.PropertyNames.Add("LV_DATAB", paramater3);
            RFCParamater paramater4= new RFCParamater
            {
                ParaDirection = Direction.InPut
            };
            this.PropertyNames.Add("LV_DATBI", paramater4);
        }

 

        public override void SetTableNames()
        {
            this.RfcTableNames = new List<RFCTableParameter>();

            RFCTableParameter item = new RFCTableParameter
            {
                RfcTableName = "EW_VBRK",
                PropertyName = "GetInvoiceHead"
            };
            this.RfcTableNames.Add(item);
            RFCTableParameter item1 = new RFCTableParameter
            {
                RfcTableName = "EW_VBRP",
                PropertyName = "GetInvoiceDetail"
            };
            this.RfcTableNames.Add(item1);
             RFCTableParameter item2 = new RFCTableParameter
            {
                RfcTableName = "IT_BUKRS",
                PropertyName = "GetInvoiceInput"
            };
            this.RfcTableNames.Add(item2);
        }
        [DataMember]
        public List<GetInvoiceInputModel> GetInvoiceInput
        {
            get
            {
                if (base.PropertyList("IT_BUKRS") == null)
                {
                    return new List<GetInvoiceInputModel>();
                }

                return JsonConvert.DeserializeObject<List<GetInvoiceInputModel>>(base.GetProperty<string>("IT_BUKRS").ConvertNull());
            }
            set
            {
                base.SetProperty("IT_BUKRS", JsonConvert.SerializeObject(value.ConvertToDataTable<GetInvoiceInputModel>()));               
            }
        }
        [DataMember]
        public List<GetInvoiceReturnHeadModel> GetInvoiceHead
        {
            get
            {
                if (base.PropertyList("EW_VBRK") == null)
                {
                    return new List<GetInvoiceReturnHeadModel>();
                }

                return JsonConvert.DeserializeObject<List<GetInvoiceReturnHeadModel>>(base.GetProperty<string>("EW_VBRK").ConvertNull());
            }
            set
            {
                base.SetProperty("EW_VBRK", JsonConvert.SerializeObject(value.ConvertToDataTable<GetInvoiceReturnHeadModel>()));                
            }
        }

        [DataMember]
        public List<GetInvoiceReturnDetailModel> GetInvoiceDetail
        {
            get
            {
                if (base.PropertyList("EW_VBRP") == null)
                {
                    return new List<GetInvoiceReturnDetailModel>();
                }

                return JsonConvert.DeserializeObject<List<GetInvoiceReturnDetailModel>>(base.GetProperty<string>("EW_VBRP")
                    .ConvertNull());
            }
            set
            {
                base.SetProperty("EW_VBRP", JsonConvert.SerializeObject(value.ConvertToDataTable<GetInvoiceReturnDetailModel>()));  
            }

        }

        [DataMember]
        public string StartDate
        {
            get
            {
                return base.GetProperty<string>("LV_DATAB");
            }
            set
            {
                base.SetProperty("LV_DATAB", value);
            }
        }
        [DataMember]
        public string EndDate
        {
            get
            {
                return base.GetProperty<string>("LV_DATBI");
            }
            set
            {
                base.SetProperty("LV_DATBI", value);
            }
        }
    }
}
