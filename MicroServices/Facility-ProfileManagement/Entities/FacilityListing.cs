using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Facility_FacilityProfileManagement.Entities
{
    public class FacilityListing : FullyBaseEnity
    {
        public virtual Facility? Facility { get; set; }
        [ForeignKey("Facility")]
        public int? FacilityId { get; set; }
        public string? Speciality { get; set; }
        public double? OfflineFair { get; set; }
        public double? OnlineFair { get; set; }
    }
}
