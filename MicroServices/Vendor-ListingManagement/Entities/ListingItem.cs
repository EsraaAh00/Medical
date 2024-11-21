using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Vendor_ListingManagement.Entities
{
    public class ListingItem : FullyBaseEnity
    {
        public virtual ItemSubCategories? ItemSubCategories { get; set; }
        [ForeignKey("ItemSubCategories")]
        public int? ItemSubCategoriesId { get; set; }
        public string? Description { get; set; }
        public string? DescriptionLocalized { get; set; }
        public int? VendorBusinessId { get; set; }
        public  int? maxticketnumber {  get; set; }
        public bool? IsOccupied { get; set; }
        public DateTime? OccupiedFrom { get; set; }
        public DateTime? OccupiedTo { get; set; }
        public int? StateCode { get; set; }
        public string? State { get; set; }
        public virtual List<ListingItemDetail?> ?Details { get; set; }

    }
}
