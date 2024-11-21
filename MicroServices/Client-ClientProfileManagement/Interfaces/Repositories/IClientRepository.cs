using SharedModels.Models.Filter;
using SharedModels.Models;
using Client_ClientProfileManagement.Models.Client;

namespace Client_ClientProfileManagement.Interfaces.Repositories
{
    public interface IClientRepository
    {
        #region CURD
        Task<ClientFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(ClientFullDataModel model);
        Task<PagedList<ClientFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
