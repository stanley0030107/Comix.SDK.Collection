using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common;
using ComixSAP.Common.SAP;

namespace ComixSAP.Common.Model
{
    [DataContract]
    public class SapCustomerSalesOrgModel
    {
        /// <summary>
        /// 流水号__是
        /// </summary>
        private string _MessageID = "";
        public string MessageID
        {
            get { return _MessageID; }
            set { _MessageID = value; }
        }
        /// <summary>
        /// 客户编号1__是
        /// </summary>
        private string _CustCode = "";
        public string CustCode
        {
            get { return _CustCode; }
            set { _CustCode = value; }
        }
        /// <summary>
        /// 公司代码__是
        /// </summary>
        private string _CompanyCode = "";
        public string CompanyCode
        {
            get { return _CompanyCode; }
            set { _CompanyCode = value; }
        }
        /// <summary>
        /// 销售组织__是
        /// </summary>
        private string _SalesOrgCode = "";
        public string SalesOrgCode
        {
            get { return _SalesOrgCode; }
            set { _SalesOrgCode = value; }
        }
        /// <summary>
        /// 分销渠道__是
        /// </summary>
        private string _DistChannelCode = "";
        public string DistChannelCode
        {
            get { return _DistChannelCode; }
            set { _DistChannelCode = value; }
        }
        /// <summary>
        /// 客户帐户组__是
        /// </summary>
        private string _CustGroupAccount = "";
        public string CustGroupAccount
        {
            get { return _CustGroupAccount; }
            set { _CustGroupAccount = value; }
        }
        /// <summary>
        /// 产品组__是
        /// </summary>
        private string _ProdGroup = "";
        public string ProdGroup
        {
            get { return _ProdGroup; }
            set { _ProdGroup = value; }
        }
        /// <summary>
        /// 客户编号1_参考的客户编号_是
        /// </summary>
        private string _Ref_CustCode = "";
        public string Ref_CustCode
        {
            get { return _Ref_CustCode; }
            set { _Ref_CustCode = value; }
        }
        /// <summary>
        /// 公司代码_参考的公司代码_是
        /// </summary>
        private string _Ref_CompanyCode = "";
        public string Ref_CompanyCode
        {
            get { return _Ref_CompanyCode; }
            set { _Ref_CompanyCode = value; }
        }
        /// <summary>
        /// 销售组织_参考的销售组织_是
        /// </summary>
        private string _Ref_SalesOrgCode = "";
        public string Ref_SalesOrgCode
        {
            get { return _Ref_SalesOrgCode; }
            set { _Ref_SalesOrgCode = value; }
        }
        /// <summary>
        /// 分销渠道_参考分销渠道_是
        /// </summary>
        private string _Ref_DistChannelCode = "";
        public string Ref_DistChannelCode
        {
            get { return _Ref_DistChannelCode; }
            set { _Ref_DistChannelCode = value; }
        }
        /// <summary>
        /// 产品组_参考的产品组_是
        /// </summary>
        private string _Ref_ProdGroup = "";
        public string Ref_ProdGroup
        {
            get { return _Ref_ProdGroup; }
            set { _Ref_ProdGroup = value; }
        }
        /// <summary>
        /// 付款条件代码__是
        /// </summary>
        private string _PaymentCode = "";
        public string PaymentCode
        {
            get { return _PaymentCode; }
            set { _PaymentCode = value; }
        }
        /// <summary>
        /// 销售地区__是
        /// </summary>
        private string _SalesAreaID = "";
        public string SalesAreaID
        {
            get { return _SalesAreaID; }
            set { _SalesAreaID = value; }
        }
        /// <summary>
        /// 销售部门__是
        /// </summary>
        private string _SalesDeptID = "";
        public string SalesDeptID
        {
            get { return _SalesDeptID; }
            set { _SalesDeptID = value; }
        }
        /// <summary>
        /// 销售组__是
        /// </summary>
        private string _SalesGroup = "";
        public string SalesGroup
        {
            get { return _SalesGroup; }
            set { _SalesGroup = value; }
        }
        /// <summary>
        /// 客户组_可以为空_否
        /// </summary>
        private string _CustGroup = "";
        public string CustGroup
        {
            get { return _CustGroup; }
            set { _CustGroup = value; }
        }
        /// <summary>
        /// 货币码__是
        /// </summary>
        private string _Currency = "";
        public string Currency
        {
            get { return _Currency; }
            set { _Currency = value; }
        }
        /// <summary>
        /// 工厂_默认工厂对应表见sheet2_是
        /// </summary>
        private string _FactoryCode = "";
        public string FactoryCode
        {
            get { return _FactoryCode; }
            set { _FactoryCode = value; }
        }






    }
}