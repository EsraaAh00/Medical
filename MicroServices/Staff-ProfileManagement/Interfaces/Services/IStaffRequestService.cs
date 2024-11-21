using SharedModels.Models;
using SharedModels.Models.Filter;
using Microsoft.AspNetCore.Mvc;
using Staff_StaffProfileManagement.Models.StaffRequest;

namespace Staff_StaffProfileManagement.Interfaces.Services
{
    public interface IStaffRequestService
    {
        #region CURD
        Task<StaffRequestFullDataModel> GetById(int? id);
        Task<List<StaffRequestFullDataModel>> GetListByState(int? state);
        Task<BaseResponse?> Save(StaffRequestFullDataModel model);
        Task<BaseResponse?> RequestSetRejected(RejectionModel rejection);
        Task<BaseResponse?> RequestSetAccepted(int id);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}