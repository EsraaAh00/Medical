using System_Authentication.Models.UserRoleGroup;
using System_Authentication.Models;
using System_Authentication.Entities;
using SharedModels.Models;
using SharedModels.Helpers;
using System_Authentication.Context;
using System_Authentication.Mapping;
using System_Authentication.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System_Authentication.Entities.Logger;
using SharedModels.BaseRepository;
using SharedModels.Models.Filter;
namespace System_Authentication.Repositories
{
    public class UserRoleGroupRepository : BaseRespository<UserRoleGroup, UserRoleGroupLogger, AuthenticationContext>, IUserRoleGroupRepository
    {
        private readonly DbSet<UserRoleGroup> _Set;
        public UserRoleGroupRepository(AuthenticationContext context) : base(context, context.UserRoleGroup)
        {
            _Set = context.UserRoleGroup;
        }
        #region CURD
        public async Task<UserRoleGroupFullDataModel?> GetById(int? id)
        {
            UserRoleGroup? entity = await GetEntityById(id);
            return UserRoleGroupMapping.EntityToFullDataModel(entity);
        }
        public async Task<BaseResponse?> Save(UserRoleGroupFullDataModel model)
        {
            UserRoleGroup? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<PagedList<UserRoleGroupFullDataModel?>> GetPagedList(PagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().Include(s => s.User).Include(s => s.RoleGroup).AsQueryable();
            var pagedList = await PagedList<UserRoleGroupFullDataModel?>.ToPagedList(query.Select(s => UserRoleGroupMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
            return pagedList;
        }
        public async Task<List<string?>> GetUserRolesByUserId(int userId)
        {
            List<string?> userRoles = await _Set.AsNoTracking().Include(s => s.RoleGroup).Where(s => s.UserId == userId && s.IsDeleted != true).Select(s => s.RoleGroup.NormalizedName).ToListAsync();
            return userRoles;
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
