using SharedModels.Models.Filter;
namespace Vendor_ListingManagement.Models.ListingItemsPricing
{
    public class ListingItemsPricingFilter : PagedFilterModel
    {
        public int? ListingItemId { get; set; }
    }
}