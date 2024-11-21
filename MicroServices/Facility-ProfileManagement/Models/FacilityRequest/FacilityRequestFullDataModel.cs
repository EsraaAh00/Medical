using SharedModels.Models;
namespace Facility_FacilityProfileManagement.Models.FacilityRequest
{
    public class FacilityRequestFullDataModel : FullyBaseModel
    {
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? Logo { get; set; }
        public string? About { get; set; }
        public string? AboutLocalized { get; set; }
        public string? LandLine { get; set; }
        public string? Address { set; get; }
        public string? AddressLocalized { set; get; }
        public string? FacilityType { get; set; }
        public string? CommercialRecordNumber { get; set; }
        public string? CommercialRecordAttachment { get; set; }
        public string? MinistryOfHealthlicenseNumber { get; set; }
        public string? MinistryOfHealthlicenseAttachment { get; set; }
        public int? CountryId { set; get; }
        public string? Country { set; get; }
        public double? CoveredArea { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string? RequestStatus { get; set; }
        public int? RequestStatusCode { get; set; }
        public string? RejectionReason { get; set; }
    }
}
