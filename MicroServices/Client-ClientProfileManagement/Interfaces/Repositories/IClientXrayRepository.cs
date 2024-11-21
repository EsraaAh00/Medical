using Client_ClientProfileManagement.Models.Client;
using SharedModels.Models.Filter;
using SharedModels.Models;
using Client_ClientProfileManagement.Models.ClientXray;

namespace Client_ClientProfileManagement.Interfaces.Repositories
{
    public interface IClientXrayRepository
    {
        #region CURD
        Task<ClientXrayFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(ClientXrayFullDataModel model);
        Task<PagedList<ClientXrayFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
