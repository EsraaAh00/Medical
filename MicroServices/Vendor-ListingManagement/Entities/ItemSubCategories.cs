using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Vendor_ListingManagement.Entities
{
    public class ItemSubCategories : FullyBaseEnity
    {
        public virtual ItemCategories? ItemCategories { get; set; }
        [ForeignKey("ItemCategories")]
        public int? ItemCategoriesId { get; set; }
    }
}
