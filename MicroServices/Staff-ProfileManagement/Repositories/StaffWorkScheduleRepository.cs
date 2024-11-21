using SharedModels.Models;
using Microsoft.EntityFrameworkCore;
using SharedModels.BaseRepository;
using Staff_StaffProfileManagement.Mapping;
using Staff_StaffProfileManagement.Models.StaffWorkSchedule;
using Staff_StaffProfileManagement.Entities;
using Staff_StaffProfileManagement.Interfaces.Repositories;
using Staff_StaffProfileManagement.Context;
using Staff_StaffProfileManagement.Entities.Logger;
using SharedModels.Helpers;
namespace Staff_StaffProfileManagement.Repositories
{
    public class StaffWorkScheduleRepository : BaseRespository<StaffWorkSchedule, StaffWorkScheduleLogger, ProfileManagementContext>, IStaffWorkScheduleRepository
    {
        private readonly DbSet<StaffWorkSchedule> _Set;
        public StaffWorkScheduleRepository(ProfileManagementContext context) : base(context, context.StaffWorkSchedule)
        {
            _Set = context.StaffWorkSchedule;
        }
        #region CURD
        public async Task<StaffWorkScheduleFullDataModel> GetById(int id)
        {
            StaffWorkSchedule? entity = await GetEntityById(id);
            return StaffWorkScheduleMapping.EntityToFullDataModel(entity);
        }


        public async Task<List<StaffWorkScheduleFullDataModel>> GetListById(int? id)
        {
            if (id == null) return new List<StaffWorkScheduleFullDataModel>();
            var entities = await _set.AsNoTracking().Where(p => p.StaffId == id).ToListAsync();
            var result = entities.Select(StaffWorkScheduleMapping.EntityToFullDataModel).ToList();
            return result;
        }


        public async Task<List<StaffWorkScheduleFullDataModel>> EntitiesByDayLoc(string day, double lat, double lng)
        {
            List<StaffWorkSchedule> AvailableToday =  await GetEntitiesByCondition(e => e.WorkDay == day);

            List<StaffWorkScheduleFullDataModel> AvailableTodayInCoverage = AvailableToday.Where(staff =>
            {
                var distance = DistanceHelper.GetDistance(
                    new Location { Latitude = staff.Latitude, Longitude = staff.Longitude },
                    new Location { Latitude = lat, Longitude = lng }
                );
                return distance <= (staff.CoveredArea * 1000);
            })
            .Select(StaffWorkScheduleMapping.EntityToFullDataModel)
            .ToList();

            return AvailableTodayInCoverage;
        }


        public async Task<List<StaffWorkScheduleFullDataModel>> GetListById(int id)
        {
            if (id == null) return new List<StaffWorkScheduleFullDataModel>();
            var entities = await _set.AsNoTracking().Where(p => p.StaffId == id).ToListAsync();
            var result = entities.Select(StaffWorkScheduleMapping.EntityToFullDataModel).ToList();
            return result;
        }
        public async Task<BaseResponse?> Save(StaffWorkScheduleFullDataModel model)
        {
            StaffWorkSchedule? enitity = await GetEntityByIdWithTracking(model.Id);
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
