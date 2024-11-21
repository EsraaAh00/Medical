using SharedModels.Models;
using Staff_StaffProfileManagement.Models.StaffAward;
namespace Staff_StaffProfileManagement.Interfaces.Services
{
    public interface IStaffAwardService
    {
        #region CURD
        Task<StaffAwardFullDataModel> GetById(int? id);
        Task<List<StaffAwardFullDataModel>> GetListById(int? id);
        Task<BaseResponse?> Save(StaffAwardFullDataModel model);
        Task<BaseResponse?> DeleteAndActivate(int? id);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
