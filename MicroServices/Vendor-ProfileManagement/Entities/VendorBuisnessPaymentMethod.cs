using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Vendor_ProfileManagement.Entities
{
    public class VendorBusinessPaymentMethod : FullyBaseEnity
    {
        public virtual VendorBusiness? VendorBusiness { get; set; }
        [ForeignKey("VendorBusiness")]
        public int? VendorBusinessId { get; set; }
        public virtual PaymentMethod? PaymentMethod { get; set; }
        [ForeignKey("PaymentMethod")]
        public int? PaymentMethodId { get; set; }
    }
}
