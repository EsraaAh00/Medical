using SharedModels.Models;
using Staff_StaffProfileManagement.Models.StaffExperience;
namespace Staff_StaffProfileManagement.Interfaces.Services
{
    public interface IStaffExperienceService
    {
        #region CURD
        Task<StaffExperienceFullDataModel> GetById(int? id);
        Task<List<StaffExperienceFullDataModel>> GetListById(int? id);
        Task<BaseResponse?> Save(StaffExperienceFullDataModel model);
        Task<BaseResponse?> DeleteAndActivate(int? id);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
