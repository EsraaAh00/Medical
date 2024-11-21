using Vendor_ProfileManagement.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Models.VendorBusinessGallery;
namespace Vendor_ProfileManagement.Interfaces.Services
{
    public interface IVendorBusinessGalleryService
    {
        #region CURD
        Task<VendorBusinessGalleryFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(VendorBusinessGalleryFullDataModel model);
        Task<PagedList<VendorBusinessGalleryFullDataModel?>> GetPagedList(PagedFilterModel filter);
        Task<BaseResponse?> DeleteAndActivate(int? id);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
