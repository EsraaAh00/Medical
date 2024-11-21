using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Vendor_ListingManagement.Entities
{
    public class ListingItemPhotos : BaseModel
    {
        public virtual ListingItem? ListingItem { get; set; }
        [ForeignKey("ListingItem")]
        public int? ListingItemId { get; set; }
        public string? Image { get; set; }
    }
}
