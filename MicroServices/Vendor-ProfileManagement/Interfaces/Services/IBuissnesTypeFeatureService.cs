using Vendor_ProfileManagement.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Models.BusinessTypeFeature;
namespace Vendor_ProfileManagement.Interfaces.Services
{
    public interface IBusinessTypeFeatureService
    {
        #region CURD
        Task<BusinessTypeFeatureFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(BusinessTypeFeatureFullDataModel model);
        Task<BaseResponse?> DeleteAndActivate(int? id);
        Task<PagedList<BusinessTypeFeatureFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
