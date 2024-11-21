using SharedModels.Models;
namespace System_Authentication.Models.ActionRole
{
    public class ActionRoleFullDataModel : FullyBaseModel
    {
        public string? BaseName { get; set; }
        public int? RoleGroupId { get; set; }
        public string? RoleGroupName { get; set; }
    }
}
