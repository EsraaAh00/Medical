using SharedModels.Models;
using SharedModels.Models.Filter;
using Staff_StaffProfileManagement.Models.StaffAward;
namespace Staff_StaffProfileManagement.Interfaces.Repositories
{
    public interface IStaffAwardRepository
    {
        #region CURD
        Task<StaffAwardFullDataModel> GetById(int? id);
        Task<List<StaffAwardFullDataModel>> GetListById(int? id);
        Task<BaseResponse?> Save(StaffAwardFullDataModel model);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
