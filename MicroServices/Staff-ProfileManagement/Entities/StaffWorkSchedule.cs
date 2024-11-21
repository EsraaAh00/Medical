using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Staff_StaffProfileManagement.Entities
{
    public class StaffWorkSchedule : BaseModel
    {
        public virtual Staff? Staff { get; set; }
        [ForeignKey("Staff")]
        public int? StaffId { get; set; }
        public string? WorkDay { get; set; }
        public string? WorkStartTime { get; set; }
        public string? WorkEndTime { get; set; }
        public double? CoveredArea { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
