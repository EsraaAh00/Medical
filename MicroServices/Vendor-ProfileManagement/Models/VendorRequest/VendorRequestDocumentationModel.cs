using SharedModels.Models;
namespace Vendor_ProfileManagement.Models.VendorRequest
{
    public class VendorRequestDocumentationModel 
    {
        
        public IFormFile? CommercialRecordFile { get; set; }
        public string? CommercialRecord { get; set; }
        public IFormFile? TaxCardFile { get; set; }
        public string? TaxCard { get; set; }
        public IFormFile? ValueAddedCardFile { get; set; }
        public string? ValueAddedCard { get; set; }
        public IFormFile? LicenseFile { get; set; }
        public string? License{ get; set; }
        public IFormFile? PropertyContractFile { get; set; }
        public string? PropertyContract { get; set; }
        public IFormFile? PerformancePermissionFile { get; set; }
        public string? PerformancePermission { get; set; }
       
    }
}
