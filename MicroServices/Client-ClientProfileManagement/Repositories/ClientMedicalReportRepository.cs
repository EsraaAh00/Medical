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
using Client_ClientProfileManagement.Models.ClientMedicalReport;

namespace Client_ClientProfileManagement.Repositories
{
    public class ClientMedicalReportRepository : BaseRespository<ClientMedicalReport, ClientMedicalReportLogger, ClientProfileManagementContext>, IClientMedicalReportRepository
    {
        private readonly DbSet<ClientMedicalReport> _Set;
        public ClientMedicalReportRepository(ClientProfileManagementContext context) : base(context, context.ClientMedicalReport)
        {
            _Set = context.ClientMedicalReport;
        }

        public async Task<ClientMedicalReportFullDataModel?> GetById(int? id)
        {
            ClientMedicalReport? entity = await GetEntityById(id);
            return ClientMedicalReportMapping.EntityToFullDataModel(entity);
        }


        public async Task<BaseResponse?> Save(ClientMedicalReportFullDataModel model)
        {
            ClientMedicalReport? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<PagedList<ClientMedicalReportFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().AsQueryable();
            var pagedList = await PagedList<ClientMedicalReportFullDataModel?>.ToPagedList(query.Select(s => ClientMedicalReportMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
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
