using Vendor_ListingManagement.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using Vendor_ListingManagement.Models.ListingItemsTax;
namespace Vendor_ListingManagement.Interfaces.Services
{
    public interface IListingItemsTaxService
    {
        #region CURD
        Task<ListingItemsTaxFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(ListingItemsTaxFullDataModel model);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
