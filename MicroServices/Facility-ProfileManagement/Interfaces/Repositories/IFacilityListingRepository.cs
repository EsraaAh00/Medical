using SharedModels.Models;
using SharedModels.Models.Filter;
using System.Linq.Expressions;
using Facility_FacilityProfileManagement.Models.FacilityListing;
using Facility_FacilityProfileManagement.Models.Facility;
namespace Facility_FacilityProfileManagement.Interfaces.Repositories
{
    public interface IFacilityListingRepository
    {
        #region CURD
        Task<FacilityListingFullDataModel> GetById(int Id);
        Task<List<FacilityListingFullDataModel>> EntitiesById(int Id);
        Task<List<FacilityListingFullDataModel>> EntitiesBySpeciality(string Speciality);
        Task<List<FacilityListingFullDataModel>> EntitiesByIdSpeciality(int Id , string Speciality);
        Task<BaseResponse?> Save(FacilityListingFullDataModel model);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
