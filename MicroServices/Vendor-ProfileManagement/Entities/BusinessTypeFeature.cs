using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Vendor_ProfileManagement.Entities
{
    public class BusinessTypeFeature : BaseModel
    {
        public virtual BusinessType? BusinessType { get; set; }
        [ForeignKey("BusinessType")]
        public int? BusinessTypeId { get; set; }
        public virtual Feature? Feature { get; set; }
        [ForeignKey("Feature")]
        public int? FeatureId { get; set; }
    }
}
