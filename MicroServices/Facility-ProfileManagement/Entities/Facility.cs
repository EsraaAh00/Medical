using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Facility_FacilityProfileManagement.Entities
{
    public class Facility : FullyBaseEnity
    {
        public int? UserId { get; set; }
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
        public string? Country { set; get; }
        public double? CoveredArea { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string? State { get; set; }
        public int? StateCode { get; set; }
    }
}
