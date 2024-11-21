using SharedModels.Models;
namespace Vendor_ProfileManagement.Models.VendorBusinessPaymentMethod
{
    public class VendorBusinessPaymentMethodFullDataModel : FullyBaseModel
    {
        public int? VendorBusinessId { get; set; }
        public string? VendorBusinessName { get; set; }
        public int? PaymentMethodId { get; set; }
        public string? PaymentMethodName { get; set; }
    }
}
