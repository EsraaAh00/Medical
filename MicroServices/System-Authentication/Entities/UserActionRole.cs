using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace System_Authentication.Entities
{
    public class UserActionRole : BaseModel
    {
        public virtual ActionRole? ActionRole { get; set; }
        [ForeignKey("ActionRole")]
        public int? ActionRoleId { get; set; }
        public virtual User? User { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
    }
}
