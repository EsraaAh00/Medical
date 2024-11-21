using SharedModels.Models;
namespace System_Authentication.Models.UserActionRole
{
    public class UserActionRoleFullDataModel : BaseModel
    {
        public int? ActionRoleId { get; set; }
        public string? ActionRoleName { get; set; }
        public int? UserId { get; set; }
    }
}
