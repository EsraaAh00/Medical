using Facility_FacilityProfileManagement.Entities;
using Facility_FacilityProfileManagement.Interfaces.Repositories;
using Facility_FacilityProfileManagement.Interfaces.Services;
using Facility_FacilityProfileManagement.Mapping;
using Facility_FacilityProfileManagement.Models.Facility;
using Facility_FacilityProfileManagement.Models.FacilityListing;
using SharedModels.Helpers;
using SharedModels.Models;
using System.Collections.Generic;

namespace Facility_FacilityProfileManagement.Services
{
    public class FilterService: IFilterService
    {
        private readonly IFacilityRepository _FacilityRepository;
        private readonly IFacilityListingRepository _FacilityListingRepository;
        public FilterService(IFacilityRepository FacilityRepository, IFacilityListingRepository FacilityListingRepository)
        {
            _FacilityRepository = FacilityRepository;
            _FacilityListingRepository = FacilityListingRepository;
        }


        public async Task<List<FacilityFullDataModel>> GetList(string Speciality, double lat, double lng)
        {
            List<FacilityListingFullDataModel> SpecFaciliies = await _FacilityListingRepository.EntitiesBySpeciality(Speciality);
            List<int> facilityIds = SpecFaciliies
                .Where(f => f.FacilityId.HasValue)
                .Select(f => f.FacilityId.Value)
                .ToList();
            List<FacilityFullDataModel> Faciliies = await _FacilityRepository.GetListByIds(facilityIds);
            var facilitiesInCoverage = Faciliies.Where(facility =>
            {
                var distance = DistanceHelper.GetDistance(
                    new Location { Latitude = facility.Latitude, Longitude = facility.Longitude },
                    new Location { Latitude = lat, Longitude = lng }
                );
                return distance <= (facility.CoveredArea * 1000);
            }).ToList();
            return facilitiesInCoverage;
        }

        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _FacilityRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _FacilityRepository.GetRecordLogger(recordId);
        }
        #endregion

    }
}
