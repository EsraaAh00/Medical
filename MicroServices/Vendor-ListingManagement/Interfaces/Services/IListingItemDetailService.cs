using Vendor_ListingManagement.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using Vendor_ListingManagement.Models.ListingItemDetail;
namespace Vendor_ListingManagement.Interfaces.Services
{
    public interface IListingItemDetailService
    {
        #region CURD
        Task<ListingItemDetailFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(ListingItemDetailFullDataModel model , int? ItemId);
        Task<PagedList<ListingItemDetailFullDataModel?>> GetPagedList(PagedFilterModel filter);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
