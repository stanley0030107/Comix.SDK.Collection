using System.Collections.Generic;

namespace Comix.COS.Model.EventModels.CosMallProduct
{
    public class CosQualificationBody
    {
        public List<CosQualificationDto> qualificationList { get; set; }
        public string sku { get; set; }
        public string messageId { get; set; }
    }
}