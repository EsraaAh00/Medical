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
using Client_ClientProfileManagement.Models.ClientMedicalProfile;

namespace Client_ClientProfileManagement.Repositories
{
    public class ClientMedicalProfileRepository : BaseRespository<ClientMedicalProfile, ClientMedicalProfileLogger, ClientProfileManagementContext>, IClientMedicalProfileRepository
    {
        private readonly DbSet<ClientMedicalProfile> _Set;
        public ClientMedicalProfileRepository(ClientProfileManagementContext context) : base(context, context.ClientMedicalProfile)
        {
            _Set = context.ClientMedicalProfile;
        }

        public async Task<ClientMedicalProfileFullDataModel?> GetById(int? id)
        {
            ClientMedicalProfile? entity = await GetEntityById(id);
            return ClientMedicalProfileMapping.EntityToFullDataModel(entity);
        }


        public async Task<BaseResponse?> Save(ClientMedicalProfileFullDataModel model)
        {
            ClientMedicalProfile? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<PagedList<ClientMedicalProfileFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().AsQueryable();
            var pagedList = await PagedList<ClientMedicalProfileFullDataModel?>.ToPagedList(query.Select(s => ClientMedicalProfileMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
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
