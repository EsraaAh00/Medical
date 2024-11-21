using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Shared_GeneralSharedData.Entities
{
    public class Currency : FullyBaseEnity
    {
        public virtual Country? Country { get; set; }
        [ForeignKey("Country")]
        public int? CountryId { get; set; }
        public string? Prefix { get; set; }
        public string? PrefixLocalized { get; set; }
        public string? Symbol { get; set; }
    }
}
