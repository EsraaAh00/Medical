using System_Authentication.Models.ActionRole;
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
using System.Collections.Generic;
using System_Authentication.Models.Rank;

namespace System_Authentication.Repositories
{
    public class ActionRoleRepository : BaseRespository<ActionRole, ActionRoleLogger, AuthenticationContext>, IActionRoleRepository
    {
        private readonly DbSet<ActionRole> _Set;
        public ActionRoleRepository(AuthenticationContext context) : base(context, context.ActionRole)
        {
            _Set = context.ActionRole;
        }
        #region CURD
        public async Task<ActionRoleFullDataModel?> GetById(int? id)
        {
            ActionRole? entity = await GetEntityById(id);
            return ActionRoleMapping.EntityToFullDataModel(entity);
        }
        public async Task<BaseResponse?> Save(ActionRoleFullDataModel model)
        {
            ActionRole? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<PagedList<ActionRoleFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().Include(s => s.RoleGroup).AsQueryable();
            if (!filter.Name.IsNullOrEmpty())
            {
                query = query.Where(s => s.Name.Contains(filter.Name ?? "") || s.NameLocalized.Contains(filter.Name ?? "")).Include(s=>s.RoleGroup);
            }
            var pagedList = await PagedList<ActionRoleFullDataModel?>.ToPagedList(query.Select(s => ActionRoleMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
            return pagedList;
        }
        public async Task<List<BaseDropDown>?> GetDropDownList(int? roleGroupId)
        {
            List<BaseDropDown>? dropDownList = new List<BaseDropDown>();
            if (roleGroupId.HasValue)
            {
                dropDownList = await _Set.AsNoTracking().Where(s => s.IsDeleted != true && s.RoleGroupId == roleGroupId).Select(s => ActionRoleMapping.EntityToDropDownModel(s)).ToListAsync();
            }
            else
            {
                dropDownList = await _Set.AsNoTracking().Where(s => s.IsDeleted != true).Select(s => ActionRoleMapping.EntityToDropDownModel(s)).ToListAsync();
            }
            return dropDownList;
        }
        public async Task<List<ActionRoleDataList>?> GetDataList()
        {
            List<ActionRoleDataList>? List = await _Set.AsNoTracking().Where(s => s.IsDeleted != true).Select(s => ActionRoleMapping.EntityToListModel(s)).ToListAsync();
            return List;
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            List<OuterIncludeModel>? list = await _Set.AsNoTracking().Where(s => s.IsDeleted != true && ids.Contains(s.Id)).Select(s => ActionRoleMapping.EntityToOuterIncludeModel(s)).ToListAsync();
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
