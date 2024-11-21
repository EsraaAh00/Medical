using SharedModels.BaseRepository;
using System_ClientRelationMangement.Context;
using System_ClientRelationMangement.Entities.Logger;
using System_ClientRelationMangement.Entities;
using System_ClientRelationMangement.Interfaces.Repositories;
using System_ClientRelationMangement.Models.ComplaintAction;
using Microsoft.EntityFrameworkCore;
using SharedModels.Models.Filter;
using SharedModels.Models;
using System_ClientRelationMangement.Mapping;
using SharedModels.Helpers;

namespace System_ClientRelationMangement.Repositories
{
    public class ComplaintActionRepository : BaseRespository<ComplaintAction, ComplaintActionLogger, ClientRelationMangementContext>, IComplaintActionRepository
    {
        private readonly DbSet<ComplaintAction> _Set;

        public ComplaintActionRepository(ClientRelationMangementContext context) : base(context, context.ComplaintAction)
        {
            _Set = context.ComplaintAction;
        }

        #region CURD
        public async Task<ComplaintActionFullDataModel?> GetById(int? id)
        {
            ComplaintAction? entity = await GetEntityById(id);
            return ComplaintActionMapping.EntityToFullDataModel(entity);
        }


        public async Task<BaseResponse?> Save(ComplaintActionFullDataModel model)
        {
            ComplaintAction? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }

        public async Task<PagedList<ComplaintActionFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().AsQueryable();
            var pagedList = await PagedList<ComplaintActionFullDataModel?>.ToPagedList(query.Select(s => ComplaintActionMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
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
