using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common.SAP;
using ComixSAP.Common.Model;

namespace ComixSAP.Common.Entity
{
    public class AutoVoucherEntity : SapEntityBase
    {
        public AutoVoucherEntity()
        {
            base.FuncName = "ZDRP_GET_VOUCHER";
        }

        public override void SetFieldNames()
        {
            this.PropertyNames = new SortedDictionary<string, RFCParamater>();
            RFCParamater paramater = new RFCParamater {
                ParaDirection = Direction.InPut
            };
            this.PropertyNames.Add("IW_VOUCHER", paramater);

            RFCParamater paramater2 = new RFCParamater
            {
                ParaDirection = Direction.OutPut
            };
            this.PropertyNames.Add("GT_ERRLOG", paramater2);
        }

        public override void SetStructNames()
        {
            this.RfcStructNames = new List<RFCStructParameter>();
            RFCStructParameter item = new RFCStructParameter {
                RfcStructName = "IW_VOUCHER",
                PropertyName = "Voucher"
            };
            this.RfcStructNames.Add(item);
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
        }

        [DataMember]
        public List<ErrorLogModel> ReturnMessageList
        {
            get
            {
                if (base.PropertyList("GT_ERRLOG") == null)
                {
                    return new List<ErrorLogModel>();
                }
                return fastJSON.JSON.Instance.ToObject<System.Data.DataTable>(base.GetProperty<string>("GT_ERRLOG").ConvertNull()).ConvertToList<ErrorLogModel>();
            }
            set
            {
                base.SetProperty("GT_ERRLOG", fastJSON.JSON.Instance.ToJSON(value.ConvertToDataTable<ErrorLogModel>()));                
            }
        }

        [DataMember]
        public AutoVoucherModel Voucher
        {
            get
            {
                if (base.PropertyList("IW_VOUCHER") == null)
                {
                    return new AutoVoucherModel();
                }
                return fastJSON.JSON.Instance.ToObject<AutoVoucherModel>(base.GetProperty<string>("IW_VOUCHER")); 
            }
            set
            {
                base.SetProperty("IW_VOUCHER", fastJSON.JSON.Instance.ToJSON(value));
            }
        }
    }
}
