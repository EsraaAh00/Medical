using Vendor_ListingManagement.Models;
using SharedModels.Models;
using Vendor_ListingManagement.Models.ListingItemPhotos;
namespace Vendor_ListingManagement.Interfaces.Repositories
{
    public interface IListingItemPhotosRepository
    {
        #region CURD
        Task<ListingItemPhotosFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(ListingItemPhotosFullDataModel model);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
