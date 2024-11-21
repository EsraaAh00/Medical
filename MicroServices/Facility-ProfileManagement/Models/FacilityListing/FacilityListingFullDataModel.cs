using SharedModels.Models;
namespace Facility_FacilityProfileManagement.Models.FacilityListing
{
    public class FacilityListingFullDataModel : FullyBaseModel
    {
        public int? FacilityId { get; set; }
        public string? Speciality { get; set; }
        public double? OfflineFair { get; set; }
        public double? OnlineFair { get; set; }
    }
}
