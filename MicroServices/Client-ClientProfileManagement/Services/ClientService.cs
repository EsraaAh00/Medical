using SharedModels.Models.Filter;
using SharedModels.Models;
using Client_ClientProfileManagement.Interfaces.Services;
using Client_ClientProfileManagement.Interfaces.Repositories;
using Client_ClientProfileManagement.Models.Client;
using Client_ClientProfileManagement.Models.Settings;

namespace Client_ClientProfileManagement.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _ClientRepository;
        public ClientService(IClientRepository ClientRepository)
        {
            _ClientRepository = ClientRepository;
        }
        #region CURD
        public async Task<ClientFullDataModel?> GetById(int? id)
        {
            return await _ClientRepository.GetById(id);
        }

        public async Task<BaseResponse?> Save(ClientFullDataModel model /*, UploadFileModel File*/)
        {
            // messagebroker  
            return await _ClientRepository.Save(model); ;
        }
        public async Task<PagedList<ClientFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _ClientRepository.GetPagedList(filter);
        }


        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _ClientRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _ClientRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
