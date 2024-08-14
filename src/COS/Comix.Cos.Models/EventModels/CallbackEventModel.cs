namespace Comix.Cos.Models.EventModels;

public class CallbackEventModel
{
    public string system { get; set; }
    public string messageId { get; set; }
    public string mallProductCode { get; set; }
    public int status { get; set; }
    public string message { get; set; }
    public string consumeDateTime { get; set; }

    public void Fail(int status, string message)
    {
        this.status = status;
        this.message = message;
    }

    public void Success()
    {
        this.status = 200;
    }
}