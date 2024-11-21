using Vendor_ListingManagement.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using Vendor_ListingManagement.Models.ListingItemDetailSetting;
namespace Vendor_ListingManagement.Interfaces.Services
{
    public interface IListingItemDetailSettingService
    {
        #region CURD
        Task<ListingItemDetailSettingFullDataModel?> GetById(int? id);
        Task<List<ListingItemDetailSettingFullDataModel?>> GetFormByItemCategoryId(int? id);
        Task<BaseResponse?> Save(ListingItemDetailSettingFullDataModel model);
        Task<List<ListingItemDetailSettingFullDataModel?>> GetItemSetting(int? id);
        Task<PagedList<ListingItemDetailSettingFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        Task<List<BaseDropDown>?> GetDropDownList();
        Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
