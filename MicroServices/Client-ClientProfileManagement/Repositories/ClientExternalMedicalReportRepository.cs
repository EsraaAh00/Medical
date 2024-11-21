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
using Client_ClientProfileManagement.Models.ClientExternalMedicalReport;

namespace Client_ClientProfileManagement.Repositories
{
    public class ClientExternalMedicalReportRepository : BaseRespository<ClientExternalMedicalReport, ClientExternalMedicalReportLogger, ClientProfileManagementContext>, IClientExternalMedicalReportRepository
    {
        private readonly DbSet<ClientExternalMedicalReport> _Set;
        public ClientExternalMedicalReportRepository(ClientProfileManagementContext context) : base(context, context.ClientExternalMedicalReport)
        {
            _Set = context.ClientExternalMedicalReport;
        }

        public async Task<ClientExternalMedicalReportFullDataModel?> GetById(int? id)
        {
            ClientExternalMedicalReport? entity = await GetEntityById(id);
            return ClientExternalMedicalReportMapping.EntityToFullDataModel(entity);
        }


        public async Task<BaseResponse?> Save(ClientExternalMedicalReportFullDataModel model)
        {
            ClientExternalMedicalReport? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<PagedList<ClientExternalMedicalReportFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().AsQueryable();
            var pagedList = await PagedList<ClientExternalMedicalReportFullDataModel?>.ToPagedList(query.Select(s => ClientExternalMedicalReportMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
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
