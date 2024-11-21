using SharedModels.Models;
namespace Shared_GeneralSharedData.Models.Region
{
    public class RegionFullDataModel : FullyBaseModel
    {
        public int? GovernorateId { get; set; }
        public string? GovernorateName { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public string? NameKayes { get; set; }
    }
}
