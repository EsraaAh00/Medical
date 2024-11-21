using Shared_GeneralSharedData.Models.Currency;
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
    public class CurrencyRepository : BaseRespository<Currency, CurrencyLogger, GeneralSharedDataContext>, ICurrencyRepository
    {
        private readonly DbSet<Currency> _Set;
        public CurrencyRepository(GeneralSharedDataContext context) : base(context, context.Currency)
        {
            _Set = context.Currency;
        }
        #region CURD
        public async Task<CurrencyFullDataModel?> GetById(int? id)
        {
            Currency? entity = await GetEntityById(id);
            return CurrencyMapping.EntityToFullDataModel(entity);
        }
        public async Task<BaseResponse?> Save(CurrencyFullDataModel model)
        {
            Currency? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<PagedList<CurrencyFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().Include(s => s.Country).AsQueryable();
            if (!filter.Name.IsNullOrEmpty())
            {
                query = query.Where(s => s.NameLocalized.Contains(filter.Name ?? "") || s.Name.Contains(filter.Name ?? "") || s.PrefixLocalized.Contains(filter.Name ?? "") || s.Prefix.Contains(filter.Name ?? "") || s.Symbol.Contains(filter.Name ?? ""));
            }
            var pagedList = await PagedList<CurrencyFullDataModel?>.ToPagedList(query.Select(s => CurrencyMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
            return pagedList;
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            List<BaseDropDown>? dropDownList = await _Set.AsNoTracking().Where(s => s.IsDeleted != true).Select(s => CurrencyMapping.EntityToDropDownModel(s)).ToListAsync();
            return dropDownList;
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            List<OuterIncludeModel>? list = await _Set.AsNoTracking().Where(s => s.IsDeleted != true && ids.Contains(s.Id)).Select(s => CurrencyMapping.EntityToOuterIncludeModel(s)).ToListAsync();
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
