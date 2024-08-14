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
        /// ��ˮ��__��
        /// </summary>
        private string _MessageID = "";
        public string MessageID
        {
            get { return _MessageID; }
            set { _MessageID = value; }
        }
        /// <summary>
        /// �ͻ����1__��
        /// </summary>
        private string _CustCode = "";
        public string CustCode
        {
            get { return _CustCode; }
            set { _CustCode = value; }
        }
        /// <summary>
        /// ��˾����__��
        /// </summary>
        private string _CompanyCode = "";
        public string CompanyCode
        {
            get { return _CompanyCode; }
            set { _CompanyCode = value; }
        }
        /// <summary>
        /// ������֯__��
        /// </summary>
        private string _SalesOrgCode = "";
        public string SalesOrgCode
        {
            get { return _SalesOrgCode; }
            set { _SalesOrgCode = value; }
        }
        /// <summary>
        /// ��������__��
        /// </summary>
        private string _DistChannelCode = "";
        public string DistChannelCode
        {
            get { return _DistChannelCode; }
            set { _DistChannelCode = value; }
        }
        /// <summary>
        /// �ͻ��ʻ���__��
        /// </summary>
        private string _CustGroupAccount = "";
        public string CustGroupAccount
        {
            get { return _CustGroupAccount; }
            set { _CustGroupAccount = value; }
        }
        /// <summary>
        /// ��Ʒ��__��
        /// </summary>
        private string _ProdGroup = "";
        public string ProdGroup
        {
            get { return _ProdGroup; }
            set { _ProdGroup = value; }
        }
        /// <summary>
        /// �ͻ����1_�ο��Ŀͻ����_��
        /// </summary>
        private string _Ref_CustCode = "";
        public string Ref_CustCode
        {
            get { return _Ref_CustCode; }
            set { _Ref_CustCode = value; }
        }
        /// <summary>
        /// ��˾����_�ο��Ĺ�˾����_��
        /// </summary>
        private string _Ref_CompanyCode = "";
        public string Ref_CompanyCode
        {
            get { return _Ref_CompanyCode; }
            set { _Ref_CompanyCode = value; }
        }
        /// <summary>
        /// ������֯_�ο���������֯_��
        /// </summary>
        private string _Ref_SalesOrgCode = "";
        public string Ref_SalesOrgCode
        {
            get { return _Ref_SalesOrgCode; }
            set { _Ref_SalesOrgCode = value; }
        }
        /// <summary>
        /// ��������_�ο���������_��
        /// </summary>
        private string _Ref_DistChannelCode = "";
        public string Ref_DistChannelCode
        {
            get { return _Ref_DistChannelCode; }
            set { _Ref_DistChannelCode = value; }
        }
        /// <summary>
        /// ��Ʒ��_�ο��Ĳ�Ʒ��_��
        /// </summary>
        private string _Ref_ProdGroup = "";
        public string Ref_ProdGroup
        {
            get { return _Ref_ProdGroup; }
            set { _Ref_ProdGroup = value; }
        }
        /// <summary>
        /// ������������__��
        /// </summary>
        private string _PaymentCode = "";
        public string PaymentCode
        {
            get { return _PaymentCode; }
            set { _PaymentCode = value; }
        }
        /// <summary>
        /// ���۵���__��
        /// </summary>
        private string _SalesAreaID = "";
        public string SalesAreaID
        {
            get { return _SalesAreaID; }
            set { _SalesAreaID = value; }
        }
        /// <summary>
        /// ���۲���__��
        /// </summary>
        private string _SalesDeptID = "";
        public string SalesDeptID
        {
            get { return _SalesDeptID; }
            set { _SalesDeptID = value; }
        }
        /// <summary>
        /// ������__��
        /// </summary>
        private string _SalesGroup = "";
        public string SalesGroup
        {
            get { return _SalesGroup; }
            set { _SalesGroup = value; }
        }
        /// <summary>
        /// �ͻ���_����Ϊ��_��
        /// </summary>
        private string _CustGroup = "";
        public string CustGroup
        {
            get { return _CustGroup; }
            set { _CustGroup = value; }
        }
        /// <summary>
        /// ������__��
        /// </summary>
        private string _Currency = "";
        public string Currency
        {
            get { return _Currency; }
            set { _Currency = value; }
        }
        /// <summary>
        /// ����_Ĭ�Ϲ�����Ӧ���sheet2_��
        /// </summary>
        private string _FactoryCode = "";
        public string FactoryCode
        {
            get { return _FactoryCode; }
            set { _FactoryCode = value; }
        }






    }
}