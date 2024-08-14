namespace Comix.COS.Model.EventModels.CosMallBaseData
{
    public class CosMallBaseDataEventModel
    {
        public EventHeader MsgHeader { get; set; }
        public CosBaseDataBody MsgBody { get; set; }
    }
}