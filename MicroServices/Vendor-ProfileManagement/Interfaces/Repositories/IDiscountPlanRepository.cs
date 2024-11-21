using Vendor_ProfileManagement.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Models.DiscountPlan;
namespace Vendor_ProfileManagement.Interfaces.Repositories
{
    public interface IDiscountPlanRepository
    {
        #region CURD
        Task<DiscountPlanFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(DiscountPlanFullDataModel model);
        Task<PagedList<DiscountPlanFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        Task<List<BaseDropDown>?> GetDropDownList();
        Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
