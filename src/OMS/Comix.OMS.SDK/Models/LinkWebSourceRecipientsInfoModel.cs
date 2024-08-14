namespace Comix.OMS.SDK.Models
{
    [Serializable]
    public class LinkWebSourceRecipientsInfoModel
    {
        private string _SourceBillNo = "";
        /// <summary>
        /// 合约订单编号
        /// </summary>
        public string SourceBillNo
        {
            get { return _SourceBillNo; }
            set { _SourceBillNo = value; }
        }
        private string _CreatorName = "";
        /// <summary>
        /// 订货人姓名
        /// </summary>
        public string CreatorName
        {
            get { return _CreatorName; }
            set { _CreatorName = value; }
        }
        private string _CreatorPhone = "";
        /// <summary>
        /// 订货人座机
        /// </summary>
        public string CreatorPhone
        {
            get { return _CreatorPhone; }
            set { _CreatorPhone = value; }
        }
        private string _CreatorMobile = "";
        /// <summary>
        /// 订货人手机
        /// </summary>
        public string CreatorMobile
        {
            get { return _CreatorMobile; }
            set { _CreatorMobile = value; }
        }

        private string _creatorDepartment;

        /// <summary>
        /// 订货人部门
        /// </summary>
        public string CreatorDepartment
        {
            get { return _creatorDepartment; }
            set { _creatorDepartment = value; }
        }

        private string _orderOwner;

        /// <summary>
        /// 订货人部门
        /// </summary>
        public string OrderOwner
        {
            get { return _orderOwner; }
            set { _orderOwner = value; }
        }

        /// <summary>
        /// 订货人地址
        /// </summary>
        public string ShipperAddress { get; set; }

        /// <summary>
        /// 订货人邮箱
        /// </summary>
        public string BuyerEmail { get; set; }

    }
}
