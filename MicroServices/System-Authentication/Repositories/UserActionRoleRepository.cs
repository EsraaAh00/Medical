using System_Authentication.Models.UserActionRole;
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
    public class UserActionRoleRepository : BaseRespository<UserActionRole, UserActionRoleLogger, AuthenticationContext>, IUserActionRoleRepository
    {
        private readonly DbSet<UserActionRole> _Set;
        public UserActionRoleRepository(AuthenticationContext context) : base(context, context.UserActionRole)
        {
            _Set = context.UserActionRole;
        }
        #region CURD
        public async Task<UserActionRoleFullDataModel?> GetById(int? id)
        {
            UserActionRole? entity = await GetEntityById(id);
            return UserActionRoleMapping.EntityToFullDataModel(entity);
        }
        public async Task<BaseResponse?> Save(UserActionRoleFullDataModel model)
        {
            UserActionRole? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<PagedList<UserActionRoleFullDataModel?>> GetPagedList(PagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().Include(s => s.ActionRole).Include(s => s.User).AsQueryable();
            var pagedList = await PagedList<UserActionRoleFullDataModel?>.ToPagedList(query.Select(s => UserActionRoleMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
            return pagedList;
        }
        public async Task<List<string?>> GetUserActionRoleByUserId(int userId)
        {
           List<string?> userActionRoles = await _Set.AsNoTracking().Include(s => s.ActionRole).Where(s => s.UserId == userId && s.IsDeleted != true).Select(s => s.ActionRole.BaseName).ToListAsync();
            return userActionRoles;
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
