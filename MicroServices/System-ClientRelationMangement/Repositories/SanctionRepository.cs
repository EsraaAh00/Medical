using SharedModels.BaseRepository;
using System_ClientRelationMangement.Context;
using System_ClientRelationMangement.Entities.Logger;
using System_ClientRelationMangement.Entities;
using System_ClientRelationMangement.Interfaces.Repositories;
using System_ClientRelationMangement.Models.Sanction;
using Microsoft.EntityFrameworkCore;
using SharedModels.Models.Filter;
using SharedModels.Models;
using System_ClientRelationMangement.Mapping;
using SharedModels.Helpers;

namespace System_ClientRelationMangement.Repositories
{
    public class SanctionRepository : BaseRespository<Sanction, SanctionLogger, ClientRelationMangementContext>, ISanctionRepository
    {
        private readonly DbSet<Sanction> _Set;

        public SanctionRepository(ClientRelationMangementContext context) : base(context, context.Sanction)
        {
            _Set = context.Sanction;
        }

        #region CURD
        public async Task<SanctionFullDataModel?> GetById(int? id)
        {
            Sanction? entity = await GetEntityById(id);
            return SanctionMapping.EntityToFullDataModel(entity);
        }


        public async Task<BaseResponse?> Save(SanctionFullDataModel model)
        {
            Sanction? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }

        public async Task<PagedList<SanctionFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().AsQueryable();
            var pagedList = await PagedList<SanctionFullDataModel?>.ToPagedList(query.Select(s => SanctionMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
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
