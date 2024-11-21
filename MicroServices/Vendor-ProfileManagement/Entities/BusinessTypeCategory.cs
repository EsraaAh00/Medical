using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Vendor_ProfileManagement.Entities
{
    public class BusinessTypeCategory : FullyBaseEnity
    {
        public virtual BusinessType? BusinessType { get; set; }
        [ForeignKey("BusinessType")]
        public int? BusinessTypeId { get; set; }
    }
}
