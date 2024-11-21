using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Vendor_ProfileManagement.Entities
{
    public class VendorBusinessFacility : BaseModel
    {
        public virtual VendorBusiness? VendorBusiness { get; set; }
        [ForeignKey("VendorBusiness")]
        public int? VendorBusinessId { get; set; }
        public virtual Facility? Facility { get; set; }
        [ForeignKey("Facility")]
        public int? FacilityId { get; set; }
    }
}
