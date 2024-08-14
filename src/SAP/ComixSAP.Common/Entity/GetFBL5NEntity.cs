using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common.SAP;
using ComixSAP.Common.Model;
using Furion.JsonSerialization;
using Newtonsoft.Json;

namespace ComixSAP.Common.Entity
{
    public class GetFBL5NEntity : SapEntityBase
    {
        public GetFBL5NEntity()
        {
            base.FuncName = "ZCRM_READ_FBL5N";
        }

        public override void SetFieldNames()
        {
            this.PropertyNames = new SortedDictionary<string, RFCParamater>();
            RFCParamater paramater = new RFCParamater {
                ParaDirection = Direction.InPut
            };
            this.PropertyNames.Add("IT_BSID", paramater);

            RFCParamater paramater1 = new RFCParamater
            {
                ParaDirection = Direction.OutPut
            };
            this.PropertyNames.Add("EW_FBL5N", paramater1);

            RFCParamater paramater2 = new RFCParamater
            {
                ParaDirection = Direction.InPut
            };
            this.PropertyNames.Add("LV_ALLGSTID", paramater2);

            RFCParamater paramater3 = new RFCParamater
            {
                ParaDirection = Direction.InPut
            };
            this.PropertyNames.Add("lv_KUNNR", paramater3);

        }

 

        public override void SetTableNames()
        {
            this.RfcTableNames = new List<RFCTableParameter>();
            RFCTableParameter item = new RFCTableParameter
            {
                RfcTableName = "IT_BSID",
                PropertyName = "QueryCondition"
            };
            this.RfcTableNames.Add(item);
            RFCTableParameter item1 = new RFCTableParameter
            {
                RfcTableName = "EW_FBL5N",
                PropertyName = "GetInvoiceDetail"
            };
            this.RfcTableNames.Add(item1);

        }
        [DataMember]
        public List<GetFBL5NReturnModel> ReturnData
        {
            get
            {
                if (base.PropertyList("EW_FBL5N") == null)
                {
                    return new List<GetFBL5NReturnModel>();
                }

                return JsonConvert.DeserializeObject<List<GetFBL5NReturnModel>>(base.GetProperty<string>("EW_FBL5N").ConvertNull());  
            }
            set
            {
                base.SetProperty("EW_FBL5N", JsonConvert.SerializeObject(value.ConvertToDataTable<GetFBL5NReturnModel>()));              
            }
        }


        [DataMember]
        public List<GetFBL5NInputModel> QueryCondition
        {
            get
            {
                if (base.PropertyList("IT_BSID") == null)
                {
                    return new List<GetFBL5NInputModel>();
                }

                return JsonConvert.DeserializeObject<List<GetFBL5NInputModel>>(base.GetProperty<string>("IT_BSID").ConvertNull());  
            }
            set
            {
                base.SetProperty("IT_RIT_BSIDETURN", JsonConvert.SerializeObject(value.ConvertToDataTable<GetFBL5NInputModel>()));
            }

        }

        [DataMember]
        public string quiryDate
        {
            get
            {
                return base.GetProperty<string>("LV_ALLGSTID");
            }
            set
            {
                base.SetProperty("LV_ALLGSTID", value, 10);
            }
        }

        [DataMember]
        public string customerCode
        {
            get
            {
                return base.GetProperty<string>("lv_KUNNR");
            }
            set
            {
                base.SetProperty("lv_KUNNR", value, 10);
            }
        }
    }
}
