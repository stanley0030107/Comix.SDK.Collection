using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common.SAP;
using ComixSAP.Common.Model;
using Furion.JsonSerialization;
using Newtonsoft.Json;

namespace ComixSAP.Common.Entity
{
    public class CreateProductEntity : SapEntityBase
    {
        public CreateProductEntity()
        {
            base.FuncName = "ZMDM_CREATE_MATERIAL_MASTER";
        }

        public override void SetFieldNames()
        {
            this.PropertyNames = new SortedDictionary<string, RFCParamater>();
            RFCParamater paramater = new RFCParamater
            {
                ParaDirection = Direction.InPut
            };
            this.PropertyNames.Add("I_HEAD", paramater);

            RFCParamater paramater2 = new RFCParamater
            {
                ParaDirection = Direction.InPut
            };
            this.PropertyNames.Add("IT_RECORD", paramater2);

            RFCParamater paramater3 = new RFCParamater
            {
                ParaDirection = Direction.InPut
            };
            this.PropertyNames.Add("IT_UNITSOFMEASURE", paramater3);

            RFCParamater paramater4 = new RFCParamater
            {
                ParaDirection = Direction.OutPut
            };
            this.PropertyNames.Add("ET_MESSTAB", paramater4);
            
        }

        public override void SetTableNames()
        {
            this.RfcTableNames = new List<RFCTableParameter>();
            RFCTableParameter item = new RFCTableParameter
            {
                RfcTableName = "IT_UNITSOFMEASURE",
                PropertyName = "ProductUnitList"
            };
            this.RfcTableNames.Add(item);

            RFCTableParameter item3 = new RFCTableParameter
            {
                RfcTableName = "IT_RECORD",
                PropertyName = "ProductDetailList"
            };
            this.RfcTableNames.Add(item3);

            RFCTableParameter item2 = new RFCTableParameter
            {
                RfcTableName = "ET_MESSTAB",
                PropertyName = "ReturnList"
            };
            this.RfcTableNames.Add(item2);
        }
        public override void SetStructNames()
        {
            this.RfcStructNames = new List<RFCStructParameter>();
            RFCStructParameter item = new RFCStructParameter
            {
                RfcStructName = "I_HEAD",
                PropertyName = "ProductHead"
            };
            this.RfcStructNames.Add(item);
        }
        [DataMember]
        public CreateProductHeadModel ProductHead
        {

            get
            {
                if (base.PropertyList("I_HEAD") == null)
                {
                    return new CreateProductHeadModel();
                }

                return JsonConvert.DeserializeObject< CreateProductHeadModel >(base.GetProperty<string>("I_HEAD"));
            }
            set
            {
                base.SetProperty("I_HEAD", JsonConvert.SerializeObject(value));  
            }

        }
        [DataMember]
        public List<CreateProductDetailModel> ProductDetailList
        {
            get
            {
                if (base.PropertyList("IT_RECORD") == null)
                {
                    return new List<CreateProductDetailModel>();
                }

                return JsonConvert.DeserializeObject<List<CreateProductDetailModel>>(base.GetProperty<string>("IT_RECORD")
                    .ConvertNull());
            }
            set
            {
                base.SetProperty("IT_RECORD", JsonConvert.SerializeObject(value.ConvertToDataTable<CreateProductDetailModel>()));  
            }
        }
        [DataMember]
        public List<CreateProductUnitModel> ProductUnitList
        {
            get
            {
                if (base.PropertyList("IT_UNITSOFMEASURE") == null)
                {
                    return new List<CreateProductUnitModel>();
                }

                return JsonConvert.DeserializeObject<List<CreateProductUnitModel>>(base.GetProperty<string>("IT_UNITSOFMEASURE")
                    .ConvertNull());
            }
            set
            {
                base.SetProperty("IT_UNITSOFMEASURE", JsonConvert.SerializeObject(value.ConvertToDataTable<CreateProductUnitModel>()));  
            }
        }

        [DataMember]
        public List<CreateProductReturnModel> ReturnList
        {
            get
            {
                if (base.PropertyList("ET_MESSTAB") == null)
                {
                    return new List<CreateProductReturnModel>();
                }

                return JsonConvert.DeserializeObject<List<CreateProductReturnModel>>(base.GetProperty<string>("ET_MESSTAB")
                    .ConvertNull());
            }
            set
            {
                base.SetProperty("ET_MESSTAB",
                    JsonConvert.SerializeObject(value.ConvertToDataTable<CreateProductReturnModel>()));  
            }
        }
    }
}
