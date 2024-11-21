using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Facility_FacilityProfileManagement.Entities
{
    public class FacilityWorkSchedule : BaseModel
    {
        public virtual Facility? Facility { get; set; }
        [ForeignKey("Facility")]
        public int? FacilityId { get; set; }
        public string? WorkDay { get; set; }
        public string? WorkStartTime { get; set; }
        public string? WorkEndTime { get; set; }
    }
}
