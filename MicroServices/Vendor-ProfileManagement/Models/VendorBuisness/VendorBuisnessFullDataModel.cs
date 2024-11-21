using SharedModels.Models;
namespace Vendor_ProfileManagement.Models.VendorBusiness
{
    public class VendorBusinessFullDataModel : FullyBaseModel
    {
        public int? VendorId { get; set; }
        public string? VendorName { get; set; }
        public int? BusinessTypeCategoryId { get; set; }
        public string? BusinessTypeCategoryName { get; set; }
        public string? LandLine { get; set; }
        public double? LoactionLatitude { get; set; }
        public double? LoactionLongitude { get; set; }
        public string? Logo { get; set; }
        public IFormFile? LogoFile { get; set; }
        public string? Cover { get; set; }
        public IFormFile? CoverFile { get; set; }
        public string? BusinessStatus { get; set; }
        public int? BusinessStatusCode { get; set; }
    }
}
