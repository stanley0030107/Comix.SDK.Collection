using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common;
using ComixSAP.Common.SAP;

namespace ComixSAP.Common.Model
{
    [DataContract]
    public class ProductHeadModel
    {
        /// <summary>
        /// 流水号__是
        /// </summary>
        private string _MESSAGEID = "";
        public string MESSAGEID
        {
            get { return _MESSAGEID; }
            set { _MESSAGEID = value; }
        }
        /// <summary>
        /// 物料号_500000052_是
        /// </summary>
        private string _ProductCode = "";
        public string ProductCode
        {
            get { return _ProductCode; }
            set { _ProductCode = value; }
        }
        /// <summary>
        /// 行业领域_Z_是
        /// </summary>
        private string _IND_SECTOR = "";
        public string IND_SECTOR
        {
            get { return _IND_SECTOR; }
            set { _IND_SECTOR = value; }
        }
        /// <summary>
        /// 物料类型_Z005_是
        /// </summary>
        private string _MATL_TYPE = "";
        public string MATL_TYPE
        {
            get { return _MATL_TYPE; }
            set { _MATL_TYPE = value; }
        }
        /// <summary>
        /// 基本数据视图_X_是
        /// </summary>
        private string _BASIC_VIEW = "";
        public string BASIC_VIEW
        {
            get { return _BASIC_VIEW; }
            set { _BASIC_VIEW = value; }
        }
        /// <summary>
        /// 销售视图_X_是
        /// </summary>
        private string _SALES_VIEW = "";
        public string SALES_VIEW
        {
            get { return _SALES_VIEW; }
            set { _SALES_VIEW = value; }
        }
        /// <summary>
        /// 采购视图_X_是
        /// </summary>
        private string _PURCHASE_VIEW = "";
        public string PURCHASE_VIEW
        {
            get { return _PURCHASE_VIEW; }
            set { _PURCHASE_VIEW = value; }
        }
        /// <summary>
        /// 物料需求计划(MRP)视图_X_是
        /// </summary>
        private string _MRP_VIEW = "";
        public string MRP_VIEW
        {
            get { return _MRP_VIEW; }
            set { _MRP_VIEW = value; }
        }
        /// <summary>
        /// 预测视图__否
        /// </summary>
        private string _FORECAST_VIEW = "";
        public string FORECAST_VIEW
        {
            get { return _FORECAST_VIEW; }
            set { _FORECAST_VIEW = value; }
        }
        /// <summary>
        /// 工作计划视图__否
        /// </summary>
        private string _WORK_SCHED_VIEW = "";
        public string WORK_SCHED_VIEW
        {
            get { return _WORK_SCHED_VIEW; }
            set { _WORK_SCHED_VIEW = value; }
        }
        /// <summary>
        /// 生产资源/工具(PRT)视图__否
        /// </summary>
        private string _PRT_VIEW = "";
        public string PRT_VIEW
        {
            get { return _PRT_VIEW; }
            set { _PRT_VIEW = value; }
        }
        /// <summary>
        /// 存储视图_X_是
        /// </summary>
        private string _STORAGE_VIEW = "";
        public string STORAGE_VIEW
        {
            get { return _STORAGE_VIEW; }
            set { _STORAGE_VIEW = value; }
        }
        /// <summary>
        /// 仓库管理视图_X_是
        /// </summary>
        private string _WAREHOUSE_VIEW = "";
        public string WAREHOUSE_VIEW
        {
            get { return _WAREHOUSE_VIEW; }
            set { _WAREHOUSE_VIEW = value; }
        }
        /// <summary>
        /// 质量管理视图__否
        /// </summary>
        private string _QUALITY_VIEW = "";
        public string QUALITY_VIEW
        {
            get { return _QUALITY_VIEW; }
            set { _QUALITY_VIEW = value; }
        }
        /// <summary>
        /// 会计视图_X_是
        /// </summary>
        private string _ACCOUNT_VIEW = "";
        public string ACCOUNT_VIEW
        {
            get { return _ACCOUNT_VIEW; }
            set { _ACCOUNT_VIEW = value; }
        }
        /// <summary>
        /// 成本视图_X_是
        /// </summary>
        private string _COST_VIEW = "";
        public string COST_VIEW
        {
            get { return _COST_VIEW; }
            set { _COST_VIEW = value; }
        }
        /// <summary>
        /// 字段未激活的响应__否
        /// </summary>
        private string _INP_FLD_CHECK = "";
        public string INP_FLD_CHECK
        {
            get { return _INP_FLD_CHECK; }
            set { _INP_FLD_CHECK = value; }
        }
        /// <summary>
        /// MATERIAL 字段的长物料号__否
        /// </summary>
        private string _MATERIAL_EXTERNAL = "";
        public string MATERIAL_EXTERNAL
        {
            get { return _MATERIAL_EXTERNAL; }
            set { _MATERIAL_EXTERNAL = value; }
        }
        /// <summary>
        /// MATERIAL 字段的外部 GUID__否
        /// </summary>
        private string _MATERIAL_GUID = "";
        public string MATERIAL_GUID
        {
            get { return _MATERIAL_GUID; }
            set { _MATERIAL_GUID = value; }
        }
        /// <summary>
        /// MATERIAL 字段的版本编号__否
        /// </summary>
        private string _MATERIAL_VERSION = "";
        public string MATERIAL_VERSION
        {
            get { return _MATERIAL_VERSION; }
            set { _MATERIAL_VERSION = value; }
        }





    }
}
