namespace Comix.COS.Model.EventModels
{
    public class EventHeader
    {
        public string systemId { get; set; }
        public string messageId { get; set; }
        public string systemName { get; set; }
        public string tokenStr { get; set; }
        public string UserCode { get; set; }
        public string LoginIP { get; set; }
        public string LoginComputerName { get; set; }
        public string OperateTime { get; set; }
    }
}