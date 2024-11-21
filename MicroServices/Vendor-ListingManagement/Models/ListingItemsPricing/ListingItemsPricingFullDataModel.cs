using SharedModels.Models;
namespace Vendor_ListingManagement.Models.ListingItemsPricing
{
    public class ListingItemsPricingFullDataModel : BaseModel
    {
        public int? ListingItemId { get; set; }
        public bool? IsPackage { get; set; }
        public int? DestinationId { get; set; }
        public string? Destination { get; set; }
        public string? DestinationLocalized { get; set; }
        public string? ListingItemName { get; set; }
        public double? BaseAmount { get; set; }
        public int? BaseAppliedNumber { get; set; }
        public double? PricePerextraPerson { get; set; }
        public string? ChargeFrequencyType { get; set; }
        public int? ChargeFrequencyTypeCode { get; set; }
        public int? ChargeFrequency { get; set; }
        public string? ApplicableType { get; set; }
        public int? ApplicableTypeCode { get; set; }
        public int? ApplicableTypeNumber { get; set; }
    }
}
