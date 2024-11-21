using SharedModels.Models;
namespace System_Authentication.Models.UserRoleGroup
{
    public class UserRoleGroupFullDataModel : BaseModel
    {
        public int? UserId { get; set; }
        public int? RoleGroupId { get; set; }
    }
}
