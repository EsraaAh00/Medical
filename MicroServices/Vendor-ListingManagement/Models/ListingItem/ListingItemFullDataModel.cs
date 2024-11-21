using SharedModels.Models;
using Vendor_ListingManagement.Models.ListingItemDetail;

namespace Vendor_ListingManagement.Models.ListingItem
{
    public class ListingItemFullDataModel : FullyBaseModel
    {
        public ListingItemFullDataModel() {
            Details = new List<ListingItemDetailFullDataModel>();
        }
        public int? ItemSubCategoriesId { get; set; }
        public string? ItemSubCategoriesName { get; set; }
        public string? Description { get; set; }
        public string? DescriptionLocalized { get; set; }
        public int? VendorBusinessId { get; set; }
        public string? VendorBusinessName { get; set; }
        public int? maxticketnumber { get; set; }
        public bool? IsOccupied { get; set; }
        public DateTime? OccupiedFrom { get; set; }
        public DateTime? OccupiedTo { get; set; }
        public string? State { get; set; }
        public int? StateCode { get; set; }
        public List<ListingItemDetailFullDataModel>? Details { get; set; }
    }
}
