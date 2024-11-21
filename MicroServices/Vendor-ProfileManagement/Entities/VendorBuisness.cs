using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Vendor_ProfileManagement.Entities
{
    public class VendorBusiness : FullyBaseEnity
    {
        public virtual Vendor? Vendor { get; set; }
        [ForeignKey("Vendor")]
        public int? VendorId { get; set; }
        public virtual BusinessTypeCategory? BusinessTypeCategory { get; set; }
        [ForeignKey("BusinessTypeCategory")]
        public int? BusinessTypeCategoryId { get; set; }
        public string? LandLine { get; set; }
        public double? LoactionLatitude { get; set; }
        public double? LoactionLongitude { get; set; }
        public string? Logo { get; set; }
        public string? Cover { get; set; }
        public string? BusinessStatus { get; set; }
        public int? BusinessStatusCode { get; set; }
    }
}
