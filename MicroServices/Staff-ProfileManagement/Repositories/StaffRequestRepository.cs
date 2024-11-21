using SharedModels.Models;
using SharedModels.Helpers;
using Microsoft.EntityFrameworkCore;
using SharedModels.BaseRepository;
using Staff_StaffProfileManagement.Entities;
using Staff_StaffProfileManagement.Interfaces.Repositories;
using Staff_StaffProfileManagement.Entities.Logger;
using Staff_StaffProfileManagement.Models.StaffRequest;
using Staff_StaffProfileManagement.Context;
using Staff_StaffProfileManagement.Mapping;
namespace Staff_StaffProfileManagement.Repositories
{
    public class StaffRequestRepository : BaseRespository<StaffRequest, StaffRequestLogger, ProfileManagementContext>, IStaffRequestRepository
    {
        private readonly DbSet<StaffRequest> _Set;


        public StaffRequestRepository(ProfileManagementContext context) : base(context, context.StaffRequest)
        {
            _Set = context.StaffRequest;
        }
        #region CURD
        public async Task<StaffRequestFullDataModel> GetById(int? id)
        {
            StaffRequest? entity = await GetEntityById(id);
            return StaffRequestMapping.EntityToFullDataModel(entity);
        }

        public async Task<List<StaffRequestFullDataModel>> GetListByState(int? state)
        {
            if (state == null) return new List<StaffRequestFullDataModel>();
            var entities = await _set.AsNoTracking().Where(p => p.RequestStatusCode == state).ToListAsync();
            var result = entities.Select(StaffRequestMapping.EntityToFullDataModel).ToList();
            return result;
        }

        public async Task<BaseResponse?> Save(StaffRequestFullDataModel model)
        {
            StaffRequest? enitity = await GetEntityByIdWithTracking(model.Id);
            if (enitity == null)
            {
                enitity.RequestStatusCode = 0;
                var entityWithLog = enitity.FullDataModelToEntity(model);
                var issaved = await SaveAsync(entityWithLog);
                return new BaseResponse { IsError = false, Message = "Request Saved" };
            }
            return new BaseResponse { IsError = true, Message = "Failed to Save The Request" };
        }
        #endregion
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