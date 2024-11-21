using SharedModels.Models;
using Staff_StaffProfileManagement.Models.Staff;

namespace Staff_StaffProfileManagement.Interfaces.Services
{
    public interface IFilterService
    {
        #region CURD
        Task<List<StaffFullDataModel>> GetList(string? Speciality, string Day, double lat, double lng);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
