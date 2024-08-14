namespace Comix.Cos.Models.EventModels.CosMallProduct;

public class CosMallProductEventModel
{
    public EventHeader MsgHeader { get; set; }
    public CosProductBody? MsgBody { get; set; }
}