using SharedModels.Models;
namespace Vendor_ProfileManagement.Models.BusinessAffiliationInfo
{
    public class BusinessAffiliationInfoFullDataModel : FullyBaseModel
    {
        public int? VendorBusinessId { get; set; }
        public string? VendorBusinessName { get; set; }
        public string? Provider { get; set; }
        public string? AwardPhoto { get; set; }
        public IFormFile? AwardPhotoFile { get; set; }
    }
}
