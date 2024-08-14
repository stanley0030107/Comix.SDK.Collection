using ComixCDP.Common.OMSMoldes;

namespace Comix.OMS.SDK.Models
{
    [Serializable]
    public class LinkWebSourceObjectModel
    {

        public LinkWebSourceHeadModel head = new LinkWebSourceHeadModel();

        /// <summary>
        /// 行项目(产品列表)
        /// </summary>
        public List<LinkWebSourceItemModel> WebSourceItemList = new List<LinkWebSourceItemModel>();

        /// <summary>
        /// 收货人信息
        /// </summary>
        public LinkWebSourceDeliveryInfoModel LinkWebSourceDeliveryInfo = new LinkWebSourceDeliveryInfoModel();

        /// <summary>
        /// 订货人信息
        /// </summary>
        public LinkWebSourceRecipientsInfoModel LinkWebSourceRecipientsInfo = new LinkWebSourceRecipientsInfoModel();

        /// <summary>
        /// 发票信息
        /// </summary>
        public LinkWebSourceInvoiceInfoModel LinkWebSourceInvoiceInfo = new LinkWebSourceInvoiceInfoModel();
    }
}
