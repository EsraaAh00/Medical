using System_Authentication.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using System_Authentication.Models.UserRoleGroup;
namespace System_Authentication.Interfaces.Repositories
{
    public interface IUserRoleGroupRepository
    {
        #region CURD
        Task<UserRoleGroupFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(UserRoleGroupFullDataModel model);
        Task<PagedList<UserRoleGroupFullDataModel?>> GetPagedList(PagedFilterModel filter);
        Task<List<string?>> GetUserRolesByUserId(int userId);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
