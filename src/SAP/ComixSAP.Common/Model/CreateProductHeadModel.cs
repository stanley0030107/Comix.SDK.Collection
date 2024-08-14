using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common;
using ComixSAP.Common.SAP;

namespace ComixSAP.Common.Model
{
    [DataContract]
    public class CreateProductHeadModel : SapModelBase
    {
        public override void SetFieldNames()
        {
            this.PropertyNames = new List<string> { 
           "MESSAGEID","MATERIAL","IND_SECTOR","MATL_TYPE","BASIC_VIEW","SALES_VIEW","PURCHASE_VIEW","MRP_VIEW","FORECAST_VIEW","WORK_SCHED_VIEW","PRT_VIEW","STORAGE_VIEW","WAREHOUSE_VIEW","QUALITY_VIEW","ACCOUNT_VIEW","COST_VIEW","INP_FLD_CHECK","MATERIAL_EXTERNAL","MATERIAL_GUID","MATERIAL_VERSION"};
        }

        [DataMember]
        //流水号 
        public string Messageid
        {
            get
            {
                return base.GetProperty<string>("MESSAGEID");
            }
            set
            {
                base.SetProperty("MESSAGEID", value);
            }
        }

        [DataMember]
        //物料号 
        public string Material
        {
            get
            {
                return base.GetProperty<string>("MATERIAL");
            }
            set
            {
                base.SetProperty("MATERIAL", value);
            }
        }

        [DataMember]
        //行业领域
        public string IndSector
        {
            get
            {
                return base.GetProperty<string>("IND_SECTOR");
            }
            set
            {
                base.SetProperty("IND_SECTOR", value);
            }
        }

        [DataMember]
        //物料类型
        public string MatlType
        {
            get
            {
                return base.GetProperty<string>("MATL_TYPE");
            }
            set
            {
                base.SetProperty("MATL_TYPE", value);
            }
        }

        [DataMember]
        //基本数据视图
        public string BasicView
        {
            get
            {
                return base.GetProperty<string>("BASIC_VIEW");
            }
            set
            {
                base.SetProperty("BASIC_VIEW", value);
            }
        }

        [DataMember]
        //销售视图 
        public string SalesView
        {
            get
            {
                return base.GetProperty<string>("SALES_VIEW");
            }
            set
            {
                base.SetProperty("SALES_VIEW", value);
            }
        }

        [DataMember]
        //采购视图
        public string PurchaseView
        {
            get
            {
                return base.GetProperty<string>("PURCHASE_VIEW");
            }
            set
            {
                base.SetProperty("PURCHASE_VIEW", value);
            }
        }

        [DataMember]
        //物料需求计划(MRP)视图
        public string MrpView
        {
            get
            {
                return base.GetProperty<string>("MRP_VIEW");
            }
            set
            {
                base.SetProperty("MRP_VIEW", value);
            }
        }

        [DataMember]
        //预测视图
        public string ForecastView
        {
            get
            {
                return base.GetProperty<string>("FORECAST_VIEW");
            }
            set
            {
                base.SetProperty("FORECAST_VIEW", value);
            }
        }

        [DataMember]
        //工作计划视图
        public string WorkSchedView
        {
            get
            {
                return base.GetProperty<string>("WORK_SCHED_VIEW");
            }
            set
            {
                base.SetProperty("WORK_SCHED_VIEW", value);
            }
        }

        [DataMember]
        //生产资源/工具(PRT)视图
        public string PrtView
        {
            get
            {
                return base.GetProperty<string>("PRT_VIEW");
            }
            set
            {
                base.SetProperty("PRT_VIEW", value);
            }
        }

        [DataMember]
        //存储视图
        public string StorageView
        {
            get
            {
                return base.GetProperty<string>("STORAGE_VIEW");
            }
            set
            {
                base.SetProperty("STORAGE_VIEW", value);
            }
        }

        [DataMember]
        //仓库管理视图
        public string WarehouseView
        {
            get
            {
                return base.GetProperty<string>("WAREHOUSE_VIEW");
            }
            set
            {
                base.SetProperty("WAREHOUSE_VIEW", value);
            }
        }

        [DataMember]
        //质量管理视图
        public string QualityView
        {
            get
            {
                return base.GetProperty<string>("QUALITY_VIEW");
            }
            set
            {
                base.SetProperty("QUALITY_VIEW", value);
            }
        }

        [DataMember]
        //会计视图
        public string AccountView
        {
            get
            {
                return base.GetProperty<string>("ACCOUNT_VIEW");
            }
            set
            {
                base.SetProperty("ACCOUNT_VIEW", value);
            }
        }

        [DataMember]
        //成本视图
        public string CostView
        {
            get
            {
                return base.GetProperty<string>("COST_VIEW");
            }
            set
            {
                base.SetProperty("COST_VIEW", value);
            }
        }

        [DataMember]
        //字段未激活的响应
        public string InpFldCheck
        {
            get
            {
                return base.GetProperty<string>("INP_FLD_CHECK");
            }
            set
            {
                base.SetProperty("INP_FLD_CHECK", value);
            }
        }

        [DataMember]
        //MATERIAL 字段的长物料号 
        public string MaterialExternal
        {
            get
            {
                return base.GetProperty<string>("MATERIAL_EXTERNAL");
            }
            set
            {
                base.SetProperty("MATERIAL_EXTERNAL", value);
            }
        }

        [DataMember]
        //MATERIAL 字段的外部 GUID
        public string MaterialGuid
        {
            get
            {
                return base.GetProperty<string>("MATERIAL_GUID");
            }
            set
            {
                base.SetProperty("MATERIAL_GUID", value);
            }
        }

        [DataMember]
        //MATERIAL 字段的版本编号 
        public string MaterialVersion
        {
            get
            {
                return base.GetProperty<string>("MATERIAL_VERSION");
            }
            set
            {
                base.SetProperty("MATERIAL_VERSION", value);
            }
        }

    }
}


