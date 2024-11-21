using Client_ClientProfileManagement.Interfaces.Repositories;
using Client_ClientProfileManagement.Interfaces.Services;
using Client_ClientProfileManagement.Models.Client;
using SharedModels.Models.Filter;
using SharedModels.Models;
using Client_ClientProfileManagement.Models.ClientAnalysisResult;

namespace Client_ClientProfileManagement.Services
{
    public class ClientAnalysisResultService : IClientAnalysisResultService
    {
        private readonly IClientAnalysisResultRepository _ClientAnalysisResultRepository;
        public ClientAnalysisResultService(IClientAnalysisResultRepository ClientAnalysisResultRepository)
        {
            _ClientAnalysisResultRepository = ClientAnalysisResultRepository;
        }
        #region CURD
        public async Task<ClientAnalysisResultFullDataModel?> GetById(int? id)
        {
            return await _ClientAnalysisResultRepository.GetById(id);
        }


        public async Task<BaseResponse?> Save(ClientAnalysisResultFullDataModel model)
        {
            return await _ClientAnalysisResultRepository.Save(model); ;
        }
        public async Task<PagedList<ClientAnalysisResultFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _ClientAnalysisResultRepository.GetPagedList(filter);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _ClientAnalysisResultRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _ClientAnalysisResultRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
