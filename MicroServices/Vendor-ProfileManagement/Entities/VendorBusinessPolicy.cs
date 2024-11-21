using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Vendor_ProfileManagement.Entities
{
    public class VendorBusinessPolicy : BaseModel
    {
        public virtual VendorBusiness? VendorBusiness { get; set; }
        [ForeignKey("VendorBusiness")]
        public int? VendorBusinessId { get; set; }
        public int? TotalGuestCount { get; set; }
        public string? AcceptedGuestType { get; set; }
        public int? MinGuestAge { get; set; }
        public double? NoShowPenalty { get; set; }
        public double? PetsAllowedFee { get; set; }
        public bool? PetsAllowed { get; set; }
        public bool? CancelPolicy { get; set; }
        public string? Policy { get; set; }
        public TimeSpan? CheckOut { get; set; }
        public TimeSpan? CheckIn { get; set; }
    }
}
