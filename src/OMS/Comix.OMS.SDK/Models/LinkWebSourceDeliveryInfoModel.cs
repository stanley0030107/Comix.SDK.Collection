namespace Comix.OMS.SDK.Models
{
    [Serializable]
    public class LinkWebSourceDeliveryInfoModel
    {
        private string _SourceBillNo;
        /// <summary>
        /// 合约订单编号
        /// </summary>
        public string SourceBillNo
        {
            get { return _SourceBillNo; }
            set { _SourceBillNo = value; }
        }
        private string _DeliveryName;
        /// <summary>
        /// 收货人姓名
        /// </summary>
        public string DeliveryName
        {
            get { return _DeliveryName; }
            set { _DeliveryName = value; }
        }
        private string _Company;
        /// <summary>
        /// 收货人公司
        /// </summary>
        public string Company
        {
            get { return _Company; }
            set { _Company = value; }
        }
        private string _Province;
        /// <summary>
        /// 收货省份
        /// </summary>
        public string Province
        {
            get { return _Province; }
            set { _Province = value; }
        }
        private string _City;
        /// <summary>
        /// 收货城市
        /// </summary>
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
        private string _County;
        /// <summary>
        /// 收货区县
        /// </summary>
        public string County
        {
            get { return _County; }
            set { _County = value; }
        }
        private string _Town;
        /// <summary>
        /// 收货乡镇
        /// </summary>
        public string Town
        {
            get { return _Town; }
            set { _Town = value; }
        }
        private string _Address;
        /// <summary>
        /// 收货街道地址
        /// </summary>
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        private string _Zip;
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string Zip
        {
            get { return _Zip; }
            set { _Zip = value; }
        }

        private string _Phone;
        /// <summary>
        /// 收货人座机
        /// </summary>
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        private string _Mobile;
        /// <summary>
        /// 收货人手机
        /// </summary>
        public string Mobile
        {
            get { return _Mobile; }
            set { _Mobile = value; }
        }
        private string _Email;
        /// <summary>
        /// 收货人邮箱
        /// </summary>
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        private string _Remark;
        /// <summary>
        /// 备注信息
        /// </summary>
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
    }
}
