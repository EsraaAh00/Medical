using Vendor_ListingManagement.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using Vendor_ListingManagement.Models.ListingItem;
namespace Vendor_ListingManagement.Interfaces.Services
{
    public interface IListingItemService
    {
        #region CURD
        Task<ListingItemFullDataModel?> GetFormByItemId(int? id, int vendorBuissnesId);
        Task<BaseResponse?> StateSetItemDeactivate(int id);
        Task<BaseResponse?> Save(ListingItemFullDataModel model);
        Task<PagedList<ListingItemFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        Task<List<BaseDropDown>?> GetDropDownList();
        Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
