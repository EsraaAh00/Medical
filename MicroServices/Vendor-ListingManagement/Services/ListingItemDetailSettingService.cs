using SharedModels.Models;
using SharedModels.Helpers;
using Vendor_ListingManagement.Interfaces.Services;
using Vendor_ListingManagement.Interfaces.Repositories;
using Vendor_ListingManagement.Models;
using Vendor_ListingManagement.Models.ListingItemDetailSetting;
using SharedModels.Models.Filter;
using Vendor_ListingManagement.Enums;
using Vendor_ListingManagement.RefModels;
namespace Vendor_ListingManagement.Services
{
    public class ListingItemDetailSettingService : IListingItemDetailSettingService
    {
        private readonly IListingItemDetailSettingRepository _ListingItemDetailSettingRepository;
        public ListingItemDetailSettingService(IListingItemDetailSettingRepository ListingItemDetailSettingRepository)
        {
            _ListingItemDetailSettingRepository = ListingItemDetailSettingRepository;
        }
        #region CURD
        public async Task<ListingItemDetailSettingFullDataModel?> GetById(int? id)
        {
            return await _ListingItemDetailSettingRepository.GetById(id);
        }

        public async Task<List<ListingItemDetailSettingFullDataModel?>> GetFormByItemCategoryId(int? id)
        {
            int? bcid = await MessageBrokerServices.MessageBrokerService.GetBuissnesCatId(id);
            return await _ListingItemDetailSettingRepository.GetFormByBusinessTypeCategoryId(bcid);
        }
        public async Task<List<ListingItemDetailSettingFullDataModel?>> GetItemSetting(int? id)
        {
            return await _ListingItemDetailSettingRepository.GetItemSetting(id);
        }

        public async Task<BaseResponse?> Save(ListingItemDetailSettingFullDataModel model)
        {
            return await _ListingItemDetailSettingRepository.Save(model); ;
        }
        public async Task<PagedList<ListingItemDetailSettingFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _ListingItemDetailSettingRepository.GetPagedList(filter);
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            return await _ListingItemDetailSettingRepository.GetDropDownList();
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            return await _ListingItemDetailSettingRepository.GetIncludeByIdsList(ids);
        }
        public List<BaseDropDown>? GetTypeEnumDropDownList()
        {
            var dropDownList = Enum.GetValues(typeof(TypeEnum)).Cast<TypeEnum>().Select(s =>
          new BaseDropDown { Id = (int)s, Name = s.GetDisplayName() }).ToList();
            return dropDownList;
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _ListingItemDetailSettingRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _ListingItemDetailSettingRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
