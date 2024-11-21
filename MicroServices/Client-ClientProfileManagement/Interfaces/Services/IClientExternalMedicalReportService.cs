using Client_ClientProfileManagement.Models.ClientAnalysisResult;
using SharedModels.Models.Filter;
using SharedModels.Models;
using Client_ClientProfileManagement.Models.ClientExternalMedicalReport;

namespace Client_ClientProfileManagement.Interfaces.Services
{
    public interface IClientExternalMedicalReportService
    {
        #region CURD
        Task<ClientExternalMedicalReportFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(ClientExternalMedicalReportFullDataModel model);
        Task<PagedList<ClientExternalMedicalReportFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
