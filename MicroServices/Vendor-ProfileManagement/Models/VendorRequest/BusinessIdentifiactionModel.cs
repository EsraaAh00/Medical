using SharedModels.Models;
namespace Vendor_ProfileManagement.Models.VendorRequest
{
    public class BusinessIdentifiactionModel : BaseModel
    {
        
        public string? BusinessName { get; set; }
        public string? BusinessNameLocalized { get; set; }
        public int? BusinessTypeCategoryId { get; set; }
        public string? BusinessLandLine { get; set; }
        public string? BusinessLogo { get; set; }
        public IFormFile? BusinessLogoFile { get; set; }
        public string? BusinessCover { get; set; }
        public IFormFile? BusinessCoverFile { get; set; }
      
    }
}
