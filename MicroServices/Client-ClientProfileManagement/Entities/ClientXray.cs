using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Client_ClientProfileManagement.Entities
{
    public class ClientXray : BaseModel
    {
        public virtual Client? Client { get; set; }
        [ForeignKey("Client")]
        public int? ClientId { get; set; }
        public int? FacilityId { get; set; }
        public string? Facility { get; set; }
        public string? File { get; set; }
    }
}
