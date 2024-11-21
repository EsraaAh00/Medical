using SharedModels.Models.Filter;
using SharedModels.Models;
using Client_ClientProfileManagement.Models.Client;
using Client_ClientProfileManagement.Models.ClientInsurance;

namespace Client_ClientProfileManagement.Interfaces.Repositories
{
    public interface IClientInsuranceRepository
    {
        #region CURD
        Task<ClientInsuranceFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(ClientInsuranceFullDataModel model);
        Task<PagedList<ClientInsuranceFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
