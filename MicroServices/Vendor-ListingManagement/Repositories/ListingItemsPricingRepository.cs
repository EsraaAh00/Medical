using Vendor_ListingManagement.Models.ListingItemsPricing;
using Vendor_ListingManagement.Models;
using Vendor_ListingManagement.Entities;
using SharedModels.Models;
using Vendor_ListingManagement.Context;
using Vendor_ListingManagement.Mapping;
using Vendor_ListingManagement.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Vendor_ListingManagement.Entities.Logger;
using SharedModels.BaseRepository;
using Vendor_ListingManagement.MessageBrokerServices;
using SharedModels.Helpers;
namespace Vendor_ListingManagement.Repositories
{
    public class ListingItemsPricingRepository : BaseRespository<ListingItemsPricing, ListingItemsPricingLogger, ListingManagementContext>, IListingItemsPricingRepository
    {
        private readonly DbSet<ListingItemsPricing> _Set;

        public ListingItemsPricingRepository(ListingManagementContext context) : base(context, context.ListingItemsPricing)
        {
            _Set = context.ListingItemsPricing;
        }

        #region CURD
        public async Task<ListingItemsPricingFullDataModel?> GetById(int? id)
        {
            ListingItemsPricing? entity = await GetEntityById(id);
            return ListingItemsPricingMapping.EntityToFullDataModel(entity);
        }
        public async Task<BaseResponse?> Save(ListingItemsPricingFullDataModel model)
        {
            ListingItemsPricing? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<PagedList<ListingItemsPricingFullDataModel?>> GetPagedList(ListingItemsPricingFilter filter)
        {
            var query = _Set.AsNoTracking().Include(s => s.ListingItem).AsQueryable();
            if (filter.ListingItemId != 0)
            {
                query = query.Where(s => s.ListingItemId == filter.ListingItemId);
            }
            var pagedList = await PagedList<ListingItemsPricingFullDataModel?>.ToPagedList(query.Select(s => ListingItemsPricingMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
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