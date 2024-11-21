using System_Authentication.Models.User;
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
using System_Authentication.Models.Rank;
namespace System_Authentication.Repositories
{
    public class UserRepository : BaseRespositoryIdentityUser<User, UserLogger, AuthenticationContext>, IUserRepository
    {
        private readonly DbSet<User> _Set;
        public UserRepository(AuthenticationContext context) : base(context, context.User)
        {
            _Set = context.User;
        }
        #region CURD
        public async Task<UserFullDataModel?> GetById(int? id)
        {
            User? entity = await GetEntityById(id);
            return UserMapping.EntityToFullDataModel(entity);
        }
        public async Task<BaseResponse?> Save(UserFullDataModel model)
        {
            User? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<PagedList<UserFullDataModel?>> GetPagedList(PagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().Include(s=>s.UserRank).AsQueryable();
            var pagedList = await PagedList<UserFullDataModel?>.ToPagedList(query.Select(s => UserMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
            return pagedList;
        }

        public async Task<List<UserDataList>?> GetDataList()
        {
            List<UserDataList>? List = await _Set.AsNoTracking().Where(s => s.IsDeleted != true).Select(s => UserMapping.EntityToListModel(s)).ToListAsync();
            return List;
        }
        public async Task<int > CheckForRepetitationPhone(string? phone)
        {
            User? user = await _set.AsNoTracking().FirstOrDefaultAsync(s => s.PhoneNumber == phone);
            if (user == null) {
                return user?.Id??0;
            }
            return 0;
        }
        
        public async Task<int> CheckForRepetitationEmail(string? email)
        {
            User? user = await _set.AsNoTracking().FirstOrDefaultAsync(s => s.Email == email);
            if (user == null)
            {
                return user?.Id ?? 0;
            }
            return 0;
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
