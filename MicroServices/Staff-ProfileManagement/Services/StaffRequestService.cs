using SharedModels.Models;
using Staff_StaffProfileManagement.MessageBrokerServices;
using Staff_StaffProfileManagement.Interfaces.Services;
using Staff_StaffProfileManagement.Models.StaffRequest;
using Staff_StaffProfileManagement.Interfaces.Repositories;

namespace Staff_StaffProfileManagement.Services
{
    public class StaffRequestService : IStaffRequestService
    {
        private readonly IStaffRequestRepository _StaffRequestRepository;

        public StaffRequestService(IStaffRequestRepository StaffRequestRepository)
        {
            _StaffRequestRepository = StaffRequestRepository;
        }
        #region CURD
        public async Task<StaffRequestFullDataModel?> GetById(int? id)
        {
            return await _StaffRequestRepository.GetById(id);
        }

        public async Task<List<StaffRequestFullDataModel>> GetListByState(int? state)
        {
            return await _StaffRequestRepository.GetListByState(state);
        }

        public async Task<BaseResponse?> Save(StaffRequestFullDataModel model)
        {
            return await _StaffRequestRepository.Save(model);
        }

        public async Task<BaseResponse?> RequestSetAccepted(int id)
        {
            var model = await _StaffRequestRepository.GetById(id);
            if (model == null)
            {
                return new BaseResponse { IsError = true, Message = "Model not found." };
            }

            model.RequestStatusCode = 1;
            model.RequestStatus = "Accepted";

            var registerprocess = await MessageBrokerService.RegisterUser(model);

            if (registerprocess?.IsError == false)
            {
                return await _StaffRequestRepository.Save(model);
            }

            return new BaseResponse { IsError = true };
        }


        public async Task<BaseResponse?> RequestSetRejected(RejectionModel rejection)
        {
            var model = await _StaffRequestRepository.GetById(rejection.RequestId);
            model.RequestStatusCode = 2;
            model.RequestStatus = "Rejected";
            model.RejectionReason = rejection.RejectionReason;
            //MessageBroker.smshelper
            return await _StaffRequestRepository.Save(model);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _StaffRequestRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _StaffRequestRepository.GetRecordLogger(recordId);
        }




        #endregion
    }
}