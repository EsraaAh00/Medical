using Operation_FinanceManagement.Models.Transaction;
using Operation_FinanceManagement.Interfaces.Repositories;
using SharedModels.Models.Filter;
using SharedModels.Models;
using Operation_FinanceManagement.Interfaces.Services;

namespace Operation_FinanceManagement.Services
{
    public class TransactionService : ITransactionService
    {

        private readonly ITransactionRepository _TransactionRepository;
        public TransactionService(ITransactionRepository TransactionRepository)
        {
            _TransactionRepository = TransactionRepository;
        }

        #region CURD
        public async Task<TransactionFullDataModel?> GetById(int? id)
        {
            return await _TransactionRepository.GetById(id);
        }

        public async Task<BaseResponse?> Save(TransactionFullDataModel model)
        {



            return await _TransactionRepository.Save(model);
        }


        public async Task<PagedList<TransactionFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _TransactionRepository.GetPagedList(filter);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _TransactionRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _TransactionRepository.GetRecordLogger(recordId);
        }
        #endregion


    }
}
