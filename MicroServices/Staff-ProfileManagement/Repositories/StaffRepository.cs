using SharedModels.Models;
using Microsoft.EntityFrameworkCore;
using SharedModels.BaseRepository;
using SharedModels.Models.Filter;
using Staff_StaffProfileManagement.Models.Staff;
using Staff_StaffProfileManagement.Entities;
using Staff_StaffProfileManagement.Mapping;
using Staff_StaffProfileManagement.Interfaces.Repositories;
using Staff_StaffProfileManagement.Context;
using Staff_StaffProfileManagement.Entities.Logger;
using Staff_StaffProfileManagement.Models.StaffWorkSchedule;
namespace Staff_StaffProfileManagement.Repositories
{
    public class StaffRepository : BaseRespository<Staff, StaffLogger, ProfileManagementContext>, IStaffRepository
    {
        private readonly DbSet<Staff> _Set;
        public StaffRepository(ProfileManagementContext context) : base(context, context.Staff)
        {
            _Set = context.Staff;
        }
        #region CURD
        public async Task<StaffFullDataModel> GetById(int Id)
        {
            Staff? entity = await GetEntityById(Id);
            return StaffMapping.EntityToFullDataModel(entity);
        }

        public async Task<List<StaffFullDataModel>> GetListByIds(List<int> ids)
        {
            List<Staff> entities = await GetEntitiesByIds(ids);
            return entities.Select(StaffMapping.EntityToFullDataModel).ToList();
        }


        public async Task<List<StaffFullDataModel>> GetFilterList(string Type, string Speciality)
        {
            List<Staff> entities = await GetEntitiesByCondition(e => e.SatffType == Type);
            var entitiesfiltered = entities.Where(e => e.Speciality == Speciality);
            return entitiesfiltered.Select(entity => StaffMapping.EntityToFullDataModel(entity)).ToList();
        }


        public async Task<BaseResponse?> Save(StaffFullDataModel model)
        {
            Staff? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            var issaved = await SaveAsync(entityWithLog);
            if (issaved?.IsError == false)
            {
                var StaffId = _context.Staff.Where(v => v.UserId == model.UserId).Select(u => u.Id).FirstOrDefault();
                return new BaseResponse { IsError = false, ReturnedValue = StaffId };
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
