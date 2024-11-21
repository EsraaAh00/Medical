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
using Client_ClientProfileManagement.Models.ClientTherapyProgram;

namespace Client_ClientProfileManagement.Repositories
{
    public class ClientTherapyProgramRepository : BaseRespository<ClientTherapyProgram, ClientTherapyProgramLogger, ClientProfileManagementContext>, IClientTherapyProgramRepository
    {
        private readonly DbSet<ClientTherapyProgram> _Set;
        public ClientTherapyProgramRepository(ClientProfileManagementContext context) : base(context, context.ClientTherapyProgram)
        {
            _Set = context.ClientTherapyProgram;
        }

        public async Task<ClientTherapyProgramFullDataModel?> GetById(int? id)
        {
            ClientTherapyProgram? entity = await GetEntityById(id);
            return ClientTherapyProgramMapping.EntityToFullDataModel(entity);
        }


        public async Task<BaseResponse?> Save(ClientTherapyProgramFullDataModel model)
        {
            ClientTherapyProgram? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<PagedList<ClientTherapyProgramFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().AsQueryable();
            var pagedList = await PagedList<ClientTherapyProgramFullDataModel?>.ToPagedList(query.Select(s => ClientTherapyProgramMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
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
