using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Vendor_ProfileManagement.Entities
{
    public class VendorBusinessGallery : BaseModel
    {
        public virtual VendorBusiness? VendorBusiness { get; set; }
        [ForeignKey("VendorBusiness")]
        public int? VendorBusinessId { get; set; }
        public string? GalleryImage { get; set; }
    }
}
