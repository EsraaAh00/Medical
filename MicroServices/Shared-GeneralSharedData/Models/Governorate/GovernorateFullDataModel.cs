using SharedModels.Models;
namespace Shared_GeneralSharedData.Models.Governorate
{
    public class GovernorateFullDataModel : FullyBaseModel
    {
        public int? CountryId { get; set; }
        public string? CountryName { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public string? NameKays { get; set; }
    }
}
