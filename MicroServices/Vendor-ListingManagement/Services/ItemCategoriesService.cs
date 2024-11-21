using SharedModels.Models;
using SharedModels.Helpers;
using Vendor_ListingManagement.Interfaces.Services;
using Vendor_ListingManagement.Interfaces.Repositories;
using Vendor_ListingManagement.Models;
using Vendor_ListingManagement.Models.ItemCategories;
using SharedModels.Models.Filter;
namespace Vendor_ListingManagement.Services
{
    public class ItemCategoriesService : IItemCategoriesService
    {
        private readonly IItemCategoriesRepository _ItemCategoriesRepository;
        public ItemCategoriesService(IItemCategoriesRepository ItemCategoriesRepository)
        {
            _ItemCategoriesRepository = ItemCategoriesRepository;
        }
        #region CURD
        public async Task<ItemCategoriesFullDataModel?> GetById(int? id)
        {
            return await _ItemCategoriesRepository.GetById(id);
        }
        public async Task<BaseResponse?> Save(ItemCategoriesFullDataModel model)
        {
            return await _ItemCategoriesRepository.Save(model); ;
        }
        public async Task<PagedList<ItemCategoriesFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _ItemCategoriesRepository.GetPagedList(filter);
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            return await _ItemCategoriesRepository.GetDropDownList();
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            return await _ItemCategoriesRepository.GetIncludeByIdsList(ids);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _ItemCategoriesRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _ItemCategoriesRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
