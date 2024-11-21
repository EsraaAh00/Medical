using SharedModels.Models;
namespace System_Authentication.Models.Rank
{
    public class RankFullDataModel : FullyBaseModel
    {
        public int? Value { get; set; }
        public string? LandScreen { get; set; }
        public string? BaseName { get; set; }
        public bool? SignupRank { get; set; }
    }
}
