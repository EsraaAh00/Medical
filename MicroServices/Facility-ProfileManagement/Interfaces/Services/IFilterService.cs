using Facility_FacilityProfileManagement.Models.Facility;
using SharedModels.Models;

namespace Facility_FacilityProfileManagement.Interfaces.Services
{
    public interface IFilterService
    {
        #region CURD
         Task<List<FacilityFullDataModel>> GetList(string Speciality, double lat , double lng);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
