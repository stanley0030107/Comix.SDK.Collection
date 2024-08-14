using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using ComixSAP.Common.SAP;

namespace ComixSAP.Common.Model
{
    [DataContract]
    public class SAPDeliveryHeadModel : SapModelBase
    {
        //2016-12-16
        //新增订单员信息 
        //ERNAM
        public override void SetFieldNames()
        {
            //this.PropertyNames = new List<string> { "VBELN", "VKORG", "VTWEG", "SPART", "VKBUR", "VKGRP", "WADAT", "KODAT", "NTGEW", "BRGEW", "GEWEI", "VOLUM", "VOLEH", "REMARK", "UPDKZ", "CDS_DELIVERY", "XABLN" ,
            //"ORDERNO","DATALINE","SDF_FLAG","ADDR_NAME","ADDR_CITY","ADDR_STREET","ADDR_TEL","ADDR_REGION","ADDR_COUNTRY","POSTL_COD1"};

            this.PropertyNames = new List<string> { "VBELN", "VKORG", "VTWEG", "SPART", "VKBUR", "VKGRP", "WADAT", "KODAT", "NTGEW", "BRGEW", "GEWEI", "VOLUM", "VOLEH", "REMARK", "UPDKZ", "CDS_DELIVERY", "XABLN" ,
            "ORDERNO","DATALINE","ERNAM","SH_CITY"};//
        }

        ///// <summary>
        ///// 城市邮政编码
        ///// </summary>
        //[DataMember]
        //public string Postcode
        //{
        //    get
        //    {
        //        return base.GetProperty<string>("POSTL_COD1");
        //    }
        //    set
        //    {
        //        base.SetProperty("POSTL_COD1", value, 10);
        //    }
        //}

        ///// <summary>
        ///// 国家代码
        ///// </summary>
        //[DataMember]
        //public string CountryCode
        //{
        //    get
        //    {
        //        return base.GetProperty<string>("ADDR_COUNTRY");
        //    }
        //    set
        //    {
        //        base.SetProperty("ADDR_COUNTRY", value, 3);
        //    }
        //}

        ///// <summary>
        ///// 地区 (州、省、县) SAP 编码
        ///// </summary>
        //[DataMember]
        //public string RegionCode
        //{
        //    get
        //    {
        //        return base.GetProperty<string>("ADDR_REGION");
        //    }
        //    set
        //    {
        //        base.SetProperty("ADDR_REGION", value, 3);
        //    }
        //}

        ///// <summary>
        ///// 送货方联系方式
        ///// </summary>
        //[DataMember]
        //public string ShipToCNTTEL
        //{
        //    get
        //    {
        //        return base.GetProperty<string>("ADDR_TEL");
        //    }
        //    set
        //    {
        //        base.SetProperty("ADDR_TEL", value, 30);
        //    }
        //}

        ///// <summary>
        ///// 街道(送货地址）
        ///// </summary>
        //[DataMember]
        //public string ShipToStreet
        //{
        //    get
        //    {
        //        return base.GetProperty<string>("ADDR_STREET");
        //    }
        //    set
        //    {
        //        base.SetProperty("ADDR_STREET", value);
        //    }
        //}

        ///// <summary>
        ///// 城市
        ///// </summary>
        //[DataMember]
        //public string ShipToCity
        //{
        //    get
        //    {
        //        return base.GetProperty<string>("ADDR_CITY");
        //    }
        //    set
        //    {
        //        base.SetProperty("ADDR_CITY", value, 40);
        //    }
        //}

        ///// <summary>
        ///// 送达方名称（送货人）
        ///// </summary>
        //[DataMember]
        //public string ShipToName
        //{
        //    get
        //    {
        //        return base.GetProperty<string>("ADDR_NAME");
        //    }
        //    set
        //    {
        //        base.SetProperty("ADDR_NAME", value, 40);
        //    }
        //}

        ///// <summary>
        ///// 送货地址手动标志
        ///// </summary>
        //[DataMember]
        //public string FlagManual
        //{
        //    get
        //    {
        //        return base.GetProperty<string>("SDF_FLAG");
        //    }
        //    set
        //    {
        //        base.SetProperty("SDF_FLAG", value,1);
        //    }
        //}


        //public DeliveryHeadModel()
        //{
        //    this.OrderBillNo = string.Empty;
        //    this.DataLine = string.Empty;
        //}
        [DataMember]
        public string DeliveryCity
        {
            get
            {
                return base.GetProperty<string>("SH_CITY");
            }
            set
            {
                base.SetProperty("SH_CITY", value, 40);
            }
        }

