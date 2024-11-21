using Vendor_ProfileManagement.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Models.SubscriptionPlan;
namespace Vendor_ProfileManagement.Interfaces.Services
{
    public interface ISubscriptionPlanService
    {
        #region CURD
        Task<SubscriptionPlanFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(SubscriptionPlanFullDataModel model);
        Task<PagedList<SubscriptionPlanFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        Task<List<BaseDropDown>?> GetDropDownList();
        Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
