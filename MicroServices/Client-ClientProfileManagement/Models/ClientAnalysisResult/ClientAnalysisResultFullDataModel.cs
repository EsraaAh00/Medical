using SharedModels.Models;

namespace Client_ClientProfileManagement.Models.ClientAnalysisResult
{
    public class ClientAnalysisResultFullDataModel : BaseModel
    {
        public int? ClientId { get; set; }
        public int? FacilityId { get; set; }
        public string? Facility { get; set; }
        public string? File { get; set; }
    }
}
