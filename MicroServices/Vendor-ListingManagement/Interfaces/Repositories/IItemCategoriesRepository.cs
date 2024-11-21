using Vendor_ListingManagement.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using Vendor_ListingManagement.Models.ItemCategories;
namespace Vendor_ListingManagement.Interfaces.Repositories
{
    public interface IItemCategoriesRepository
    {
        #region CURD
        Task<ItemCategoriesFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(ItemCategoriesFullDataModel model);
        Task<PagedList<ItemCategoriesFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        Task<List<BaseDropDown>?> GetDropDownList();
        Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
