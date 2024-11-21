using Vendor_ProfileManagement.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Models.VendorBusinessGallery;
namespace Vendor_ProfileManagement.Interfaces.Repositories
{
    public interface IVendorBusinessGalleryRepository
    {
        #region CURD
        Task<VendorBusinessGalleryFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(VendorBusinessGalleryFullDataModel model);
        Task<PagedList<VendorBusinessGalleryFullDataModel?>> GetPagedList(PagedFilterModel filter);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
