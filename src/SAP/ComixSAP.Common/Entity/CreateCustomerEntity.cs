using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common.SAP;
using ComixSAP.Common.Model;
using Furion.JsonSerialization;
using Newtonsoft.Json;

namespace ComixSAP.Common.Entity
{
    public class CreateCustomerEntity : SapEntityBase
    {
        public CreateCustomerEntity()
        {
            base.FuncName = "ZMDM_CREATE_CUSTOMER_MASTER";
        }

        public override void SetFieldNames()
        {
            this.PropertyNames = new SortedDictionary<string, RFCParamater>();
            RFCParamater paramater = new RFCParamater
            {
                ParaDirection = Direction.InPut
            };
            this.PropertyNames.Add("IT_CUSTOMER", paramater);

            RFCParamater paramater2 = new RFCParamater
            {
                ParaDirection = Direction.InPut
            };
            this.PropertyNames.Add("IT_KNVP", paramater2);

            RFCParamater paramater3 = new RFCParamater
            {
                ParaDirection = Direction.OutPut
            };
            this.PropertyNames.Add("LS_TYPE", paramater3);
            
            RFCParamater paramater4 = new RFCParamater
            {
                ParaDirection = Direction.OutPut
            };
            this.PropertyNames.Add("LS_MESSAGE", paramater4);
        }

        public override void SetTableNames()
        {
            this.RfcTableNames = new List<RFCTableParameter>();
            RFCTableParameter item = new RFCTableParameter
            {
                RfcTableName = "IT_CUSTOMER",
                PropertyName = "CustomerList"
            };
            this.RfcTableNames.Add(item);

            RFCTableParameter item2 = new RFCTableParameter
            {
                RfcTableName = "IT_KNVP",
                PropertyName = "KnvpList"
            };
            this.RfcTableNames.Add(item2);
        }

        [DataMember]
        public List<CreateCustomerModel> CustomerList
        {
            get
            {
                if (base.PropertyList("IT_CUSTOMER") == null)
                {
                    return new List<CreateCustomerModel>();
                }

                return JsonConvert.DeserializeObject<List<CreateCustomerModel>>(base.GetProperty<string>("IT_CUSTOMER").ConvertNull()); 
            }
            set
            {
                base.SetProperty("IT_CUSTOMER", JsonConvert.SerializeObject(value.ConvertToDataTable<CreateCustomerModel>()));
            }
        }

        [DataMember]
        public List<CreateKnvpModel> KnvpList
        {
            get
            {
                if (base.PropertyList("IT_KNVP") == null)
                {
                    return new List<CreateKnvpModel>();
                }

                return JsonConvert.DeserializeObject<List<CreateKnvpModel>>(base.GetProperty<string>("IT_KNVP").ConvertNull()); 
            }
            set
            {
                base.SetProperty("IT_KNVP", JsonConvert.SerializeObject(value.ConvertToDataTable<CreateKnvpModel>()));
            }
        }

        [DataMember]
        public string ReturnType
        {
            get
            {
                return base.GetProperty<string>("LS_TYPE");
            }
            set
            {
                base.SetProperty("LS_TYPE", value, 10);
            }
        }

        [DataMember]
        public string ReturnMessage
        {
            get
            {
                return base.GetProperty<string>("LS_MESSAGE");
            }
            set
            {
                base.SetProperty("LS_MESSAGE", value, 220);
            }
        }
    }
}
