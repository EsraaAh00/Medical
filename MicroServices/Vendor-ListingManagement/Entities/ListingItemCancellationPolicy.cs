using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vendor_ListingManagement.Entities
{
    public class ListingItemCancellationPolicy : BaseModel
    {
        public virtual ListingItem? ListingItem { get; set; }
        [ForeignKey("ListingItem")]
        public int? ListingItemId { get; set; }
        public bool? IsCancellation { get; set; }
        public int? CancellableUpTo { get; set; }
        public bool? IsRefundable { get; set; }
        public decimal? RefundablePercentge { get; set; }
    }
}
