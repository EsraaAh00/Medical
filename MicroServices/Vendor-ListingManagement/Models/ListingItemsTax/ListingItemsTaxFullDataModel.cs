using SharedModels.Models;
namespace Vendor_ListingManagement.Models.ListingItemsTax
{
    public class ListingItemsTaxFullDataModel : BaseModel
    {
        public int? ListingItemId { get; set; }
        public string? ListingItemName { get; set; }
        public double? TaxAmount { get; set; }
        public bool? Percentege { get; set; }
        public string? State { get; set; }
        public int? StateCode { get; set; }
    }
}
