using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Client_ClientProfileManagement.Entities
{
    public class ClientExternalMedicalReport : BaseModel
    {
        public virtual Client? Client { get; set; }
        [ForeignKey("Client")]
        public int? ClientId { get; set; }
        public string? File { get; set; }

    }
}
