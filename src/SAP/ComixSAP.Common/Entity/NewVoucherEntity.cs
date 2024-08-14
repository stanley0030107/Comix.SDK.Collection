using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common.SAP;
using Furion.JsonSerialization;
using Newtonsoft.Json;

namespace ComixSAP.Common
{
    public class NewVoucherEntity : SapEntityBase
    {
        public NewVoucherEntity()
        {
            base.FuncName = "ZDRP_GET_MANUAL_VOUCHER";
        }

        public override void SetFieldNames()
        {
            this.PropertyNames = new SortedDictionary<string, RFCParamater>();
            RFCParamater paramater = new RFCParamater {
                ParaDirection = Direction.InPut
            };
            this.PropertyNames.Add("GT_ZHEAD", paramater);

            RFCParamater paramater3 = new RFCParamater
            {
                ParaDirection = Direction.InPut
            };
            this.PropertyNames.Add("GT_ZITEM", paramater3);

            RFCParamater paramater2 = new RFCParamater
            {
                ParaDirection = Direction.OutPut
            };
            this.PropertyNames.Add("GT_ERRLOG", paramater2);
        }

        public override void SetStructNames()
        {
            this.RfcStructNames = new List<RFCStructParameter>();
        }

        public override void SetTableNames()
        {
            this.RfcTableNames = new List<RFCTableParameter>();
            RFCTableParameter item = new RFCTableParameter
            {
                RfcTableName = "GT_ERRLOG",
                PropertyName = "ReturnMessageList"
            };
            this.RfcTableNames.Add(item);

            RFCTableParameter item2 = new RFCTableParameter
            {
                RfcTableName = "GT_ZHEAD",
                PropertyName = "VoucherHead"
            };
            this.RfcTableNames.Add(item2);

            RFCTableParameter item3 = new RFCTableParameter
            {
                RfcTableName = "GT_ZITEM",
                PropertyName = "VoucherItem"
            };
            this.RfcTableNames.Add(item3);
        }

        [DataMember]
        public List<NewVoucherErrorLogModel> ReturnMessageList
        {
            get
            {
                if (base.PropertyList("GT_ERRLOG") == null)
                {
                    return new List<NewVoucherErrorLogModel>();
                }

                return JsonConvert.DeserializeObject<List<NewVoucherErrorLogModel>>(base.GetProperty<string>("GT_ERRLOG")
                    .ConvertNull());
            }
            set
            {
                base.SetProperty("GT_ERRLOG", JsonConvert.SerializeObject(value.ConvertToDataTable<NewVoucherErrorLogModel>()));                  
            }
        }

        [DataMember]
        public List<NewVoucherHeadModel> VoucherHead
        {
            get
            {
                if (base.PropertyList("GT_ZHEAD") == null)
                {
                    return new List<NewVoucherHeadModel>();
                }

                return JsonConvert.DeserializeObject<List<NewVoucherHeadModel>>(base.GetProperty<string>("GT_ZHEAD")
                    .ConvertNull());
            }
            set
            {
                base.SetProperty("GT_ZHEAD", JsonConvert.SerializeObject(value.ConvertToDataTable<NewVoucherHeadModel>())); 
            }
        }

        [DataMember]
        public List<NewVoucherItemModel> VoucherItem
        {
            get
            {
                if (base.PropertyList("GT_ZITEM") == null)
                {
                    return new List<NewVoucherItemModel>();
                }

                return JsonConvert.DeserializeObject<List<NewVoucherItemModel>>(base.GetProperty<string>("GT_ZITEM")
                    .ConvertNull());
            }
            set
            {
                base.SetProperty("GT_ZITEM", JsonConvert.SerializeObject(value.ConvertToDataTable<NewVoucherItemModel>())); 
            }
        }
    }
}
