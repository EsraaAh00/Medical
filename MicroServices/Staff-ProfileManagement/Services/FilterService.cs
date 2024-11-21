using SharedModels.Helpers;
using SharedModels.Models;
using Staff_StaffProfileManagement.Entities;
using Staff_StaffProfileManagement.Interfaces.Repositories;
using Staff_StaffProfileManagement.Interfaces.Services;
using Staff_StaffProfileManagement.Mapping;
using Staff_StaffProfileManagement.Models.Staff;
using Staff_StaffProfileManagement.Models.StaffWorkSchedule;

namespace Staff_StaffProfileManagement.Services
{
    public class FilterService :  IFilterService
    {
        private readonly IStaffRepository _StaffRepository;
        private readonly IStaffWorkScheduleRepository _StaffWorkScheduleRepository;
        public FilterService(IStaffRepository StaffRepository , IStaffWorkScheduleRepository StaffWorkScheduleRepository)
        {
            _StaffRepository = StaffRepository;
            _StaffWorkScheduleRepository = StaffWorkScheduleRepository;
        }

        public async Task<List<StaffFullDataModel>> GetList(string? Speciality, string Day, double lat, double lng)
        {
            List<StaffWorkScheduleFullDataModel> AvailableStaff = await _StaffWorkScheduleRepository.EntitiesByDayLoc(Day, lat, lng);
            List<int> staffIds = AvailableStaff.Select(f => f.Id).ToList();
            List<StaffFullDataModel> TodaysStaff = await _StaffRepository.GetListByIds(staffIds);
            List<StaffFullDataModel> filteredStaff = TodaysStaff.Where(staff => staff.Speciality == Speciality) .ToList();
            return filteredStaff;

        }
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _StaffRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _StaffRepository.GetRecordLogger(recordId);
        }
        #endregion

    }
}
