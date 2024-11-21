using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Staff_StaffProfileManagement.Entities
{
    public class StaffExperience : FullyBaseEnity
    {
        public virtual Staff? Staff { get; set; }
        [ForeignKey("Staff")]
        public int? StaffId { get; set; }
    }
}
