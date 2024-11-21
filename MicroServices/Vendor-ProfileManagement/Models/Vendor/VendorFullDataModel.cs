using SharedModels.Models;
namespace Vendor_ProfileManagement.Models.Vendor
{
    public class VendorFullDataModel : FullyBaseModel
    {
        public int? UserId { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Logo { get; set; }
        public IFormFile? LogoFile { get; set; }
        public string? Cover { get; set; }
        public IFormFile? CoverFile { get; set; }
        public string? ManagerFirstName { get; set; }
        public string? ManagerFirstNameLocalized { get; set; }
        public string? ManagerLastName { get; set; }
        public string? ManagerLastNameLocalized { get; set; }
        public string? ManagerNationalIdFront { get; set; }
        public IFormFile? ManagerNationalIdFrontFile { get; set; }
        public string? ManagerNationalIdBack { get; set; }
        public IFormFile? ManagerNationalIdBackFile { get; set; }
        public int? SubscriptionPlanId { get; set; }
        public string? SubscriptionPlanName { get; set; }
        public int? MarketingPlanId { get; set; }
        public string? MarketingPlanName { get; set; }
        public int? DiscountPlanId { get; set; }
        public string? DiscountPlanName { get; set; }
        public string? State { get; set; }
        public int? StateCode { get; set; }
    }
}
