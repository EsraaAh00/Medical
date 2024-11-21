using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Vendor_ListingManagement.Entities
{
    public class ListingItemDetailSetting : FullyBaseEnity
    {
        public virtual ItemCategories? ItemCategory { get; set; }
        [ForeignKey("ItemCategory")]
        public int? ItemCategoryId { get; set; }
        public int? Code { get; set; }
        public string? Type { get; set; }
        public int? TypeCode { get; set; }
        public string? Vector { get; set; }
        public int? Priority { get; set; }
    }
}
