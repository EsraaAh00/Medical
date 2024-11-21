using System_Authentication.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using System_Authentication.Models.User;
namespace System_Authentication.Interfaces.Repositories
{
    public interface IUserRepository
    {
        #region CURD
        Task<UserFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(UserFullDataModel model);
        Task<PagedList<UserFullDataModel?>> GetPagedList(PagedFilterModel filter);
        Task<List<UserDataList>?> GetDataList();

        Task<int> CheckForRepetitationPhone(string? phone);
        Task<int> CheckForRepetitationEmail(string? email);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
