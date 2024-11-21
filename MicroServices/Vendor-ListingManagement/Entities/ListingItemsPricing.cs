using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Vendor_ListingManagement.Entities
{
    public class ListingItemsPricing : BaseModel
    {
        public virtual ListingItem? ListingItem { get; set; }
        [ForeignKey("ListingItem")]
        public int? ListingItemId { get; set; }
        public bool? IsPackage { get; set; }
        public int? DestinationId { get; set; }
        public string? Destination { get; set; }
        public string? DestinationLocalized { get; set; }
        public double? BaseAmount { get; set; }
        public int? BaseAppliedNumber { get; set; }
        public double? PricePerextraPerson { get; set; }
        public int? ChargeFrequencyTypeCode { get; set; }
        public string? ChargeFrequencyType { get; set; }
        public int? ChargeFrequency { get; set; }
        public int? ApplicableTypeCode { get; set; }
        public string? ApplicableType { get; set; }
        public int? ApplicableTypeNumber { get; set; }
    }
}
