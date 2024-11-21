using SharedModels.Models;
namespace Vendor_ProfileManagement.Models.VendorBusinessFeature
{
    public class VendorBusinessFeatureFullDataModel : BaseModel
    {
        public int? VendorBusinessId { get; set; }
        public string? VendorBusinessName { get; set; }
        public int? FeatureId { get; set; }
        public string? FeatureName { get; set; }
    }
}
