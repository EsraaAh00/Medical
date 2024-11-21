using Shared_GeneralSharedData.Models.Country;
using Shared_GeneralSharedData.Models;
using Shared_GeneralSharedData.Entities;
using SharedModels.Models;
using SharedModels.Helpers;
using Shared_GeneralSharedData.Context;
using Shared_GeneralSharedData.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Shared_GeneralSharedData.Entities.Logger;
using SharedModels.BaseRepository;
using SharedModels.Models.Filter;
using Shared_GeneralSharedData.Mapping;
namespace Shared_GeneralSharedData.Repositories
{
    public class CountryRepository : BaseRespository<Country, CountryLogger, GeneralSharedDataContext>, ICountryRepository
    {
        private readonly DbSet<Country> _Set;
        public CountryRepository(GeneralSharedDataContext context) : base(context, context.Country)
        {
            _Set = context.Country;
        }
        #region CURD
        public async Task<CountryFullDataModel?> GetById(int? id)
        {
            Country? entity = await GetEntityById(id);
            return CountryMapping.EntityToFullDataModel(entity);
        }
        public async Task<BaseResponse?> Save(CountryFullDataModel model)
        {
            Country? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<PagedList<CountryFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().AsQueryable();
            if (!filter.Name.IsNullOrEmpty())
            {
                query = query.Where(s => s.NameLocalized.Contains(filter.Name ?? "") || s.Name.Contains(filter.Name ?? "") || s.Code.Contains(filter.Name ?? "") || s.ShortName.Contains(filter.Name ?? ""));
            }
            var pagedList = await PagedList<CountryFullDataModel?>.ToPagedList(query.Select(s => CountryMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
            return pagedList;
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            List<BaseDropDown>? dropDownList = await _Set.AsNoTracking().Where(s => s.IsDeleted != true).Select(s => CountryMapping.EntityToDropDownModel(s)).ToListAsync();
            return dropDownList;
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            List<OuterIncludeModel>? list = await _Set.AsNoTracking().Where(s => s.IsDeleted != true && ids.Contains(s.Id)).Select(s => CountryMapping.EntityToOuterIncludeModel(s)).ToListAsync();
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
