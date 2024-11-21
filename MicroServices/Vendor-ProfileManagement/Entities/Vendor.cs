using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Vendor_ProfileManagement.Entities
{
    public class Vendor : FullyBaseEnity
    {
        public int? UserID { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Logo { get; set; }
        public string? Cover { get; set; }
        public string? ManagerFirstName { get; set; }
        public string? ManagerFirstNameLocalized { get; set; }
        public string? ManagerLastName { get; set; }
        public string? ManagerLastNameLocalized { get; set; }
        public string? ManagerNationalIdFront { get; set; }
        public string? ManagerNationalIdBack { get; set; }
        public virtual SubscriptionPlan? SubscriptionPlan { get; set; }
        [ForeignKey("SubscriptionPlan")]
        public int? SubscriptionPlanId { get; set; }
        public virtual MarketingPlan? MarketingPlan { get; set; }
        [ForeignKey("MarketingPlan")]
        public int? MarketingPlanId { get; set; }
        public virtual DiscountPlan? DiscountPlan { get; set; }
        [ForeignKey("DiscountPlan")]
        public int? DiscountPlanId { get; set; }
        public string? State { get; set; }
        public int? StateCode { get; set; }
    }
}
