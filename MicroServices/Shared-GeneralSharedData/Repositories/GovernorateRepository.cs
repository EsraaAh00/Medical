using Shared_GeneralSharedData.Models.Governorate;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Shared_GeneralSharedData.Repositories
{
    public class GovernorateRepository : BaseRespository<Governorate, GovernorateLogger, GeneralSharedDataContext>, IGovernorateRepository
    {
        private readonly DbSet<Governorate> _Set;
        public GovernorateRepository(GeneralSharedDataContext context) : base(context, context.Governorate)
        {
            _Set = context.Governorate;
        }
        #region CURD
        public async Task<GovernorateFullDataModel?> GetById(int? id)
        {
            Governorate? entity = await GetEntityById(id);
            return GovernorateMapping.EntityToFullDataModel(entity);
        }
        public async Task<BaseResponse?> Save(GovernorateFullDataModel model)
        {
            Governorate? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<PagedList<GovernorateFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().Include(s => s.Country).AsQueryable();
            if (!filter.Name.IsNullOrEmpty())
            {
                query = query.Where(s => s.Name.Contains(filter.Name ?? "") || s.NameLocalized.Contains(filter.Name ?? ""));
            }
            var pagedList = await PagedList<GovernorateFullDataModel?>.ToPagedList(query.Select(s => GovernorateMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
            return pagedList;
        }
        public async Task<List<BaseDropDown>?> GetDropDownList(int? countryId)
        {
            var query = _Set.AsNoTracking().Where(s => s.IsDeleted != true);
            if (countryId.HasValue)
            {
                query = query.Where(s => s.CountryId == countryId);
            }

            List<BaseDropDown>? dropDownList = await query.Select(s => GovernorateMapping.EntityToDropDownModel(s)).ToListAsync();
            return dropDownList;
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            List<OuterIncludeModel>? list = await _Set.AsNoTracking().Where(s => s.IsDeleted != true && ids.Contains(s.Id)).Select(s => GovernorateMapping.EntityToOuterIncludeModel(s)).ToListAsync();
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
