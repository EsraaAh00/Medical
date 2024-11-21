using Vendor_ProfileManagement.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Models.VendorBusinessFeature;
namespace Vendor_ProfileManagement.Interfaces.Repositories
{
    public interface IVendorBusinessFeatureRepository
    {
        #region CURD
        Task<VendorBusinessFeatureFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(VendorBusinessFeatureFullDataModel model);
        Task<PagedList<VendorBusinessFeatureFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
