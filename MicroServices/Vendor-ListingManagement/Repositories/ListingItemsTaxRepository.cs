using Vendor_ListingManagement.Models.ListingItemsTax;
using Vendor_ListingManagement.Models;
using Vendor_ListingManagement.Entities;
using SharedModels.Models;
using SharedModels.Helpers;
using Vendor_ListingManagement.Context;
using Vendor_ListingManagement.Mapping;
using Vendor_ListingManagement.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Vendor_ListingManagement.Entities.Logger;
using SharedModels.BaseRepository;
using SharedModels.Models.Filter;
namespace Vendor_ListingManagement.Repositories
{
    public class ListingItemsTaxRepository : BaseRespository<ListingItemsTax, ListingItemsTaxLogger, ListingManagementContext>, IListingItemsTaxRepository
    {
        private readonly DbSet<ListingItemsTax> _Set;
        public ListingItemsTaxRepository(ListingManagementContext context) : base(context, context.ListingItemsTax)
        {
            _Set = context.ListingItemsTax;
        }
        #region CURD
        public async Task<ListingItemsTaxFullDataModel?> GetById(int? id)
        {
            ListingItemsTax? entity = await GetEntityById(id);
            return ListingItemsTaxMapping.EntityToFullDataModel(entity);
        }
        public async Task<BaseResponse?> Save(ListingItemsTaxFullDataModel model)
        {
            ListingItemsTax? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<PagedList<ListingItemsTaxFullDataModel?>> GetPagedList(PagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().Include(s => s.ListingItem).AsQueryable();
            var pagedList = await PagedList<ListingItemsTaxFullDataModel?>.ToPagedList(query.Select(s => ListingItemsTaxMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
            return pagedList;
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
