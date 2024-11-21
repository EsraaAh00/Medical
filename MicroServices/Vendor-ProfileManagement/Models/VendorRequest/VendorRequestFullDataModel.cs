using SharedModels.Models;
namespace Vendor_ProfileManagement.Models.VendorRequest
{
    public class VendorRequestFullDataModel : FullyBaseModel
    {
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
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
        public string? BusinessName { get; set; }
        public string? BusinessNameLocalized { get; set; }
        public int? BusinessTypeCategoryId { get; set; }
        public string? BusinessTypeCategoryName { get; set; }
        public string? BusinessLandLine { get; set; }
        public string? BusinessLogo { get; set; }
        public IFormFile? BusinessLogoFile { get; set; }
        public string? BusinessCover { get; set; }
        public IFormFile? BusinessCoverFile { get; set; }
        public string? CommercialRecord { get; set; }
        public IFormFile? CommercialRecordFile { get; set; }
        public string? TaxCard { get; set; }
        public IFormFile? TaxCardFile { get; set; }
        public string? ValueAddedCard { get; set; }
        public IFormFile? ValueAddedCardFile { get; set; }
        public string? License { get; set; }
        public IFormFile? LicenseFile { get; set; }
        public string? PropertyContract { get; set; }
        public IFormFile? PropertyContractFile { get; set; }
        public string? PerformancePermission { get; set; }
        public IFormFile? PerformancePermissionFile { get; set; }
        public string? RequestStatus { get; set; }
        public int? RequestStatusCode { get; set; }
        public string? RejectionReason { get; set; }
        public int? RejectionReasonCode { get; set; }
        public string? RejectionFields { get; set; }
        public double? Lat { set; get; }
        public double? Lng { set; get; }
        public string? Address { set; get; }
        public string? AddressLocalized { set; get; }
        public int? RegionId { set; get; }
        public string? LandScreen { set; get; }
    }
}
