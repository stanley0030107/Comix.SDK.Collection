namespace Comix.Cos.Models.EventModels.CosMallBaseData;

public class CosBaseDataBody
{
    public CosBrandDto? Brand { get; set; }
    public string SupplierCode { get; set; }
    public CosCategoryDto? Category { get; set; }
    public List<CosCategoryDto>? CategoryList { get; set; }
    public List<string> CategoryBrands { get; set; }
}