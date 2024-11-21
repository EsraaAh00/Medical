using Facility_FacilityProfileManagement.Models.Facility;
using Facility_FacilityProfileManagement.Models.FacilityWorkSchedule;
using SharedModels.Models;
using SharedModels.Models.Filter;
using System.Linq.Expressions;
namespace Facility_FacilityProfileManagement.Interfaces.Services
{
    public interface IFacilityWorkScheduleService
    {
        #region CURD
        Task<FacilityWorkScheduleFullDataModel?> GetById(int? id);
        Task<List<FacilityWorkScheduleFullDataModel?>> GetListById(int? id);
        Task<BaseResponse?> Save(FacilityWorkScheduleFullDataModel model);
        Task<BaseResponse?> DeleteAndActivate(int? id);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
