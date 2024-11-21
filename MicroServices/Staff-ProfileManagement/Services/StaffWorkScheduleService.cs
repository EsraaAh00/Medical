using SharedModels.Models;
using SharedModels.Helpers;
using SharedModels.Models.Filter;
using Staff_StaffProfileManagement.Models.StaffWorkSchedule;
using Staff_StaffProfileManagement.Interfaces.Repositories;
using Staff_StaffProfileManagement.Interfaces.Services;
using Staff_StaffProfileManagement.Entities;
namespace Staff_StaffProfileManagement.Services
{
    public class StaffWorkScheduleService : IStaffWorkScheduleService
    {
        private readonly IStaffWorkScheduleRepository _StaffWorkScheduleRepository;
        public StaffWorkScheduleService(IStaffWorkScheduleRepository StaffWorkScheduleRepository)
        {
            _StaffWorkScheduleRepository = StaffWorkScheduleRepository;
        }
        #region CURD
        public async Task<StaffWorkScheduleFullDataModel> GetById(int Id)
        {
            return await _StaffWorkScheduleRepository.GetById(Id);
        }


        public async Task<List<StaffWorkScheduleFullDataModel>> GetListById(int? id)
        {
            return await _StaffWorkScheduleRepository.GetListById(id);
        }

        public async Task<List<StaffWorkScheduleFullDataModel>> EntitiesByDayLoc(string day, double lat, double lng)
        {
            return await _StaffWorkScheduleRepository.EntitiesByDayLoc(day,lat,lng);
        }

        public async Task<BaseResponse?> Save(StaffWorkScheduleFullDataModel model)
        {
            return await _StaffWorkScheduleRepository.Save(model); ;
        }

        public async Task<BaseResponse?> DeleteAndActivate(int Id)
        {
            StaffWorkScheduleFullDataModel? model = await _StaffWorkScheduleRepository.GetById(Id);
            if (model != null)
            {
                model.IsDeleted = !(model.IsDeleted ?? false);

            }
            return await _StaffWorkScheduleRepository.Save(model);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _StaffWorkScheduleRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _StaffWorkScheduleRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
