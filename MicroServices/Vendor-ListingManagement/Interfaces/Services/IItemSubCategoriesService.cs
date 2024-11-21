using SharedModels.Models.Filter;
using SharedModels.Models;
using Vendor_ListingManagement.Models.ItemSubCategories;

namespace Vendor_ListingManagement.Interfaces.Services
{
    public interface IItemSubCategoriesService
    {
        #region CURD
        Task<ItemSubCategoriesFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(ItemSubCategoriesFullDataModel model);
        Task<PagedList<ItemSubCategoriesFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        Task<List<BaseDropDown>?> GetDropDownList();
        Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
