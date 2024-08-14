namespace Comix.Cos.Models.EventModels.CosMallBaseData;

public class CosQualificationDto
{
    public string CertificateType { get; set; }
    public DateTime CreatDate { get; set; }
    public string Creater { get; set; }
    public DateTime EditDate { get; set; }
    public string Editer { get; set; }
    public int OrderNumber { get; set; }
    public string SKU { get; set; }
    public string SKUName { get; set; }
    public List<CosQualificationSYSFileDto> sYSFileinfoList { get; set; }
}