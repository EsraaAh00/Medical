using Microsoft.EntityFrameworkCore;
using SharedModels.BaseRepository;
using SharedModels.Models.Filter;
using SharedModels.Models;
using Client_ClientProfileManagement.Entities;
using Client_ClientProfileManagement.Entities.Logger;
using Client_ClientProfileManagement.Context;
using Client_ClientProfileManagement.Interfaces.Repositories;
using Client_ClientProfileManagement.Mapping;
using Client_ClientProfileManagement.Models.Client;

namespace Client_ClientProfileManagement.Repositories
{
    public class ClientRepository : BaseRespository<Client, ClientLogger, ClientProfileManagementContext>, IClientRepository
    {
        private readonly DbSet<Client> _Set;
        public ClientRepository(ClientProfileManagementContext context) : base(context, context.Client)
        {
            _Set = context.Client;
        }

        public async Task<ClientFullDataModel?> GetById(int? id)
        {
            Client? entity = await GetEntityById(id);
            return ClientMapping.EntityToFullDataModel(entity);
        }


        public async Task<BaseResponse?> Save(ClientFullDataModel model)
        {
            Client? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }


        public async Task<PagedList<ClientFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().AsQueryable();
            var pagedList = await PagedList<ClientFullDataModel?>.ToPagedList(query.Select(s => ClientMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
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
