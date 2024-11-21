using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Client_ClientRelationMangement.Entities
{
    public class ComplaintAction : BaseModel
    {
        public virtual Complaint? Complaint { get; set; }
        [ForeignKey("Complaint")]
        public int? ComplaintId { get; set; }
        public int? ActionId { get; set; }
        public string? Action { get; set; }
    }
}
