namespace Comix.Qx.Infrastructure.Models
{
    public class ReqSendMessageToMq
    {
        public string OrderCode { get; set; }
        public string DeliveryNo { get; set; }
        public bool IsSigned { get; set; }
        public string FileAddress { get; set; }
    }
}