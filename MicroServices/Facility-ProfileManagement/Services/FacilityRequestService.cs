using SharedModels.Models;
using Facility_FacilityProfileManagement.Models.FacilityRequest;
using Facility_FacilityProfileManagement.Interfaces.Services;
using Facility_FacilityProfileManagement.Interfaces.Repositories;
using Facility_FacilityProfileManagement.MessageBrokerServices;

namespace Facility_FacilityProfileManagement.Services
{
    public class FacilityRequestService : IFacilityRequestService
    {
        private readonly IFacilityRequestRepository _FacilityRequestRepository;

        public FacilityRequestService(IFacilityRequestRepository FacilityRequestRepository)
        {
            _FacilityRequestRepository = FacilityRequestRepository;
        }
        #region CURD
        public async Task<FacilityRequestFullDataModel?> GetById(int? id)
        {
            return await _FacilityRequestRepository.GetById(id);
        }

        public async Task<List<FacilityRequestFullDataModel?>> GetListByState(int? state)
        {
            return await _FacilityRequestRepository.GetListByState(state);
        }

        public async Task<BaseResponse?> Save(FacilityRequestFullDataModel model )
        {
            return await _FacilityRequestRepository.Save(model);
        }

        public async Task<BaseResponse?> RequestSetAccepted(int id)
        {
            var model = await _FacilityRequestRepository.GetById(id);
            if (model == null)
            {
                return new BaseResponse { IsError = true, Message = "Model not found." };
            }


            model.RequestStatusCode = 1;
            model.RequestStatus = "Accepted";

            //MessageBroker.smshelper
            /// mail sender == moddel.email , subject = " You are accepted" , body = " formal acceptance phrase + account data phone = model.phone ,  password  = model.password




            var registerprocess = await MessageBrokerService.RegisterUser(model);


            if (registerprocess?.IsError == false)
            {
                return await _FacilityRequestRepository.Save(model);
            }

            return new BaseResponse { IsError = true };
        }


        public async Task<BaseResponse?> RequestSetRejected(RejectionModel rejection)
        {
            var model = await _FacilityRequestRepository.GetById(rejection.RequestId);
            model.RequestStatusCode = 2;
            model.RequestStatus = "Rejected";
            model.RejectionReason = rejection.RejectionReason;
            //MessageBroker.smshelper
            ///   عكس mail sender == moddel.email , subject = " You are accepted" , body = " formal acceptance phrase + account data phone = model.phone ,  password  = model.password
            return await _FacilityRequestRepository.Save(model);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _FacilityRequestRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _FacilityRequestRepository.GetRecordLogger(recordId);
        }




        #endregion
    }
}