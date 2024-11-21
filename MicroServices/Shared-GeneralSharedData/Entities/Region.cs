using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Shared_GeneralSharedData.Entities
{
    public class Region : FullyBaseEnity
    {
        public virtual Governorate? Governorate { get; set; }
        [ForeignKey("Governorate")]
        public int? GovernorateId { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public string? NameKayes { get; set; }
    }
}
