using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Staff_StaffProfileManagement.Entities
{
    public class StaffAward : FullyBaseEnity
    {
        public virtual Staff? Staff { get; set; }
        [ForeignKey("Staff")]
        public int? StaffId { get; set; }
        public string? Award { get; set; }
    }
}
