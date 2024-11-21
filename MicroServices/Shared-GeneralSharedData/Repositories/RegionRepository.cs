using Shared_GeneralSharedData.Models.Region;
using Shared_GeneralSharedData.Models;
using Shared_GeneralSharedData.Entities;
using SharedModels.Models;
using SharedModels.Helpers;
using Shared_GeneralSharedData.Context;
using Shared_GeneralSharedData.Mapping;
using Shared_GeneralSharedData.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Shared_GeneralSharedData.Entities.Logger;
using SharedModels.BaseRepository;
using SharedModels.Models.Filter;
namespace Shared_GeneralSharedData.Repositories
{
    public class RegionRepository : BaseRespository<Region, RegionLogger, GeneralSharedDataContext>, IRegionRepository
    {
        private readonly DbSet<Region> _Set;
        public RegionRepository(GeneralSharedDataContext context) : base(context, context.Region)
        {
            _Set = context.Region;
        }
        #region CURD
        public async Task<RegionFullDataModel?> GetById(int? id)
        {
            Region? entity = await GetEntityById(id);
            return RegionMapping.EntityToFullDataModel(entity);
        }
        public async Task<BaseResponse?> Save(RegionFullDataModel model)
        {
            Region? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<PagedList<RegionFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().Include(s => s.Governorate).AsQueryable();
            if (!filter.Name.IsNullOrEmpty())
            {
                query = query.Where(s => s.NameLocalized.Contains(filter.Name ?? "") || s.Name.Contains(filter.Name ?? "") || (s.Governorate.NameLocalized.Contains(filter.Name ?? "") || s.Governorate.Name.Contains(filter.Name ?? "")) || s.NameKayes.Contains(filter.Name ?? ""));
            }
            var pagedList = await PagedList<RegionFullDataModel?>.ToPagedList(query.Select(s => RegionMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
            return pagedList;
        }
        public async Task<List<BaseDropDown>?> GetDropDownList(int GovernorateId)
        {
            List<BaseDropDown>? dropDownList = await _Set.AsNoTracking().Where(s => s.IsDeleted != true && s.GovernorateId == GovernorateId).Select(s => RegionMapping.EntityToDropDownModel(s)).ToListAsync();
            return dropDownList;
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            List<OuterIncludeModel>? list = await _Set.AsNoTracking().Where(s => s.IsDeleted != true && ids.Contains(s.Id)).Select(s => RegionMapping.EntityToOuterIncludeModel(s)).ToListAsync();
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
