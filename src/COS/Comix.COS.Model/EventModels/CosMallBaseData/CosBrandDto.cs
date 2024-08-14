namespace Comix.COS.Model.EventModels.CosMallBaseData
{
    public class CosBrandDto
    {
        public long BrandId { get; set; }
        public string BrandCode { get; set; }
        public string BrandName { get; set; }
        public string BrandSpell { get; set; }
        public string Meta_Description { get; set; }
        public string metaKeywords { get; set; }
        public string Logo { get; set; }
        public string CompanyUrl { get; set; }
        public string Description { get; set; }
        public int DisplaySequence { get; set; }
        public string Theme { get; set; }
        public string Quanpin { get; set; }
        public string FirstABC { get; set; }
        public int Status { get; set; }
        public bool IsHomePageShow { get; set; }
        public int HomePageShowSequence { get; set; }
        public string SapBrandCode { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}