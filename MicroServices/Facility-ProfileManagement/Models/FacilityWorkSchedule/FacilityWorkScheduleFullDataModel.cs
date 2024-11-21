using SharedModels.Models;
namespace Facility_FacilityProfileManagement.Models.FacilityWorkSchedule
{
    public class FacilityWorkScheduleFullDataModel : FullyBaseModel
    {
        public int? FacilityId { get; set; }
        public string? WorkDay { get; set; }
        public string? WorkStartTime { get; set; }
        public string? WorkEndTime { get; set; }
    }
}