        [DataMember]
        public string OrderOperatorName
        {
            get
            {
                return base.GetProperty<string>("ERNAM");
            }
            set
            {
                base.SetProperty("ERNAM", value, 12);
            }
        }
        /// <summary>
        /// 数据来源B2B、LINK
        /// </summary>
        [DataMember]
        public string DataLine
        {
            get
            {
                return base.GetProperty<string>("DATALINE");
            }
            set
            {
                base.SetProperty("DATALINE", value);
            }
        }

        /// <summary>
        /// 商城订单编号
        /// </summary>
        [DataMember]
        public string OrderBillNo
        {
            get
            {
                return base.GetProperty<string>("ORDERNO");
            }
            set
            {
                base.SetProperty("ORDERNO", value);
            }
        }

        [DataMember]
        public string DiscountAmount
        {
            get
            {
                return base.GetProperty<string>("XABLN");
            }
            set
            {
                base.SetProperty("XABLN", value);
            }
        }

        [DataMember]
        public string CDSBillNO
        {
            get
            {
                return base.GetProperty<string>("CDS_DELIVERY");
            }
            set
            {
                base.SetProperty("CDS_DELIVERY", value, 20);
            }
        }

        [DataMember]
        public string ChannelCode
        {
            get
            {
                return base.GetProperty<string>("VTWEG");
            }
            set
            {
                base.SetProperty("VTWEG", value, 2);
            }
        }

        public string DeliveryNo
        {
            get
            {
                return base.GetProperty<string>("VBELN");
            }
            set
            {
                base.SetProperty("VBELN", value, 10);
            }
        }

        [DataMember]
        public string IsModify
        {
            get
            {
                return base.GetProperty<string>("UPDKZ");
            }
            set
            {
                base.SetProperty("UPDKZ", value, 3);
            }
        }

        [DataMember]
        public string PickingDate
        {
            get
            {
                return base.GetProperty<string>("KODAT");
            }
            set
            {
                base.SetProperty("KODAT", value, 8);
            }
        }

        [DataMember]
        public string ProdGroup
        {
            get
            {
                return base.GetProperty<string>("SPART");
            }
            set
            {
                base.SetProperty("SPART", value, 2);
            }
        }

        [DataMember]
        public string Remark
        {
            get
            {
                return base.GetProperty<string>("REMARK");
            }
            set
            {
                base.SetProperty("REMARK", value, 300);
            }
        }


        [DataMember]
        public string SalesDept
        {
            get
            {
                return base.GetProperty<string>("VKBUR");
            }
            set
            {
                base.SetProperty("VKBUR", value, 4);
            }
        }

        [DataMember]
        public string SalesGroup
        {
            get
            {
                return base.GetProperty<string>("VKGRP");
            }
            set
            {
                base.SetProperty("VKGRP", value, 3);
            }
        }

        [DataMember]
        public string SalesOrg
        {
            get
            {
                return base.GetProperty<string>("VKORG");
            }
            set
            {
                base.SetProperty("VKORG", value, 4);
            }
        }

        [DataMember]
        public string ScheduleMoveDate
        {
            get
            {
                return base.GetProperty<string>("WADAT");
            }
            set
            {
                base.SetProperty("WADAT", value, 8);
            }
        }

        [DataMember]
        public decimal TotalGlossWeight
        {
            get
            {
                return base.GetProperty<decimal>("BRGEW");
            }
            set
            {
                base.SetProperty("BRGEW", value);
            }
        }

        [DataMember]
        public decimal TotalNetWeight
        {
            get
            {
                return base.GetProperty<decimal>("NTGEW");
            }
            set
            {
                base.SetProperty("NTGEW", value);
            }
        }

        [DataMember]
        public decimal Traffic
        {
            get
            {
                return base.GetProperty<decimal>("VOLUM");
            }
            set
            {
                base.SetProperty("VOLUM", value);
            }
        }

        [DataMember]
        public string TrafficUnit
        {
            get
            {
                return base.GetProperty<string>("VOLEH");
            }
            set
            {
                base.SetProperty("VOLEH", value, 3);
            }
        }

        [DataMember]
        public string WeightUnit
        {
            get
            {
                return base.GetProperty<string>("GEWEI");
            }
            set
            {
                base.SetProperty("GEWEI", value, 3);
            }
        }
    }
}

