using Client_ClientProfileManagement.Interfaces.Repositories;
using Client_ClientProfileManagement.Interfaces.Services;
using Client_ClientProfileManagement.Models.Client;
using SharedModels.Models.Filter;
using SharedModels.Models;
using Client_ClientProfileManagement.Models.ClientXray;

namespace Client_ClientProfileManagement.Services
{
    public class ClientXrayService : IClientXrayService
    {
        private readonly IClientXrayRepository _ClientXrayRepository;
        public ClientXrayService(IClientXrayRepository ClientXrayRepository)
        {
            _ClientXrayRepository = ClientXrayRepository;
        }
        #region CURD
        public async Task<ClientXrayFullDataModel?> GetById(int? id)
        {
            return await _ClientXrayRepository.GetById(id);
        }


        public async Task<BaseResponse?> Save(ClientXrayFullDataModel model)
        {
            return await _ClientXrayRepository.Save(model); ;
        }
        public async Task<PagedList<ClientXrayFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _ClientXrayRepository.GetPagedList(filter);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _ClientXrayRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _ClientXrayRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
