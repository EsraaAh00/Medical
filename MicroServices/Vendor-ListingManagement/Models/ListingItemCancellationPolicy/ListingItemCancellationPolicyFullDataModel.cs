using SharedModels.Models;

namespace Vendor_ListingManagement.Models.ListingItemCancellationPolicy
{
    public class ListingItemCancellationPolicyFullDataModel : BaseModel
    {
        public int? ListingItemId { get; set; }
        public bool? IsCancellation { get; set; }
        public bool? IsRefundable { get; set; }
        public decimal? RefundableAmount { get; set; }
    }
}
