using SharedModels.Models;
using Staff_StaffProfileManagement.Entities;
using Staff_StaffProfileManagement.Models.StaffWorkSchedule;
namespace Staff_StaffProfileManagement.Interfaces.Repositories
{
    public interface IStaffWorkScheduleRepository
    {
        #region CURD
        Task<StaffWorkScheduleFullDataModel> GetById(int Id);
        Task<List<StaffWorkScheduleFullDataModel>> GetListById(int? id);
        Task<List<StaffWorkScheduleFullDataModel>> EntitiesByDayLoc(string day, double lat, double lng);
        Task<BaseResponse?> Save(StaffWorkScheduleFullDataModel model);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
