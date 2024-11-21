using SharedModels.Models;
using SharedModels.Models.Filter;
using Staff_StaffProfileManagement.Models.Staff;
namespace Staff_StaffProfileManagement.Interfaces.Repositories
{
    public interface IStaffRepository
    {
        #region CURD
        Task<StaffFullDataModel> GetById(int Id);
        Task<List<StaffFullDataModel>> GetListByIds(List<int> ids);
        Task<List<StaffFullDataModel>> GetFilterList(string Type, string Speciality);
        Task<BaseResponse?> Save(StaffFullDataModel model);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
