namespace Comix.COS.Model.EventModels.CosMallProduct
{
    public class CosMallProductEventModel
    {
        public EventHeader MsgHeader { get; set; }
        public CosProductBody MsgBody { get; set; }
    }
}