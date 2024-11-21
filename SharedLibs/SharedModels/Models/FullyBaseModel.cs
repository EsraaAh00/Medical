using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedModels.Models
{
    public class FullyBaseModel
    {
        public int Id { set; get; }
        public string? NameLocalized { set; get; } = "";
        public string? Name { set; get; } = "";
        public bool? IsDeleted { set; get; } = false;
        public string? DeleterName { set; get; } = "";
        public DateTime? DeletedDate { set; get; }

        public string? UpdaterName { set; get; } = "";
        public DateTime? UpdateDate { set; get; }

        public string? ModifierName { set; get; } = "";
        public DateTime? ModifiedDate { set; get; } = DateTime.Now;
    }
}
