using SharedModels.Models;
using SharedModels.Helpers;
using Vendor_ListingManagement.Interfaces.Services;
using Vendor_ListingManagement.Interfaces.Repositories;
using Vendor_ListingManagement.Models;
using Vendor_ListingManagement.Models.ListingItemsPricing;
using Vendor_ListingManagement.Enums;
namespace Vendor_ListingManagement.Services
{
    public class ListingItemsPricingService : IListingItemsPricingService
    {
        private readonly IListingItemsPricingRepository _ListingItemsPricingRepository;
        private readonly IListingItemRepository _ListingItemRepository;

        public ListingItemsPricingService(IListingItemsPricingRepository ListingItemsPricingRepository, IListingItemRepository listingItemRepository)
        {
            _ListingItemsPricingRepository = ListingItemsPricingRepository;
            _ListingItemRepository = listingItemRepository;
        }
        #region CURD
        public async Task<ListingItemsPricingFullDataModel?> GetById(int? id)
        {
            var ItemPrice = await _ListingItemsPricingRepository.GetById(id);
            return ItemPrice;
        }
        public async Task<BaseResponse?> Save(ListingItemsPricingFullDataModel model)
        {
            return await _ListingItemsPricingRepository.Save(model); 
        }
        public async Task<PagedList<ListingItemsPricingFullDataModel?>> GetPagedList(ListingItemsPricingFilter filter)
        {
            return await _ListingItemsPricingRepository.GetPagedList(filter);
        }
        public List<BaseDropDown>? GetChargeFrequencyEnumDropDownList()
        {
            var dropDownList = Enum.GetValues(typeof(ChargeFrequencyType)).Cast<ChargeFrequencyType>().Select(s =>
          new BaseDropDown { Id = (int)s, Name = s.GetDisplayName() }).ToList().GetListDropDownWithAll();
            return dropDownList;
        }
        public List<BaseDropDown>? GetApplicableTypeEnumDropDownList()
        {
            var dropDownList = Enum.GetValues(typeof(ApplicableType)).Cast<ApplicableType>().Select(s =>
          new BaseDropDown { Id = (int)s, Name = s.GetDisplayName() }).ToList().GetListDropDownWithAll();
            return dropDownList;
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _ListingItemsPricingRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _ListingItemsPricingRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}