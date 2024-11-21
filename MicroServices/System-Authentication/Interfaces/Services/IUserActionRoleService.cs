using System_Authentication.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using System_Authentication.Models.UserActionRole;
namespace System_Authentication.Interfaces.Services
{
    public interface IUserActionRoleService
    {
        #region CURD
        Task<UserActionRoleFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(UserActionRoleFullDataModel model);
        Task<BaseResponse?> DeleteAndActivate(int? id);
        Task<PagedList<UserActionRoleFullDataModel?>> GetPagedList(PagedFilterModel filter);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
