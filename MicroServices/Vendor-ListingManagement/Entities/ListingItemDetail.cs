using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Vendor_ListingManagement.Entities
{
    public class ListingItemDetail : BaseModel
    {
        public virtual ListingItem? ListingItem { get; set; }
        [ForeignKey("ListingItem")]
        public int? ListingItemId { get; set; }
        public virtual ListingItemDetailSetting? ListingItemDetailSetting { get; set; }
        [ForeignKey("ListingItemDetailSetting")]
        public int? ListingItemDetailSettingId { get; set; }
        public string? Value { get; set; }
        public string? ValueLocalized { get; set; }
    }
}
