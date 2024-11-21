using Client_ClientProfileManagement.Models.Client;
using SharedModels.Models.Filter;
using SharedModels.Models;
using Client_ClientProfileManagement.Models.ClientMedicalReport;

namespace Client_ClientProfileManagement.Interfaces.Services
{
    public interface IClientMedicalReportService
    {
        #region CURD
        Task<ClientMedicalReportFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(ClientMedicalReportFullDataModel model);
        Task<PagedList<ClientMedicalReportFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
