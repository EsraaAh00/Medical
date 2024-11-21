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
using Client_ClientProfileManagement.Models.ClientInsurance;

namespace Client_ClientProfileManagement.Repositories
{
    public class ClientInsuranceRepository : BaseRespository<ClientInsurance, ClientInsuranceLogger, ClientProfileManagementContext>, IClientInsuranceRepository
    {
        private readonly DbSet<ClientInsurance> _Set;
        public ClientInsuranceRepository(ClientProfileManagementContext context) : base(context, context.ClientInsurance)
        {
            _Set = context.ClientInsurance;
        }

        public async Task<ClientInsuranceFullDataModel?> GetById(int? id)
        {
            ClientInsurance? entity = await GetEntityById(id);
            return ClientInsuranceMapping.EntityToFullDataModel(entity);
        }


        public async Task<BaseResponse?> Save(ClientInsuranceFullDataModel model)
        {
            ClientInsurance? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<PagedList<ClientInsuranceFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().AsQueryable();
            var pagedList = await PagedList<ClientInsuranceFullDataModel?>.ToPagedList(query.Select(s => ClientInsuranceMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
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
