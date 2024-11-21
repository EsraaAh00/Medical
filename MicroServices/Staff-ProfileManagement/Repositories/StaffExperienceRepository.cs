using SharedModels.Models;
using Microsoft.EntityFrameworkCore;
using SharedModels.BaseRepository;
using Staff_StaffProfileManagement.Models.StaffExperience;
using Staff_StaffProfileManagement.Entities;
using Staff_StaffProfileManagement.Interfaces.Repositories;
using Staff_StaffProfileManagement.Entities.Logger;
using Staff_StaffProfileManagement.Context;
using Staff_StaffProfileManagement.Mapping;
namespace Staff_StaffProfileManagement.Repositories
{
    public class StaffExperienceRepository : BaseRespository<StaffExperience, StaffExperienceLogger, ProfileManagementContext>, IStaffExperienceRepository
    {
        private readonly DbSet<StaffExperience> _Set;
        public StaffExperienceRepository(ProfileManagementContext context) : base(context, context.StaffExperience)
        {
            _Set = context.StaffExperience;
        }
        #region CURD
        public async Task<StaffExperienceFullDataModel> GetById(int? id)
        {
            StaffExperience? entity = await GetEntityById(id);
            return StaffExperienceMapping.EntityToFullDataModel(entity);
        }

        public async Task<List<StaffExperienceFullDataModel>> GetListById(int? id)
        {
            if (id == null) return new List<StaffExperienceFullDataModel>();
            var entities = await _set.AsNoTracking().Where(p => p.StaffId == id).ToListAsync();
            var result = entities.Select(StaffExperienceMapping.EntityToFullDataModel).ToList();
            return result;
        }
        public async Task<BaseResponse?> Save(StaffExperienceFullDataModel model)
        {
            StaffExperience? enitity = await GetEntityByIdWithTracking(model.Id);
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
