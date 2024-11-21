using Client_ClientProfileManagement.Models.Client;
using SharedModels.Models.Filter;
using SharedModels.Models;
using Client_ClientProfileManagement.Models.ClientAnalysisResult;

namespace Client_ClientProfileManagement.Interfaces.Services
{
    public interface IClientAnalysisResultService
    {
        #region CURD
        Task<ClientAnalysisResultFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(ClientAnalysisResultFullDataModel model);
        Task<PagedList<ClientAnalysisResultFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
