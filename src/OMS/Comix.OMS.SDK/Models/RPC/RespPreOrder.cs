namespace Comix.OMS.SDK.Models.RPC;

public class RespPreOrder
{
    private bool _success = false;

    public bool success
    {
        get
        {
            if (code != "200")
            {
                return false;
            }

            return _success;
        }
        set { _success = value; }
    }

    public string code { get; set; }

    public string msg { get; set; }

    public string traceId { get; set; }

    public Data data { get; set; }
}

public class Data
{
    public string token { get; set; }
}