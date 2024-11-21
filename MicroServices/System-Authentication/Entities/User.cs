using Microsoft.AspNetCore.Identity;
using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace System_Authentication.Entities
{
    public class User : IdentityUser<int>
    {
        public string? Name { set; get; } = "";
        public bool? IsDeleted { set; get; } = false;
        public string? DeleterName { set; get; } = "";
        public DateTime? DeletedDate { set; get; }
        public string? UpdaterName { set; get; } = "";
        public DateTime? UpdateDate { set; get; }
        public string? ModifierName { set; get; } = "";
        public DateTime? ModifiedDate { set; get; } = DateTime.Now;

        [ForeignKey("UserRank")]
        public virtual int? UserRankId { set; get; }
        public virtual Rank? UserRank { set; get; }

    }
}
