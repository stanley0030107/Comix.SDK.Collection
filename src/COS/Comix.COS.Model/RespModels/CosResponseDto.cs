namespace Comix.COS.Model.RespModels
{
    public class CosResponseDto<T>
    {
        public bool isOk { get; set; }
        public string errCode { get; set; }
        public string msg { get; set; }
        public T resultList { get; set; }
    }

    public class CosResponse2Dto<T>
    {
        public string code { get; set; }
        public string msg { get; set; }
        public T res { get; set; }
    }
}