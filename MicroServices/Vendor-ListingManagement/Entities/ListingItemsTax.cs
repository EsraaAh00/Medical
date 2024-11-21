using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Vendor_ListingManagement.Entities
{
    public class ListingItemsTax : BaseModel
    {
        public virtual ListingItem? ListingItem { get; set; }
        [ForeignKey("ListingItem")]
        public int? ListingItemId { get; set; }
        public double? TaxAmount { get; set; }
        public bool? Percentege { get; set; }
        public string? State { get; set; }
        public int? StateCode { get; set; }

    }
}
