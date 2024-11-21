using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Vendor_ProfileManagement.Entities
{
    public class Option : FullyBaseEnity
    {
        public virtual Feature? Feature { get; set; }
        [ForeignKey("Feature")]
        public int? FeatureId { get; set; }
    }
}
