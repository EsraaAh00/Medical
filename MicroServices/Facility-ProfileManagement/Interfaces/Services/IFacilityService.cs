using SharedModels.Models;
using SharedModels.Models.Filter;
using System.Linq.Expressions;
using Facility_FacilityProfileManagement.Models.Facility;
namespace Facility_FacilityProfileManagement.Interfaces.Services
{
    public interface IFacilityService
    {
        #region CURD
        Task<FacilityFullDataModel> GetById(int Id);
        Task<List<FacilityFullDataModel>> GetListByIds(List<int> ids);
        Task<List<FacilityFullDataModel>> GetFilterList(string Type, double lat, double lng);
        Task<BaseResponse?> Save(FacilityFullDataModel model);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
