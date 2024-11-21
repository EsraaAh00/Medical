using SharedModels.Models;
using SharedModels.Helpers;
using Microsoft.EntityFrameworkCore;
using SharedModels.BaseRepository;
using Facility_FacilityProfileManagement.Context;
using Facility_FacilityProfileManagement.Mapping;
using Facility_FacilityProfileManagement.Models.FacilityWorkSchedule;
using Facility_FacilityProfileManagement.Interfaces.Repositories;
using Facility_FacilityProfileManagement.Entities;
using Facility_FacilityProfileManagement.Entities.Logger;
using Facility_FacilityProfileManagement.Models.Facility;
namespace Facility_FacilityProfileManagement.Repositories
{
    public class FacilityWorkScheduleRepository : BaseRespository<FacilityWorkSchedule, FacilityWorkScheduleLogger, ProfileManagementContext>, IFacilityWorkScheduleRepository
    {
        private readonly DbSet<FacilityWorkSchedule> _Set;
        public FacilityWorkScheduleRepository(ProfileManagementContext context) : base(context, context.FacilityWorkSchedule)
        {
            _Set = context.FacilityWorkSchedule;
        }
        #region CURD
        public async Task<FacilityWorkScheduleFullDataModel?> GetById(int? id)
        {
            FacilityWorkSchedule? entity = await GetEntityById(id);
            return FacilityWorkScheduleMapping.EntityToFullDataModel(entity);
        }

        public async Task<List<FacilityWorkScheduleFullDataModel?>> GetListById(int? id)
        {
            if (id == null) return new List<FacilityWorkScheduleFullDataModel?>();
            var entities = await _set.AsNoTracking().Where(p => p.FacilityId == id).ToListAsync();
            var result = entities.Select(FacilityWorkScheduleMapping.EntityToFullDataModel).ToList();
            return result;
        }
        public async Task<BaseResponse?> Save(FacilityWorkScheduleFullDataModel model)
        {
            FacilityWorkSchedule? enitity = await GetEntityByIdWithTracking(model.Id);
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
