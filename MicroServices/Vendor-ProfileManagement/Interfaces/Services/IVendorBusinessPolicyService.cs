using Vendor_ProfileManagement.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Models.VendorBusinessPolicy;
namespace Vendor_ProfileManagement.Interfaces.Services
{
    public interface IVendorBusinessPolicyService
    {
        #region CURD
        Task<VendorBusinessPolicyFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(VendorBusinessPolicyFullDataModel model);
        Task<PagedList<VendorBusinessPolicyFullDataModel?>> GetPagedList(PagedFilterModel filter);
        Task<BaseResponse?> DeleteAndActivate(int? id);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
