using SharedModels.Models;
using System.Linq.Expressions;
using Facility_FacilityProfileManagement.Models.FacilityRequest;

namespace Facility_FacilityProfileManagement.Interfaces.Services
{
    public interface IFacilityRequestService
    {
        #region CURD
        Task<FacilityRequestFullDataModel?> GetById(int? id);
        Task<List<FacilityRequestFullDataModel?>> GetListByState(int? state);
        Task<BaseResponse?> Save(FacilityRequestFullDataModel model);
        Task<BaseResponse?> RequestSetRejected(RejectionModel rejection);
        Task<BaseResponse?> RequestSetAccepted(int id);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}