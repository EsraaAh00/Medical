using SharedModels.Models;
namespace Vendor_ProfileManagement.Models.VendorBusinessAreaAttraction
{
    public class VendorBusinessAreaAttractionFullDataModel : FullyBaseModel
    {
        public int? VendorBusinessId { get; set; }
        public string? VendorBusinessName { get; set; }
        public string? Description { get; set; }
        public string? DescriptionLocalized { get; set; }
        public string? DistanceUnit { get; set; }
        public int? DistanceUnitCode { get; set; }
        public double? DistanceValue { get; set; }
        public string? Image { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
