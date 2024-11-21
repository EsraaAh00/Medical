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
using Client_ClientProfileManagement.Models.ClientPrescribtion;

namespace Client_ClientProfileManagement.Repositories
{
    public class ClientPrescribtionRepository : BaseRespository<ClientPrescribtion, ClientPrescribtionLogger, ClientProfileManagementContext>, IClientPrescribtionRepository
    {
        private readonly DbSet<ClientPrescribtion> _Set;
        public ClientPrescribtionRepository(ClientProfileManagementContext context) : base(context, context.ClientPrescribtion)
        {
            _Set = context.ClientPrescribtion;
        }

        public async Task<ClientPrescribtionFullDataModel?> GetById(int? id)
        {
            ClientPrescribtion? entity = await GetEntityById(id);
            return ClientPrescribtionMapping.EntityToFullDataModel(entity);
        }


        public async Task<BaseResponse?> Save(ClientPrescribtionFullDataModel model)
        {
            ClientPrescribtion? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<PagedList<ClientPrescribtionFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().AsQueryable();
            var pagedList = await PagedList<ClientPrescribtionFullDataModel?>.ToPagedList(query.Select(s => ClientPrescribtionMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
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
