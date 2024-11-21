using SharedModels.Models;
using SharedModels.Helpers;
using Vendor_ListingManagement.Interfaces.Services;
using Vendor_ListingManagement.Interfaces.Repositories;
using Vendor_ListingManagement.Models;
using Vendor_ListingManagement.Models.ListingItemDetail;
using SharedModels.Models.Filter;
using Vendor_ListingManagement.Enums;
using Vendor_ListingManagement.MessageBrokerServices;
using Vendor_ListingManagement.Entities;
namespace Vendor_ListingManagement.Services
{
    public class ListingItemDetailService : IListingItemDetailService
    {
        private readonly IListingItemDetailRepository _ListingItemDetailRepository;
        public ListingItemDetailService(IListingItemDetailRepository ListingItemDetailRepository)
        {
            _ListingItemDetailRepository = ListingItemDetailRepository;
        }
        #region CURD
        public async Task<ListingItemDetailFullDataModel?> GetById(int? id)
        {
            return await _ListingItemDetailRepository.GetById(id);
        }
        public async Task<BaseResponse?> Save(ListingItemDetailFullDataModel model, int? ItemId)
        {
            DynamicObjectHelper.AddParameter(model, "ItemId", ItemId);
            var AddListingItemDetail = await MessageBrokerServices.MessageBrokerService.AddListingIemDetail(model, model.ListingItemDetailSettingCode);
            if (AddListingItemDetail?.IsError == false) 
            {
                return await _ListingItemDetailRepository.Save(model);
            }
            return new BaseResponse { IsError = true };
        }
        public async Task<PagedList<ListingItemDetailFullDataModel?>> GetPagedList(PagedFilterModel filter)
        {
            return await _ListingItemDetailRepository.GetPagedList(filter);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _ListingItemDetailRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _ListingItemDetailRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
