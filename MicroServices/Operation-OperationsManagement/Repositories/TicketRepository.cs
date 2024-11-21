using Microsoft.EntityFrameworkCore;
using SharedModels.BaseRepository;
using SharedModels.Models.Filter;
using SharedModels.Models;
using Operation_OperationsManagement.Entities;
using Operation_OperationsManagement.Entities.Logger;
using Operation_OperationsManagement.Context;
using Operation_OperationsManagement.Interfaces.Repositories;
using Operation_OperationsManagement.Models.Ticket;
using Vendor_ListingManagement.Mapping;
namespace Operation_OperationsManagement.Repositories
{
    public class TicketRepository : BaseRespository<Ticket, TicketLogger, OperationsManagementContext>, ITicketRepository
    {
        private readonly DbSet<Ticket> _Set;
        public TicketRepository(OperationsManagementContext context) : base(context, context.Ticket)
        {
            _Set = context.Ticket;
        }

        public async Task<TicketFullDataModel?> GetById(int? id)
        {
            Ticket? entity = await GetEntityById(id);
            return TicketMapping.EntityToFullDataModel(entity);
        }

        public async Task<List<TicketFullDataModel>> GetListByProviderId(int? id, int? State)
        {
            if (State == null) return new List<TicketFullDataModel>();
            var entities = await _set.AsNoTracking().Where(p => p.ServiceProviderId == id).ToListAsync();
            var Stateentities = await _set.AsNoTracking().Where(p => p.StatusCodeId == State).ToListAsync();
            var result = entities.Select(TicketMapping.EntityToFullDataModel).ToList();
            return result;
        }

        public async Task<List<TicketFullDataModel>> GetListByClientId(int? id, int? State)
        {
            if (State == null) return new List<TicketFullDataModel>();
            var entities = await _set.AsNoTracking().Where(p => p.ClientId == id).ToListAsync();
            var Stateentities = await _set.AsNoTracking().Where(p => p.StatusCodeId == State).ToListAsync();
            var result = entities.Select(TicketMapping.EntityToFullDataModel).ToList();
            return result;
        }


        public async Task<BaseResponse?> Save(TicketFullDataModel model)
        {
            Ticket? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
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
