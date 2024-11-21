using SharedModels.Models.Filter;
using SharedModels.Models;
using Operation_OperationsManagement.Interfaces.Repositories;
using Operation_OperationsManagement.Interfaces.Services;
using Operation_OperationsManagement.Models.Ticket;

namespace Operation_OperationsManagement.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _TicketRepository;
        public TicketService(ITicketRepository TicketRepository)
        {
            _TicketRepository = TicketRepository;
        }
        #region CURD
        public async Task<TicketFullDataModel> GetById(int id)
        {
            return await _TicketRepository.GetById(id);
        }

        public async Task<List<TicketFullDataModel>> GetListByProviderId(int id, int State)
        {
            return await _TicketRepository.GetListByProviderId(id,State);
        }

        public async Task<List<TicketFullDataModel>> GetListByClientId(int id, int State)
        {
            return await _TicketRepository.GetListByClientId(id,State);
        }

        public async Task<BaseResponse?> Save(TicketFullDataModel model)
        {
            return await _TicketRepository.Save(model); ;
        }

        public async Task<BaseResponse?> TicketSetAccepted(int Id)
        {
            var model = await _TicketRepository.GetById(Id);
            if (model == null)
            {
                return new BaseResponse { IsError = true, Message = "Model not found." };
            }

            model.StatusCodeId = 1;
            model.StatusCode = "Accepted";
            //MessageBroker.notification
            return await _TicketRepository.Save(model);
        }


        public async Task<BaseResponse?> TicketSetRejected(int Id)
        {
            var model = await _TicketRepository.GetById(Id);
            if (model == null)
            {
                return new BaseResponse { IsError = true, Message = "Model not found." };
            }
            model.StatusCodeId = 2;
            model.StatusCode = "Rejected";
            //MessageBroker.notification
            return await _TicketRepository.Save(model);
        }

        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _TicketRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _TicketRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
