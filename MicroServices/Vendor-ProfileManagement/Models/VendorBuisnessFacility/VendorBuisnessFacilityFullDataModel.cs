using SharedModels.Models;
namespace Vendor_ProfileManagement.Models.VendorBusinessFacility
{
    public class VendorBusinessFacilityFullDataModel : BaseModel
    {
        public int? VendorBusinessId { get; set; }
        public string? VendorBusinessName { get; set; }
        public int? FacilityId { get; set; }
        public string? FacilityName { get; set; }
    }
}
