using SharedModels.Models;
using SharedModels.Helpers;
using Microsoft.EntityFrameworkCore;
using SharedModels.BaseRepository;
using Facility_FacilityProfileManagement.Context;
using Facility_FacilityProfileManagement.Entities;
using Facility_FacilityProfileManagement.Models.Facility;
using Facility_FacilityProfileManagement.Interfaces.Repositories;
using Facility_FacilityProfileManagement.Entities.Logger;
using Facility_FacilityProfileManagement.Mapping;
namespace Facility_FacilityProfileManagement.Repositories
{
    public class FacilityRepository : BaseRespository<Facility, FacilityLogger, ProfileManagementContext>, IFacilityRepository
    {
        private readonly DbSet<Facility> _Set;
        public FacilityRepository(ProfileManagementContext context) : base(context, context.Facility)
        {
            _Set = context.Facility;
        }
        #region CURD


        public async Task<FacilityFullDataModel> GetById(int Id)
        {
            Facility? entity = await GetEntityById(Id);
            return FacilityMapping.EntityToFullDataModel(entity);
        }

        public async Task<List<FacilityFullDataModel>> GetListByIds(List<int> ids)
        {
            List<Facility> entities = await GetEntitiesByIds(ids);
            return entities.Select(FacilityMapping.EntityToFullDataModel).ToList();
        }


        public async Task<List<FacilityFullDataModel>> GetFilterList(string Type, double lat, double lng)
        {
            List<Facility> facilities = await GetEntitiesByCondition(f => f.FacilityType == Type);

            var facilitiesInCoverage = facilities.Where(facility =>
            {
                var distance = DistanceHelper.GetDistance(
                    new Location { Latitude = facility.Latitude, Longitude = facility.Longitude },
                    new Location { Latitude = lat, Longitude = lng }
                );
                return distance <= (facility.CoveredArea*1000);
            })
            .Select(FacilityMapping.EntityToFullDataModel)
            .ToList();

            return facilitiesInCoverage;
        }

        public async Task<BaseResponse?> Save(FacilityFullDataModel model)
        {
            Facility? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            var issaved = await SaveAsync(entityWithLog);
            if (issaved.IsError == false)
            {
                return new BaseResponse { IsError = false, ReturnedValue = issaved.TargetId };
            }
            return new BaseResponse { IsError = true }; ;
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
