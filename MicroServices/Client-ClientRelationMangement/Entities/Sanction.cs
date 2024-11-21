using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Client_ClientRelationMangement.Entities
{
    public class Sanction : BaseModel
    {
        public virtual Complaint? Complaint { get; set; }
        [ForeignKey("Complaint")]
        public int? ComplaintId { get; set; }
        public int? ClientId { get; set; }
        public int? VendorBuissnesId { get; set; }
        public int? SanctionTypeId { get; set; }
        public string? SanctionType { get; set; }
        public bool? IsCompensation { get; set; }
        public double? Compensation { get; set; }
    }
}
