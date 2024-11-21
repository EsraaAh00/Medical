using System_Authentication.Models.RoleGroup;
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
    public class RoleGroupRepository : BaseRespositoryIdentityRole<RoleGroup, RoleGroupLogger, AuthenticationContext>, IRoleGroupRepository
    {
        private readonly DbSet<RoleGroup> _Set;
        public RoleGroupRepository(AuthenticationContext context) : base(context, context.RoleGroup)
        {
            _Set = context.RoleGroup;
        }
        #region CURD
        public async Task<RoleGroupFullDataModel?> GetById(int? id)
        {
            RoleGroup? entity = await GetEntityById(id);
            return RoleGroupMapping.EntityToFullDataModel(entity);
        }
        public async Task<BaseResponse?> Save(RoleGroupFullDataModel model)
        {
            RoleGroup? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<PagedList<RoleGroupFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().AsQueryable();
            if (!filter.Name.IsNullOrEmpty())
            {
                query = query.Where(s => s.Name.Contains(filter.Name ?? "") || s.NameLocalized.Contains(filter.Name ?? ""));
            }
            var pagedList = await PagedList<RoleGroupFullDataModel?>.ToPagedList(query.Select(s => RoleGroupMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
            return pagedList;
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            List<BaseDropDown>? dropDownList = await _Set.AsNoTracking().Where(s => s.IsDeleted != true).Select(s => RoleGroupMapping.EntityToDropDownModel(s)).ToListAsync();
            return dropDownList;
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            List<OuterIncludeModel>? list = await _Set.AsNoTracking().Where(s => s.IsDeleted != true && ids.Contains(s.Id)).Select(s => RoleGroupMapping.EntityToOuterIncludeModel(s)).ToListAsync();
            return list;
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
