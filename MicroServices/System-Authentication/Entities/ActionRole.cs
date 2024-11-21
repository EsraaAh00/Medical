using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace System_Authentication.Entities
{
    public class ActionRole : FullyBaseEnity
    {
        public string? BaseName { get; set; }

        public virtual RoleGroup? RoleGroup { get; set; }
        [ForeignKey("RoleGroup")]
        public virtual int? RoleGroupId { get; set; }
    }
}
