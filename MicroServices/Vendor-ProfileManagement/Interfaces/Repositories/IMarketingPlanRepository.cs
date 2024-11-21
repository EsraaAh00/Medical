using Vendor_ProfileManagement.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Models.MarketingPlan;
namespace Vendor_ProfileManagement.Interfaces.Repositories
{
    public interface IMarketingPlanRepository
    {
        #region CURD
        Task<MarketingPlanFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(MarketingPlanFullDataModel model);
        Task<PagedList<MarketingPlanFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        Task<List<BaseDropDown>?> GetDropDownList();
        Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
