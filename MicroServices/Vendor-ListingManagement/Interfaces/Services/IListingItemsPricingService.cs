using Vendor_ListingManagement.Models;
using SharedModels.Models;
using Vendor_ListingManagement.Models.ListingItemsPricing;
namespace Vendor_ListingManagement.Interfaces.Services
{
    public interface IListingItemsPricingService
    {
        #region CURD
        Task<ListingItemsPricingFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(ListingItemsPricingFullDataModel model);
        Task<PagedList<ListingItemsPricingFullDataModel?>> GetPagedList(ListingItemsPricingFilter filter);
        List<BaseDropDown>? GetChargeFrequencyEnumDropDownList();
        List<BaseDropDown>? GetApplicableTypeEnumDropDownList();
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}