using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Client_ClientProfileManagement.Entities
{
    public class ClientPrescribtion : BaseModel
    {
        public virtual Client? Client { get; set; }
        [ForeignKey("Client")]
        public int? ClientId { get; set; }
        public int? StaffId { get; set; }
        public string? Staff { get; set; }
        public string? File { get; set; }
    }
}
