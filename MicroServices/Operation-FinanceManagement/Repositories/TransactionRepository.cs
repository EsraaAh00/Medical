using SharedModels.BaseRepository;
using Operation_FinanceManagement.Context;
using Operation_FinanceManagement.Entities.Logger;
using Operation_FinanceManagement.Entities;
using Operation_FinanceManagement.Models.Transaction;
using Operation_FinanceManagement.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using SharedModels.Models.Filter;
using SharedModels.Models;
using Operation_FinanceManagement.Mapping;
using SharedModels.Helpers;


namespace Operation_FinanceManagement.Repositories
{
    public class TransactionRepository : BaseRespository<Transaction, TransactionLogger, FinanceManagementContext>, ITransactionRepository
    {
        private readonly DbSet<Transaction> _Set;

        public TransactionRepository(FinanceManagementContext context) : base(context, context.Transaction)
        {
            _Set = context.Transaction;
        }

        #region CURD
        public async Task<TransactionFullDataModel?> GetById(int? id)
        {
            Transaction? entity = await GetEntityById(id);
            return TransactionMapping.EntityToFullDataModel(entity);
        }


        public async Task<BaseResponse?> Save(TransactionFullDataModel model)
        {
            Transaction? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }

        public async Task<PagedList<TransactionFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().AsQueryable();
            var pagedList = await PagedList<TransactionFullDataModel?>.ToPagedList(query.Select(s => TransactionMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
            return pagedList;
        }
        #endregion

        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await UndoEntity(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            List<LogModel?>? logger = await GetEntityLogByRecordIdOrTranactionsId(recordId, null);
            return logger;
        }
        #endregion

    }
}
