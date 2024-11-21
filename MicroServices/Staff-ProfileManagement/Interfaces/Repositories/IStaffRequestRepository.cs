using SharedModels.Models;
using Staff_StaffProfileManagement.Models.StaffRequest;
namespace Staff_StaffProfileManagement.Interfaces.Repositories
{
    public interface IStaffRequestRepository
    {
        #region CURD
        Task<StaffRequestFullDataModel> GetById(int? id);
        Task<List<StaffRequestFullDataModel>> GetListByState(int? state);
        Task<BaseResponse?> Save(StaffRequestFullDataModel model);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}