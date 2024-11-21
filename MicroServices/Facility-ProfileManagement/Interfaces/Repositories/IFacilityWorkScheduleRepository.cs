using SharedModels.Models;
using SharedModels.Models.Filter;
using System.Linq.Expressions;
using Facility_FacilityProfileManagement.Models.FacilityWorkSchedule;
using Facility_FacilityProfileManagement.Models.Facility;
namespace Facility_FacilityProfileManagement.Interfaces.Repositories
{
    public interface IFacilityWorkScheduleRepository
    {
        #region CURD
        Task<FacilityWorkScheduleFullDataModel?> GetById(int? id);
        Task<List<FacilityWorkScheduleFullDataModel?>> GetListById(int? id);
        Task<BaseResponse?> Save(FacilityWorkScheduleFullDataModel model);

        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
