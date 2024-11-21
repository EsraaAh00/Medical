using Vendor_ListingManagement.Models;
using SharedModels.Models;
using Vendor_ListingManagement.Models.ListingItemsPricing;
namespace Vendor_ListingManagement.Interfaces.Repositories
{
    public interface IListingItemsPricingRepository
    {
        #region CURD
        Task<ListingItemsPricingFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(ListingItemsPricingFullDataModel model);
        Task<PagedList<ListingItemsPricingFullDataModel?>> GetPagedList(ListingItemsPricingFilter filter);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}