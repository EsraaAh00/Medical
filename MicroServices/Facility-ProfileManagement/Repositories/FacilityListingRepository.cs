using SharedModels.Models;
using Microsoft.EntityFrameworkCore;
using SharedModels.BaseRepository;
using Facility_FacilityProfileManagement.Context;
using Facility_FacilityProfileManagement.Models.FacilityListing;
using Facility_FacilityProfileManagement.Interfaces.Repositories;
using Facility_FacilityProfileManagement.Entities;
using Facility_FacilityProfileManagement.Mapping;
using Facility_FacilityProfileManagement.Entities.Logger;
using Facility_FacilityProfileManagement.Models.Facility;
namespace Facility_FacilityProfileManagement.Repositories
{
    public class FacilityListingRepository : BaseRespository<FacilityListing, FacilityListingLogger, ProfileManagementContext>, IFacilityListingRepository
    {
        private readonly DbSet<FacilityListing> _Set;
        public FacilityListingRepository(ProfileManagementContext context) : base(context, context.FacilityListing)
        {
            _Set = context.FacilityListing;
        }

        #region CURD
        public async Task<FacilityListingFullDataModel> GetById(int Id)
        {
            FacilityListing? entity = await GetEntityById(Id);
            return FacilityListingMapping.EntityToFullDataModel(entity);
        }

        public async Task<List<FacilityListingFullDataModel>> EntitiesBySpeciality(string Speciality)
        {
            List<FacilityListing> entities = await GetEntitiesByCondition(e => e.Speciality == Speciality);
            return entities.Select(entity => FacilityListingMapping.EntityToFullDataModel(entity)).ToList();
        }

        public async Task<List<FacilityListingFullDataModel>> EntitiesById(int Id)
        {
            List<FacilityListing> entities = await GetEntitiesByCondition(e => e.FacilityId == Id);
            return entities.Select(entity => FacilityListingMapping.EntityToFullDataModel(entity)).ToList();
        }

        public async Task<List<FacilityListingFullDataModel>> EntitiesByIdSpeciality(int Id, string Speciality)
        {
            List<FacilityListing> entities = await GetEntitiesByCondition(e => e.FacilityId == Id);
            var entitiesfiltered = entities.Where(e => e.Speciality == Speciality);
            return entitiesfiltered.Select(entity => FacilityListingMapping.EntityToFullDataModel(entity)).ToList();
        }

        public async Task<BaseResponse?> Save(FacilityListingFullDataModel model)
        {
            FacilityListing? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await UndoEntity(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            List<LogModel?>? logger = await GetEntityLogByRecordIdOrTranactionsId(recordId, null);
            return logger;
        }
        #endregion
    }
}
