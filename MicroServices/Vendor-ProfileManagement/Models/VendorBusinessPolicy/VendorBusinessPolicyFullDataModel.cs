using SharedModels.Models;
namespace Vendor_ProfileManagement.Models.VendorBusinessPolicy
{
    public class VendorBusinessPolicyFullDataModel : BaseModel
    {
        public int? VendorBusinessId { get; set; }
        public string? VendorBusinessName { get; set; }
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
