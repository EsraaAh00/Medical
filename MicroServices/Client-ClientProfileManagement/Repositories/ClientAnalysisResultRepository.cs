using Client_ClientProfileManagement.Context;
using Client_ClientProfileManagement.Entities.Logger;
using Client_ClientProfileManagement.Entities;
using Client_ClientProfileManagement.Interfaces.Repositories;
using Client_ClientProfileManagement.Mapping;
using Client_ClientProfileManagement.Models.Client;
using Microsoft.EntityFrameworkCore;
using SharedModels.BaseRepository;
using SharedModels.Models.Filter;
using SharedModels.Models;
using Client_ClientProfileManagement.Models.ClientAnalysisResult;

namespace Client_ClientProfileManagement.Repositories
{
    public class ClientAnalysisResultRepository : BaseRespository<ClientAnalysisResult, ClientAnalysisResultLogger, ClientProfileManagementContext>, IClientAnalysisResultRepository
    {
        private readonly DbSet<ClientAnalysisResult> _Set;
        public ClientAnalysisResultRepository(ClientProfileManagementContext context) : base(context, context.ClientAnalysisResult)
        {
            _Set = context.ClientAnalysisResult;
        }

        public async Task<ClientAnalysisResultFullDataModel?> GetById(int? id)
        {
            ClientAnalysisResult? entity = await GetEntityById(id);
            return ClientAnalysisResultMapping.EntityToFullDataModel(entity);
        }


        public async Task<BaseResponse?> Save(ClientAnalysisResultFullDataModel model)
        {
            ClientAnalysisResult? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<PagedList<ClientAnalysisResultFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().AsQueryable();
            var pagedList = await PagedList<ClientAnalysisResultFullDataModel?>.ToPagedList(query.Select(s => ClientAnalysisResultMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
            return pagedList;
        }
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
