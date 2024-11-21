using Client_ClientProfileManagement.Interfaces.Repositories;
using Client_ClientProfileManagement.Interfaces.Services;
using Client_ClientProfileManagement.Models.Client;
using SharedModels.Models.Filter;
using SharedModels.Models;
using Client_ClientProfileManagement.Models.ClientTherapyProgram;

namespace Client_ClientProfileManagement.Services
{
    public class ClientTherapyProgramService : IClientTherapyProgramService
    {
        private readonly IClientTherapyProgramRepository _ClientTherapyProgramRepository;
        public ClientTherapyProgramService(IClientTherapyProgramRepository ClientTherapyProgramRepository)
        {
            _ClientTherapyProgramRepository = ClientTherapyProgramRepository;
        }
        #region CURD
        public async Task<ClientTherapyProgramFullDataModel?> GetById(int? id)
        {
            return await _ClientTherapyProgramRepository.GetById(id);
        }


        public async Task<BaseResponse?> Save(ClientTherapyProgramFullDataModel model)
        {
            return await _ClientTherapyProgramRepository.Save(model); ;
        }
        public async Task<PagedList<ClientTherapyProgramFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _ClientTherapyProgramRepository.GetPagedList(filter);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _ClientTherapyProgramRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _ClientTherapyProgramRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
