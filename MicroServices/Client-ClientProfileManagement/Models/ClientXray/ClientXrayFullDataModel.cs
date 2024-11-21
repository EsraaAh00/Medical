using SharedModels.Models;

namespace Client_ClientProfileManagement.Models.ClientXray
{
    public class ClientXrayFullDataModel : BaseModel
    {
        public int? ClientId { get; set; }
        public int? FacilityId { get; set; }
        public string? Facility { get; set; }
        public string? File { get; set; }
    }
}
