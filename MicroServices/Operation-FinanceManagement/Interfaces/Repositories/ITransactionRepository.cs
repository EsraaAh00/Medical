using SharedModels.Models.Filter;
using SharedModels.Models;
using Operation_FinanceManagement.Models.Transaction;

namespace Operation_FinanceManagement.Interfaces.Repositories
{
    public interface ITransactionRepository
    {
        #region CURD
        Task<TransactionFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(TransactionFullDataModel model);
        Task<PagedList<TransactionFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
