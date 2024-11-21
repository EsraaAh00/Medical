using Client_ClientProfileManagement.Interfaces.Repositories;
using Client_ClientProfileManagement.Interfaces.Services;
using Client_ClientProfileManagement.Models.Client;
using SharedModels.Models.Filter;
using SharedModels.Models;
using Client_ClientProfileManagement.Models.ClientPrescribtion;

namespace Client_ClientProfileManagement.Services
{
    public class ClientPrescribtionService : IClientPrescribtionService
    {
        private readonly IClientPrescribtionRepository _ClientPrescribtionRepository;
        public ClientPrescribtionService(IClientPrescribtionRepository ClientPrescribtionRepository)
        {
            _ClientPrescribtionRepository = ClientPrescribtionRepository;
        }
        #region CURD
        public async Task<ClientPrescribtionFullDataModel?> GetById(int? id)
        {
            return await _ClientPrescribtionRepository.GetById(id);
        }


        public async Task<BaseResponse?> Save(ClientPrescribtionFullDataModel model)
        {
            return await _ClientPrescribtionRepository.Save(model); ;
        }
        public async Task<PagedList<ClientPrescribtionFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _ClientPrescribtionRepository.GetPagedList(filter);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _ClientPrescribtionRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _ClientPrescribtionRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
