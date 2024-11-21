using SharedModels.Models;
namespace Vendor_ProfileManagement.Models.Facility
{
    public class FacilityFullDataModel : FullyBaseModel
    {
        public string? Icon { get; set; }
        public IFormFile? IconFile { get; set; }
    }
}
