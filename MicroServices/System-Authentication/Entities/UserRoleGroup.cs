using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace System_Authentication.Entities
{
    public class UserRoleGroup : BaseModel
    {
        public virtual User? User { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
        public virtual RoleGroup? RoleGroup { get; set; }
        [ForeignKey("RoleGroup")]
        public int? RoleGroupId { get; set; }
    }
}
