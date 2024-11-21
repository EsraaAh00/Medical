using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Vendor_ProfileManagement.Entities
{
    public class VendorRequest : FullyBaseEnity
    {
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? Logo { get; set; }
        public string? Cover { get; set; }
        public string? ManagerFirstName { get; set; }
        public string? ManagerFirstNameLocalized { get; set; }
        public string? ManagerLastName { get; set; }
        public string? ManagerLastNameLocalized { get; set; }
        public string? ManagerNationalIdFront { get; set; }
        public string? ManagerNationalIdBack { get; set; }
        public string? BusinessName { get; set; }
        public string? BusinessNameLocalized { get; set; }
        public virtual BusinessTypeCategory? BusinessTypeCategory { get; set; }
        [ForeignKey("BusinessTypeCategory")]
        public int? BusinessTypeCategoryId { get; set; }
        public string? BusinessLandLine { get; set; }
        public string? BusinessLogo { get; set; }
        public string? BusinessCover { get; set; }
        public string? CommercialRecord { get; set; }
        public string? TaxCard { get; set; }
        public string? ValueAddedCard { get; set; }
        public string? License { get; set; }
        public string? PropertyContract { get; set; }
        public string? PerformancePermission { get; set; }
        public string? RequestStatus { get; set; }
        public int? RequestStatusCode { get; set; }
        public string? RejectionReason { get; set; }
        public int? RejectionReasonCode { get; set; }
        public string? RejectionFields { get; set; }
        public int? CountryId { set; get; }
        public string? Country { set; get; }
        public int? RegionId { set; get; }
        public string? Region { set; get; }
        public double? Lat { set; get; }
        public double? Lng { set; get; }
        public string? Address { set; get; }
        public string? AddressLocalized { set; get; }
        public string? LandScreen { set; get;}
    }
}
