using System_Authentication.Models.Rank;
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
using Microsoft.IdentityModel.Tokens;

namespace System_Authentication.Repositories
{
    public class RankRepository : BaseRespository<Rank, RankLogger, AuthenticationContext>, IRankRepository
    {
        private readonly DbSet<Rank> _Set;
        public RankRepository(AuthenticationContext context) : base(context, context.Rank)
        {
            _Set = context.Rank;
        }
        #region CURD
        public async Task<RankFullDataModel?> GetById(int? id)
        {
            Rank? entity = await GetEntityById(id);
            return RankMapping.EntityToFullDataModel(entity);
        }
        public async Task<BaseResponse?> Save(RankFullDataModel model)
        {
            Rank? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<PagedList<RankFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().AsQueryable();
             if (!filter.Name.IsNullOrEmpty())
            {
                query = query.Where(s => s.NameLocalized.Contains(filter.Name ?? "") || s.Name.Contains(filter.Name ?? "") || s.BaseName.Contains(filter.Name ?? ""));
            }
            var pagedList = await PagedList<RankFullDataModel?>.ToPagedList(query.Select(s => RankMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
            return pagedList;
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            List<BaseDropDown>? dropDownList = await _Set.AsNoTracking().Where(s => s.IsDeleted != true).Select(s => RankMapping.EntityToDropDownModel(s)).ToListAsync();
            return dropDownList;
        }
        public async Task<List<RankDataList>?> GetDataList()
        {
            List<RankDataList>? List = await _Set.AsNoTracking().Where(s => s.IsDeleted != true).Select(s => RankMapping.EntityToListModel(s)).ToListAsync();
            return List;
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            List<OuterIncludeModel>? list = await _Set.AsNoTracking().Where(s => s.IsDeleted != true && ids.Contains(s.Id)).Select(s => RankMapping.EntityToOuterIncludeModel(s)).ToListAsync();
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
