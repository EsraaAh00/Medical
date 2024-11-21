using SharedModels.Models;
namespace Vendor_ProfileManagement.Models.BusinessTypeFeature
{
    public class BusinessTypeFeatureFullDataModel : BaseModel
    {
        public int? BusinessTypeId { get; set; }
        public string? BusinessTypeName { get; set; }
        public int? FeatureId { get; set; }
        public string? FeatureName { get; set; }
    }
}
