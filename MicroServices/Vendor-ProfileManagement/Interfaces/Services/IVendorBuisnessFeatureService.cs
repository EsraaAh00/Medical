using Vendor_ProfileManagement.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Models.VendorBusinessFeature;
namespace Vendor_ProfileManagement.Interfaces.Services
{
    public interface IVendorBusinessFeatureService
    {
        #region CURD
        Task<VendorBusinessFeatureFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(VendorBusinessFeatureFullDataModel model);
        Task<PagedList<VendorBusinessFeatureFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        Task<BaseResponse?> DeleteAndActivate(int? id);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
