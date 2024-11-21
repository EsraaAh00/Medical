using System_Authentication.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using System_Authentication.Models.User;
namespace System_Authentication.Interfaces.Services
{
    public interface IUserService
    {
        #region CURD
        Task<UserFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(UserFullDataModel model);
        Task<BaseResponse?> DeleteAndActivate(int? id);
        Task<PagedList<UserFullDataModel?>> GetPagedList(PagedFilterModel filter);
        Task<List<UserDataList>?> GetDataList();
        Task<BaseResponse?> CheckForRepetitationEmailAndPhone(string? email, string? phone);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
