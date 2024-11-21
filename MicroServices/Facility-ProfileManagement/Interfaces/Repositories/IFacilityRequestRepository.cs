using SharedModels.Models;
using SharedModels.Models.Filter;
using System.Linq.Expressions;
using Facility_FacilityProfileManagement.Models.FacilityRequest;
namespace Facility_FacilityProfileManagement.Interfaces.Repositories
{
    public interface IFacilityRequestRepository
    {
        #region CURD
        Task<FacilityRequestFullDataModel?> GetById(int? id);
        Task<List<FacilityRequestFullDataModel?>> GetListByState(int? state);
        Task<BaseResponse?> Save(FacilityRequestFullDataModel model);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}