using Client_ClientProfileManagement.Interfaces.Repositories;
using Client_ClientProfileManagement.Interfaces.Services;
using Client_ClientProfileManagement.Models.Client;
using SharedModels.Models.Filter;
using SharedModels.Models;
using Client_ClientProfileManagement.Models.ClientExternalMedicalReport;

namespace Client_ClientProfileManagement.Services
{
    public class ClientExternalMedicalReportService : IClientExternalMedicalReportService
    {
        private readonly IClientExternalMedicalReportRepository _ClientExternalMedicalReportRepository;
        public ClientExternalMedicalReportService(IClientExternalMedicalReportRepository ClientExternalMedicalReportRepository)
        {
            _ClientExternalMedicalReportRepository = ClientExternalMedicalReportRepository;
        }
        #region CURD
        public async Task<ClientExternalMedicalReportFullDataModel?> GetById(int? id)
        {
            return await _ClientExternalMedicalReportRepository.GetById(id);
        }


        public async Task<BaseResponse?> Save(ClientExternalMedicalReportFullDataModel model)
        {
            return await _ClientExternalMedicalReportRepository.Save(model); ;
        }
        public async Task<PagedList<ClientExternalMedicalReportFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _ClientExternalMedicalReportRepository.GetPagedList(filter);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _ClientExternalMedicalReportRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _ClientExternalMedicalReportRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
