using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common.SAP;
using ComixSAP.Common.Model;
using Furion.JsonSerialization;
using Newtonsoft.Json;

namespace ComixSAP.Common.Entity
{
    public class CreateSapCustomerSalesOrgEntity : SapEntityBase
    {
        public CreateSapCustomerSalesOrgEntity()
        {
            base.FuncName = "ZMDM_CREATE_CUSTOMER_SALES";
        }

        public override void SetFieldNames()
        {
            this.PropertyNames = new SortedDictionary<string, RFCParamater>();
            RFCParamater paramater = new RFCParamater
            {
                ParaDirection = Direction.InPut
            };
            this.PropertyNames.Add("IT_RECORD", paramater);

            RFCParamater paramater2 = new RFCParamater
            {
                ParaDirection = Direction.OutPut
            };
            this.PropertyNames.Add("ET_MESSTAB", paramater2);

            RFCParamater paramater3 = new RFCParamater
            {
                ParaDirection = Direction.OutPut
            };
            this.PropertyNames.Add("LV_MESSAGE", paramater3);
        }

        public override void SetTableNames()
        {
            this.RfcTableNames = new List<RFCTableParameter>();
            RFCTableParameter item = new RFCTableParameter
            {
                RfcTableName = "IT_RECORD",
                PropertyName = "ProductList"
            };
            this.RfcTableNames.Add(item);

            RFCTableParameter item2 = new RFCTableParameter
            {
                RfcTableName = "ET_MESSTAB",
                PropertyName = "ReturnList"
            };

            this.RfcTableNames.Add(item2);
        }

        [DataMember]
        public List<CreateSapCustomerSalesOrgModel> SalesOrgList
        {
            get
            {
                if (base.PropertyList("IT_RECORD") == null)
                {
                    return new List<CreateSapCustomerSalesOrgModel>();
                }

                return JsonConvert.DeserializeObject<List<CreateSapCustomerSalesOrgModel>>(base.GetProperty<string>("IT_RECORD")
                    .ConvertNull());
            }
            set
            {
                base.SetProperty("IT_RECORD", JsonConvert.SerializeObject(value.ConvertToDataTable<CreateSapCustomerSalesOrgModel>())); 
            }
        }

        [DataMember]
        public List<CreateSapCustomerSalesOrgReturnModel> ReturnList
        {
            get
            {
                if (base.PropertyList("ET_MESSTAB") == null)
                {
                    return new List<CreateSapCustomerSalesOrgReturnModel>();
                }

                return JsonConvert.DeserializeObject<List<CreateSapCustomerSalesOrgReturnModel>>(base.GetProperty<string>("ET_MESSTAB")
                    .ConvertNull());
            }
            set
            {
                base.SetProperty("ET_MESSTAB", JsonConvert.SerializeObject(value.ConvertToDataTable<CreateSapCustomerSalesOrgReturnModel>())); 
            }
        }

        [DataMember]
        public string ReturnMessage
        {
            get
            {
                return base.GetProperty<string>("LV_MESSAGE");
            }
            set
            {
                base.SetProperty("LV_MESSAGE", value, 220);
            }
        }
    }
}
