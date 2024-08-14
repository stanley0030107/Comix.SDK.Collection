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
        //��ˮ�� 
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
        //���Ϻ� 
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
        //��ҵ����
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
        //��������
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
        //����������ͼ
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
        //������ͼ 
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
        //�ɹ���ͼ
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
        //��������ƻ�(MRP)��ͼ
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
        //Ԥ����ͼ
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
        //�����ƻ���ͼ
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
        //������Դ/����(PRT)��ͼ
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
        //�洢��ͼ
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
        //�ֿ������ͼ
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
        //����������ͼ
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
        //�����ͼ
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
        //�ɱ���ͼ
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
        //�ֶ�δ�������Ӧ
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
        //MATERIAL �ֶεĳ����Ϻ� 
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
        //MATERIAL �ֶε��ⲿ GUID
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
        //MATERIAL �ֶεİ汾��� 
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


