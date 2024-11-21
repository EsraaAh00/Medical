using SharedModels.Models;
namespace Vendor_ProfileManagement.Models.Feature
{
    public class FeatureFullDataModel : FullyBaseModel
    {
        public string? Icon { get; set; }
        public IFormFile? IconFile { get; set; }
    }
}
