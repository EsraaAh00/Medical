using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Shared_GeneralSharedData.Entities
{
    public class Governorate : FullyBaseEnity
    {
        public virtual Country? Country { get; set; }
        [ForeignKey("Country")]
        public int? CountryId { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public string? NameKays { get; set; }
    }
}
