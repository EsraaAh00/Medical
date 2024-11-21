using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Vendor_ProfileManagement.Entities
{
    public class VendorBusinessFeature : BaseModel
    {
        public virtual VendorBusiness? VendorBusiness { get; set; }
        [ForeignKey("VendorBusiness")]
        public int? VendorBusinessId { get; set; }
        public virtual Feature? Feature { get; set; }
        [ForeignKey("Feature")]
        public int? FeatureId { get; set; }
    }
}
