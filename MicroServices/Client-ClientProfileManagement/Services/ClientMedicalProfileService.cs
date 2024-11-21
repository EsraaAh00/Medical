using Client_ClientProfileManagement.Interfaces.Repositories;
using Client_ClientProfileManagement.Interfaces.Services;
using Client_ClientProfileManagement.Models.Client;
using SharedModels.Models.Filter;
using SharedModels.Models;
using Client_ClientProfileManagement.Models.ClientMedicalProfile;

namespace Client_ClientProfileManagement.Services
{
    public class ClientMedicalProfileService : IClientMedicalProfileService
    {
        private readonly IClientMedicalProfileRepository _ClientMedicalProfileRepository;
        public ClientMedicalProfileService(IClientMedicalProfileRepository ClientMedicalProfileRepository)
        {
            _ClientMedicalProfileRepository = ClientMedicalProfileRepository;
        }
        #region CURD
        public async Task<ClientMedicalProfileFullDataModel?> GetById(int? id)
        {
            return await _ClientMedicalProfileRepository.GetById(id);
        }


        public async Task<BaseResponse?> Save(ClientMedicalProfileFullDataModel model)
        {
            return await _ClientMedicalProfileRepository.Save(model); ;
        }
        public async Task<PagedList<ClientMedicalProfileFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _ClientMedicalProfileRepository.GetPagedList(filter);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _ClientMedicalProfileRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _ClientMedicalProfileRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
