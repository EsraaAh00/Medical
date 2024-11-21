using SharedModels.Models;
namespace Staff_StaffProfileManagement.Models.StaffWorkSchedule
{
    public class StaffWorkScheduleFullDataModel : FullyBaseModel
    {
        public int? StaffId { get; set; }
        public string? WorkDay { get; set; }
        public string? WorkStartTime { get; set; }
        public string? WorkEndTime { get; set; }
        public double? CoveredArea { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
