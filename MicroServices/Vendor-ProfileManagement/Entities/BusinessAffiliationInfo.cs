using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Vendor_ProfileManagement.Entities
{
    public class BusinessAffiliationInfo : FullyBaseEnity
    {
        public virtual VendorBusiness? VendorBusiness { get; set; }
        [ForeignKey("VendorBusiness")]
        public int? VendorBusinessId { get; set; }
        public string? Provider { get; set; }
        public string? AwardPhoto { get; set; }
    }
}
