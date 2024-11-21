using Client_ClientProfileManagement.Models.Client;
using SharedModels.Models.Filter;
using SharedModels.Models;
using Client_ClientProfileManagement.Models.ClientPrescribtion;

namespace Client_ClientProfileManagement.Interfaces.Services
{
    public interface IClientPrescribtionService
    {
        #region CURD
        Task<ClientPrescribtionFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(ClientPrescribtionFullDataModel model);
        Task<PagedList<ClientPrescribtionFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
