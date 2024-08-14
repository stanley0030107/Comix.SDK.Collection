namespace Comix.Cos.Models.EventModels.CosMallBaseData;

public class CosCategoryDto
{
    public long CategoryId { get; set; }
    public string CategoryCode { get; set; }
    public string Name { get; set; }
    public long DisplaySequence { get; set; }
    public string Meta_Title { get; set; }
    public string Meta_Description { get; set; }
    public string Meta_Keywords { get; set; }
    public string Description { get; set; }
    public long ParentCategoryId { get; set; }
    public string ParentCategoryCode { get; set; }
    public int Depth { get; set; }
    public string Path { get; set; }
    public string ImageUrl { get; set; }
    public string Theme { get; set; }
    public bool HasChildren { get; set; }
    public string SeoUrl { get; set; }
    public string SeoImageAlt { get; set; }
    public string SeoImageTitle { get; set; }
    public int Status { get; set; }
    public string Remark { get; set; }
    public string CreatedBy { get; set; }
    public bool IsSingleBuy { get; set; }
    public int ProductCounts { get; set; }
    public long SupplierId { get; set; }
}