using SharedModels.Models;
using SharedModels.Helpers;
using Vendor_ListingManagement.Interfaces.Services;
using Vendor_ListingManagement.Interfaces.Repositories;
using Vendor_ListingManagement.Models;
using Vendor_ListingManagement.Models.ListingItem;
using SharedModels.Models.Filter;
using Vendor_ListingManagement.Enums;
using Vendor_ListingManagement.MessageBrokerServices;
using Vendor_ListingManagement.RefModels;
using Vendor_ListingManagement.Models.ListingItemDetailSetting;
using Vendor_ListingManagement.Entities;
using Vendor_ListingManagement.Models.ListingItemDetail;
using JwtAuthenticationManager;
using Vendor_ListingManagement.Repositories;

namespace Vendor_ListingManagement.Services
{
    public class ListingItemService : IListingItemService
    {
        private readonly IListingItemRepository _ListingItemRepository;
        private readonly IListingItemDetailSettingRepository _ListingItemDetailSettingRepository;
        private readonly IListingItemDetailService _ListingItemDetailService;

        public ListingItemService(IListingItemRepository ListingItemRepository,
            IListingItemDetailSettingRepository ListingItemDetailSettingRepository,IListingItemDetailService listingItemDetailService)
        {
            _ListingItemRepository = ListingItemRepository;
            _ListingItemDetailSettingRepository = ListingItemDetailSettingRepository;
            _ListingItemDetailService = listingItemDetailService;   
        }


        #region CURD
        public async Task<ListingItemFullDataModel?> GetFormByItemId(int? id, int vendorBuissnesId)
        {
            if (id == null)
            {
                int? bcid = await MessageBrokerServices.MessageBrokerService.GetBuissnesCatId(vendorBuissnesId);
                if(bcid != 0)
                {
                    List<ListingItemDetailSettingFullDataModel?> settings = await _ListingItemDetailSettingRepository.GetFormByBusinessTypeCategoryId(bcid);
                    ListingItemFullDataModel item = new ListingItemFullDataModel();
                    foreach (var setting in settings)
                    {
                        ListingItemDetailFullDataModel detail = new ListingItemDetailFullDataModel();
                        detail.Setting = setting;
                        detail.ListingItemDetailSettingId = setting?.Id;
                        detail.ListingItemDetailSettingName = (AuthenticationHelper.GetLanuage() == 1) ? setting?.Name : setting?.NameLocalized;
                        if (item.Details != null)
                        {
                            item.Details.Add(detail);
                        }
                    }
                    return item;
                }
            }
            return await _ListingItemRepository.GetById(id);
        }



        public async Task<BaseResponse?> Save(ListingItemFullDataModel model)
        {
            int? bcid = await MessageBrokerServices.MessageBrokerService.GetBuissnesCatId(model.VendorBusinessId);
            if (bcid != 0)
            {
                var SaveItemHard = await _ListingItemRepository.Save(model);
                if (SaveItemHard?.IsError == false) 
                {
                    DynamicObjectHelper.AddParameter(model, "ListingItemId", SaveItemHard.ReturnedValue);
                    var AddListingItem = await MessageBrokerService.AddListingItem(model, bcid);
                    if (AddListingItem != null && !AddListingItem.IsError)
                    {
                        var ListingItemId = AddListingItem.TargetId;
                        if (model.Details != null)
                        {
                            foreach (var detail in model.Details)
                            {
                                await _ListingItemDetailService.Save(detail,ListingItemId);
                            }
                            return new BaseResponse { IsError = false , Message = "Item Saved" };
                        }
                    }
                }
            }
            return new BaseResponse { IsError = true };
        }

        public async Task<BaseResponse?> StateSetItemDeactivate(int id)
        {
            var model = await _ListingItemRepository.GetById(id);
            model.StateCode = (int)StateEnum.ItemDeactivate;
            model.State = StateEnum.ItemDeactivate.ToString();
            return await _ListingItemRepository.Save(model);
        }
        public async Task<BaseResponse?> StateSetItemActivate(int id)
        {
            var model = await _ListingItemRepository.GetById(id);
            model.StateCode = (int)StateEnum.ItemDeactivate;
            model.State = StateEnum.ItemActivate.ToString();
            return await _ListingItemRepository.Save(model);
        }
        public async Task<PagedList<ListingItemFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _ListingItemRepository.GetPagedList(filter);
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            return await _ListingItemRepository.GetDropDownList();
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            return await _ListingItemRepository.GetIncludeByIdsList(ids);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _ListingItemRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _ListingItemRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
