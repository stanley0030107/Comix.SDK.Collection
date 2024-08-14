using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common;
using ComixSAP.Common.SAP;

namespace ComixSAP.Common.Model
{
    [DataContract]
    public class ProductCategoryModel : SapModelBase
    {
        public override void SetFieldNames()
        {
            this.PropertyNames = new List<string> {
           "MATNR","PRODH1","VTEXT1","PRODH2","VTEXT2","PRODH3","VTEXT3"};
        }

        [DataMember]
        //物料编码
        public string sapSkuCode
        {
            get
            {
                return base.GetProperty<string>("MATNR");
            }
            set
            {
                base.SetProperty("MATNR", value);
            }
        }

        [DataMember]
        //一级分类编码
        public string categoryCode1
        {
            get
            {
                return base.GetProperty<string>("PRODH1");
            }
            set
            {
                base.SetProperty("PRODH1", value);
            }
        }

        [DataMember]
        //一级分类名称
        public string categoryName1
        {
            get
            {
                return base.GetProperty<string>("VTEXT1");
            }
            set
            {
                base.SetProperty("VTEXT1", value);
            }
        }
        [DataMember]
        //二级分类编码
        public string categoryCode2
        {
            get
            {
                return base.GetProperty<string>("PRODH2");
            }
            set
            {
                base.SetProperty("PRODH2", value);
            }
        }

        [DataMember]
        //二级分类名称
        public string categoryName2
        {
            get
            {
                return base.GetProperty<string>("VTEXT2");
            }
            set
            {
                base.SetProperty("VTEXT2", value);
            }
        }
        [DataMember]
        //三级分类编码
        public string categoryCode3
        {
            get
            {
                return base.GetProperty<string>("PRODH3");
            }
            set
            {
                base.SetProperty("PRODH3", value);
            }
        }

        [DataMember]
        //三级分类名称
        public string categoryName3
        {
            get
            {
                return base.GetProperty<string>("VTEXT3");
            }
            set
            {
                base.SetProperty("VTEXT3", value);
            }
        }
    }
}


