 using Microsoft.AspNetCore.Identity;
using SharedModels.Entities;
namespace System_Authentication.Entities
{
    public class RoleGroup : IdentityRole<int>
    {
        public string? NameLocalized { set; get; } = "";
        public bool? IsDeleted { set; get; } = false;
        public string? DeleterName { set; get; } = "";
        public DateTime? DeletedDate { set; get; }

        public string? UpdaterName { set; get; } = "";
        public DateTime? UpdateDate { set; get; }

        public string? ModifierName { set; get; } = "";
        public DateTime? ModifiedDate { set; get; } = DateTime.Now;
    }
}
