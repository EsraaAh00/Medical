using SharedModels.Models;
using Microsoft.EntityFrameworkCore;
using SharedModels.BaseRepository;
using Facility_FacilityProfileManagement.Context;
using Facility_FacilityProfileManagement.Models.FacilityRequest;
using Facility_FacilityProfileManagement.Entities;
using Facility_FacilityProfileManagement.Interfaces.Repositories;
using Facility_FacilityProfileManagement.Mapping;
using Facility_FacilityProfileManagement.Entities.Logger;
namespace Facility_FacilityProfileManagement.Repositories
{
    public class FacilityRequestRepository : BaseRespository<FacilityRequest, FacilityRequestLogger, ProfileManagementContext>, IFacilityRequestRepository
    {
        private readonly DbSet<FacilityRequest> _Set;


        public FacilityRequestRepository(ProfileManagementContext context) : base(context, context.FacilityRequest)
        {
            _Set = context.FacilityRequest;
        }
        #region CURD
        public async Task<FacilityRequestFullDataModel?> GetById(int? id)
        {
            FacilityRequest? entity = await GetEntityById(id);
            return FacilityRequestMapping.EntityToFullDataModel(entity);
        }

        public async Task<List<FacilityRequestFullDataModel?>> GetListByState(int? state)
        {
            if (state == null) return new List<FacilityRequestFullDataModel?>();
            var entities = await _set.AsNoTracking().Where(p => p.RequestStatusCode == state).ToListAsync();
            var result = entities.Select(FacilityRequestMapping.EntityToFullDataModel).ToList();
            return result;
        }

        public async Task<BaseResponse?> Save(FacilityRequestFullDataModel model)
        {
            FacilityRequest? enitity = await GetEntityByIdWithTracking(model.Id);
            if (enitity == null)
            {
                enitity.RequestStatusCode = 0;
                var entityWithLog = enitity.FullDataModelToEntity(model);
                var issaved = await SaveAsync(entityWithLog);
                return new BaseResponse { IsError = false, Message = "Request Saved" };
            }
            return new BaseResponse { IsError = true, Message = "Failed to Save The Request" };
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