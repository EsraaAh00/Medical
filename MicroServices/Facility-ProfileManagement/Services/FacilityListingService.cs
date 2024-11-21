using SharedModels.Models;
using SharedModels.Helpers;
using SharedModels.Models.Filter;
using Facility_FacilityProfileManagement.Models.FacilityListing;
using Facility_FacilityProfileManagement.Interfaces.Repositories;
using Facility_FacilityProfileManagement.Interfaces.Services;
namespace Facility_FacilityProfileManagement.Services
{
    public class FacilityListingService : IFacilityListingService
    {
        private readonly IFacilityListingRepository _FacilityListingRepository;
        public FacilityListingService(IFacilityListingRepository FacilityListingRepository)
        {
            _FacilityListingRepository = FacilityListingRepository;
        }
        #region CURD

        public async Task<FacilityListingFullDataModel> GetById(int Id)
        {
            return await _FacilityListingRepository.GetById(Id);
        }

        public async Task<List<FacilityListingFullDataModel>> EntitiesById(int Id)
        {
            return await _FacilityListingRepository.EntitiesById(Id);
        }

        public async Task<List<FacilityListingFullDataModel>> EntitiesBySpeciality(string Speciality)
        {
            return await _FacilityListingRepository.EntitiesBySpeciality(Speciality);
        }

        public async Task<List<FacilityListingFullDataModel>> EntitiesByIdSpeciality(int Id, string Speciality)
        {
            return await _FacilityListingRepository.EntitiesByIdSpeciality(Id,Speciality);
        }


        public async Task<BaseResponse?> Save(List<FacilityListingFullDataModel> models)
        {
            if (models == null || !models.Any()) return new BaseResponse { IsError = true, Message = "No models to save." };

            foreach (var model in models)
            {
                try
                {
                    await _FacilityListingRepository.Save(model);
                }
                catch
                {
                    return new BaseResponse { IsError = true, Message = "An error occurred while saving." };
                }
            }

            return new BaseResponse { IsError = false, Message = "Facility Registration Successful" };
        }



        public async Task<BaseResponse?> DeleteAndActivate(int Id)
        {
            FacilityListingFullDataModel? model = await _FacilityListingRepository.GetById(Id);
            if (model != null)
            {
                model.IsDeleted = !(model.IsDeleted ?? false);

            }
            return await _FacilityListingRepository.Save(model);
        }


        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _FacilityListingRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _FacilityListingRepository.GetRecordLogger(recordId);
        }


        #endregion
    }
}
