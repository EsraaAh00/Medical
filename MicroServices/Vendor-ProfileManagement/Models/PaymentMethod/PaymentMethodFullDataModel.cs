using SharedModels.Models;
namespace Vendor_ProfileManagement.Models.PaymentMethod
{
    public class PaymentMethodFullDataModel : FullyBaseModel
    {
        public string? Icon { get; set; }
        public IFormFile? IconFile { get; set; }
    }
}
