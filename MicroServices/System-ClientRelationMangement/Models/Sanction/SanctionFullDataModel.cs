using SharedModels.Models;

namespace System_ClientRelationMangement.Models.Sanction
{
    public class SanctionFullDataModel : BaseModel
    {
        public int? ComplaintId { get; set; }
        public int? ClientId { get; set; }
        public int? VendorBuissnesId { get; set; }
        public int? SanctionTypeId { get; set; }
        public string? SanctionType { get; set; }
        public bool? IsCompensation { get; set; }
        public double? Compensation { get; set; }
    }
}
