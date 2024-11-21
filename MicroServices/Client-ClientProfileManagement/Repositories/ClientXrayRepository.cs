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
using Client_ClientProfileManagement.Models.ClientXray;

namespace Client_ClientProfileManagement.Repositories
{
    public class ClientXrayRepository : BaseRespository<ClientXray, ClientXrayLogger, ClientProfileManagementContext>, IClientXrayRepository
    {
        private readonly DbSet<ClientXray> _Set;
        public ClientXrayRepository(ClientProfileManagementContext context) : base(context, context.ClientXray)
        {
            _Set = context.ClientXray;
        }

        public async Task<ClientXrayFullDataModel?> GetById(int? id)
        {
            ClientXray? entity = await GetEntityById(id);
            return ClientXrayMapping.EntityToFullDataModel(entity);
        }


        public async Task<BaseResponse?> Save(ClientXrayFullDataModel model)
        {
            ClientXray? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<PagedList<ClientXrayFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().AsQueryable();
            var pagedList = await PagedList<ClientXrayFullDataModel?>.ToPagedList(query.Select(s => ClientXrayMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
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
