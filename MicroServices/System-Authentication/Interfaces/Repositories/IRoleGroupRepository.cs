using System_Authentication.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using System_Authentication.Models.RoleGroup;
namespace System_Authentication.Interfaces.Repositories
{
    public interface IRoleGroupRepository
    {
        #region CURD
        Task<RoleGroupFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(RoleGroupFullDataModel model);
        Task<PagedList<RoleGroupFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        Task<List<BaseDropDown>?> GetDropDownList();
        Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
