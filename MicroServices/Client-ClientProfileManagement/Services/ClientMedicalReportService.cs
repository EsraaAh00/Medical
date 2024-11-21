using Client_ClientProfileManagement.Interfaces.Repositories;
using Client_ClientProfileManagement.Interfaces.Services;
using Client_ClientProfileManagement.Models.Client;
using SharedModels.Models.Filter;
using SharedModels.Models;
using Client_ClientProfileManagement.Models.ClientMedicalReport;

namespace Client_ClientProfileManagement.Services
{
    public class ClientMedicalReportService : IClientMedicalReportService
    {
        private readonly IClientMedicalReportRepository _ClientMedicalReportRepository;
        public ClientMedicalReportService(IClientMedicalReportRepository ClientMedicalReportRepository)
        {
            _ClientMedicalReportRepository = ClientMedicalReportRepository;
        }
        #region CURD
        public async Task<ClientMedicalReportFullDataModel?> GetById(int? id)
        {
            return await _ClientMedicalReportRepository.GetById(id);
        }


        public async Task<BaseResponse?> Save(ClientMedicalReportFullDataModel model)
        {
            return await _ClientMedicalReportRepository.Save(model); ;
        }
        public async Task<PagedList<ClientMedicalReportFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _ClientMedicalReportRepository.GetPagedList(filter);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _ClientMedicalReportRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _ClientMedicalReportRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
