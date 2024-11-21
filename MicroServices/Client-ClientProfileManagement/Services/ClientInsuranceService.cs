using Client_ClientProfileManagement.Interfaces.Repositories;
using Client_ClientProfileManagement.Interfaces.Services;
using Client_ClientProfileManagement.Models.Client;
using SharedModels.Models.Filter;
using SharedModels.Models;
using Client_ClientProfileManagement.Models.ClientInsurance;

namespace Client_ClientProfileManagement.Services
{
    public class ClientInsuranceService : IClientInsuranceService
    {
        private readonly IClientInsuranceRepository _ClientInsuranceRepository;
        public ClientInsuranceService(IClientInsuranceRepository ClientInsuranceRepository)
        {
            _ClientInsuranceRepository = ClientInsuranceRepository;
        }
        #region CURD
        public async Task<ClientInsuranceFullDataModel?> GetById(int? id)
        {
            return await _ClientInsuranceRepository.GetById(id);
        }


        public async Task<BaseResponse?> Save(ClientInsuranceFullDataModel model)
        {
            return await _ClientInsuranceRepository.Save(model); ;
        }
        public async Task<PagedList<ClientInsuranceFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _ClientInsuranceRepository.GetPagedList(filter);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _ClientInsuranceRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _ClientInsuranceRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
