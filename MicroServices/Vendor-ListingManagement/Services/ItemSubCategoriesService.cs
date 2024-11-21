using SharedModels.Models;
using SharedModels.Helpers;
using Vendor_ListingManagement.Interfaces.Services;
using Vendor_ListingManagement.Interfaces.Repositories;
using Vendor_ListingManagement.Models;
using Vendor_ListingManagement.Models.ItemSubCategories;
using SharedModels.Models.Filter;
namespace Vendor_ListingManagement.Services
{
    public class ItemSubCategoriesService : IItemSubCategoriesService
    {
        private readonly IItemSubCategoriesRepository _ItemSubCategoriesRepository;
        public ItemSubCategoriesService(IItemSubCategoriesRepository ItemSubCategoriesRepository)
        {
            _ItemSubCategoriesRepository = ItemSubCategoriesRepository;
        }
        #region CURD
        public async Task<ItemSubCategoriesFullDataModel?> GetById(int? id)
        {
            return await _ItemSubCategoriesRepository.GetById(id);
        }
        public async Task<BaseResponse?> Save(ItemSubCategoriesFullDataModel model)
        {
            return await _ItemSubCategoriesRepository.Save(model); ;
        }
        public async Task<PagedList<ItemSubCategoriesFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _ItemSubCategoriesRepository.GetPagedList(filter);
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            return await _ItemSubCategoriesRepository.GetDropDownList();
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            return await _ItemSubCategoriesRepository.GetIncludeByIdsList(ids);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _ItemSubCategoriesRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _ItemSubCategoriesRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
