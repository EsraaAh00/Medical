using SharedModels.Models;
namespace Vendor_ListingManagement.Models.ListingItemPhotos
{
    public class ListingItemPhotosFullDataModel : BaseModel
    {
        public int? ListingItemId { get; set; }
        public string? ListingItemName { get; set; }
        public string? Image { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
