using SharedModels.Models;
namespace Staff_StaffProfileManagement.Models.StaffExperience
{
    public class StaffExperienceFullDataModel : FullyBaseModel
    {
        public int? StaffId { get; set; }
        public string? ExperienceDetail { get; set; }
    }
}
