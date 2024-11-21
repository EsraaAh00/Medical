using SharedModels.Models;
using SharedModels.Helpers;
using Microsoft.EntityFrameworkCore;
using SharedModels.BaseRepository;
using Staff_StaffProfileManagement.Models.StaffAward;
using Staff_StaffProfileManagement.Interfaces.Repositories;
using Staff_StaffProfileManagement.Entities.Logger;
using Staff_StaffProfileManagement.Context;
using Staff_StaffProfileManagement.Entities;
using Staff_StaffProfileManagement.Mapping;
namespace Staff_StaffProfileManagement.Repositories
{
    public class StaffAwardRepository : BaseRespository<StaffAward, StaffAwardLogger, ProfileManagementContext>, IStaffAwardRepository
    {
        private readonly DbSet<StaffAward> _Set;
        public StaffAwardRepository(ProfileManagementContext context) : base(context, context.StaffAward)
        {
            _Set = context.StaffAward;
        }
        #region CURD
        public async Task<StaffAwardFullDataModel> GetById(int? id)
        {
            StaffAward? entity = await GetEntityById(id);
            return StaffAwardMapping.EntityToFullDataModel(entity);
        }

        public async Task<List<StaffAwardFullDataModel>> GetListById(int? id)
        {
            if (id == null) return new List<StaffAwardFullDataModel>();
            var entities = await _set.AsNoTracking().Where(p => p.StaffId == id).ToListAsync();
            var result = entities.Select(StaffAwardMapping.EntityToFullDataModel).ToList();
            return result;
        }
        public async Task<BaseResponse?> Save(StaffAwardFullDataModel model)
        {
            StaffAward? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
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
