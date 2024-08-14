using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common.SAP;
using ComixSAP.Common.Model;
using Furion.JsonSerialization;
using Newtonsoft.Json;

namespace ComixSAP.Common.Entity
{
    public class SyncProcutCategoryToSapEntity : SapEntityBase
    {
        public SyncProcutCategoryToSapEntity()
        {
            base.FuncName = "ZDRP_INSERT_ZTPRODH";
        }

        public override void SetFieldNames()
        {
            this.PropertyNames = new SortedDictionary<string, RFCParamater>();
            RFCParamater paramater = new RFCParamater {
                ParaDirection = Direction.InPut
            };
            this.PropertyNames.Add("IT_ZTPRODH", paramater);

            RFCParamater paramater2 = new RFCParamater
            {
                ParaDirection = Direction.OutPut
            };
            this.PropertyNames.Add("LV_TYPE", paramater2);
            RFCParamater paramater3= new RFCParamater
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
                RfcTableName = "IT_ZTPRODH",
                PropertyName = "ProductCategoryList"
            };
            this.RfcTableNames.Add(item);
        }

        [DataMember]
        public List<ProductCategoryModel> ProductCategoryList
        {
            get
            {
                if (base.PropertyList("IT_ZTPRODH") == null)
                {
                    return new List<ProductCategoryModel>();
                }

                return JsonConvert.DeserializeObject<List<ProductCategoryModel>>(base.GetProperty<string>("IT_ZTPRODH").ConvertNull());
            }
            set
            {
                base.SetProperty("IT_ZTPRODH", JsonConvert.SerializeObject(value.ConvertToDataTable<ProductCategoryModel>()));                
            }
        }

        [DataMember]
        public string returnType
        {
            get
            {
                return base.GetProperty<string>("LV_TYPE");
            }
            set
            {
                base.SetProperty("LV_TYPE", value);
            }
        }

        [DataMember]
        public string returnMessage
        {
            get
            {
                return base.GetProperty<string>("LV_MESSAGE");
            }
            set
            {
                base.SetProperty("LV_MESSAGE", value);
            }
        }
    }
}
