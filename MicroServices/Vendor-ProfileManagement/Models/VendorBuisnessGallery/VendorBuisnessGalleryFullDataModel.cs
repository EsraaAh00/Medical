using SharedModels.Models;
namespace Vendor_ProfileManagement.Models.VendorBusinessGallery
{
    public class VendorBusinessGalleryFullDataModel : BaseModel
    {
        public int? VendorBusinessId { get; set; }
        public string? VendorBusinessName { get; set; }
        public string? GalleryImage { get; set; }
        public IFormFile? GalleryImageFile { get; set; }
    }
}
