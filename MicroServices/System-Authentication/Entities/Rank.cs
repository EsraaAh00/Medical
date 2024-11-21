using SharedModels.Entities;
namespace System_Authentication.Entities
{
    public class Rank : FullyBaseEnity
    {
        public int? Value { get; set; }
        public string? LandScreen { get; set; } 
        public string? BaseName { get; set; }
        public bool? SignupRank { get; set; }
    }
}
