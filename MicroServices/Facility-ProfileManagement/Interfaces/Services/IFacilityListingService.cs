using Facility_FacilityProfileManagement.Models.Facility;
using Facility_FacilityProfileManagement.Models.FacilityListing;
using SharedModels.Models;
using SharedModels.Models.Filter;
using System.Linq.Expressions;
namespace Facility_FacilityProfileManagement.Interfaces.Services
{
    public interface IFacilityListingService
    {
        #region CURD
        Task<FacilityListingFullDataModel> GetById(int Id);
        Task<List<FacilityListingFullDataModel>> EntitiesById(int Id);
        Task<List<FacilityListingFullDataModel>> EntitiesBySpeciality(string Speciality);
        Task<List<FacilityListingFullDataModel>> EntitiesByIdSpeciality(int Id, string Speciality);
        Task<BaseResponse?> Save(List<FacilityListingFullDataModel> models);
        Task<BaseResponse?> DeleteAndActivate(int Id);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
