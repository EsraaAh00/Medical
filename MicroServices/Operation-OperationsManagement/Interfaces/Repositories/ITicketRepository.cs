using Operation_OperationsManagement.Models.Ticket;
using SharedModels.Models.Filter;
using SharedModels.Models;

namespace Operation_OperationsManagement.Interfaces.Repositories
{
    public interface ITicketRepository
    {
        #region CURD
        Task<TicketFullDataModel> GetById(int? id);
        Task<List<TicketFullDataModel>> GetListByProviderId(int? id , int? State);
        Task<List<TicketFullDataModel>> GetListByClientId(int? id, int? State);
        Task<BaseResponse?> Save(TicketFullDataModel model);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
