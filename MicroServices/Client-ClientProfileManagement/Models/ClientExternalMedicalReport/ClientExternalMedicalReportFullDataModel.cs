using SharedModels.Models;

namespace Client_ClientProfileManagement.Models.ClientExternalMedicalReport
{
    public class ClientExternalMedicalReportFullDataModel : BaseModel
    {
        public int? ClientId { get; set; }
        public string? File { get; set; }
    }
}
