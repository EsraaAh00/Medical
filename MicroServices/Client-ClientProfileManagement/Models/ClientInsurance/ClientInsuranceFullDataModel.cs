using SharedModels.Models;

namespace Client_ClientProfileManagement.Models.ClientInsurance
{
    public class ClientInsuranceFullDataModel : BaseModel
    {
        public int? ClientId { get; set; }
        public string? File { get; set; }
    }
}
