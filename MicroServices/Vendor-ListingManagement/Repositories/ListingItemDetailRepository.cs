using Vendor_ListingManagement.Models.ListingItemDetail;
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
    public class ListingItemDetailRepository : BaseRespository<ListingItemDetail, ListingItemDetailLogger, ListingManagementContext>, IListingItemDetailRepository
    {
        private readonly DbSet<ListingItemDetail> _Set;
        public ListingItemDetailRepository(ListingManagementContext context) : base(context, context.ListingItemDetail)
        {
            _Set = context.ListingItemDetail;
        }
        #region CURD
        public async Task<ListingItemDetailFullDataModel?> GetById(int? id)
        {
            ListingItemDetail? entity = await GetEntityById(id);
            return ListingItemDetailMapping.EntityToFullDataModel(entity);
        }
        public async Task<BaseResponse?> Save(ListingItemDetailFullDataModel model)
        {
            ListingItemDetail? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<PagedList<ListingItemDetailFullDataModel?>> GetPagedList(PagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().Include(s => s.ListingItem).Include(s => s.ListingItemDetailSetting).AsQueryable();
            var pagedList = await PagedList<ListingItemDetailFullDataModel?>.ToPagedList(query.Select(s => ListingItemDetailMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
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
