using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Vendor_ProfileManagement.Entities
{
    public class VendorBusinessAreaAttraction : FullyBaseEnity
    {
        public virtual VendorBusiness? VendorBusiness { get; set; }
        [ForeignKey("VendorBusiness")]
        public int? VendorBusinessId { get; set; }
        public string? Description { get; set; }
        public string? DescriptionLocalized { get; set; }
        public string? DistanceUnit { get; set; }
        public int? DistanceUnitCode { get; set; }
        public double? DistanceValue { get; set; }
        public string? Image { get; set; }
    }
}
