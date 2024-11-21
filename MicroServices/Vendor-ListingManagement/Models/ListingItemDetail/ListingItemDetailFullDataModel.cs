using SharedModels.Models;
using Vendor_ListingManagement.Models.ListingItemDetailSetting;

namespace Vendor_ListingManagement.Models.ListingItemDetail
{
    public class ListingItemDetailFullDataModel : BaseModel
    {
        public int? ListingItemId { get; set; }
        public string? ListingItemName { get; set; }
        public int? ListingItemDetailSettingId { get; set; }
        public string? ListingItemDetailSettingName { get; set; }
        public int? ListingItemDetailSettingCode { get; set; }
        public string? Value { get; set; }
        public string? ValueLocalized { get; set; }
        public ListingItemDetailSettingFullDataModel? Setting { get; set; }

    }
}
