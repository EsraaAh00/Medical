using SharedModels.Models;
namespace Vendor_ProfileManagement.Models.VendorRequest
{
    public class VendorAccountDataModel 
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameLocalized { get; set; }
        public string? ManagerFirstName { get; set; }
        public string? ManagerFirstNameLocalized { get; set; }
        public string? ManagerLastName { get; set; }
        public string? ManagerLastNameLocalized { get; set; }
        public string? ManagerNationalIdFront { get; set; }
        public IFormFile? ManagerNationalIdFrontFile { get; set; }
        public string? ManagerNationalIdBack { get; set; }
        public IFormFile? ManagerNationalIdBackFile { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? Logo { get; set; }
        public IFormFile? LogoFile { get; set; }
        public string? Cover { get; set; }
        public IFormFile? CoverFile { get; set; }
        public string? Language { get; set; }
        public string? DeviceToken   { get; set; }
    }
    
}
