using SharedModels.Models;
namespace Vendor_ListingManagement.Models.ListingItemDetailSetting
{
    public class ListingItemDetailSettingFullDataModel : FullyBaseModel
    {
        public int? ItemCategoryId { get; set; }   
        public int? Code { get; set; }
        public string? Type { get; set; }
        public int? TypeCode { get; set; }
        public string? Vector { get; set; }
        public int? Priority { get; set; }
    }
}
