using Vendor_ListingManagement.Models.ListingItem;
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
    public class ListingItemRepository : BaseRespository<ListingItem, ListingItemLogger, ListingManagementContext>, IListingItemRepository
    {
        private readonly DbSet<ListingItem> _Set;
        public ListingItemRepository(ListingManagementContext context) : base(context, context.ListingItem)
        {
            _Set = context.ListingItem;
        }
        #region CURD
        public async Task<ListingItemFullDataModel?> GetById(int? id)
        {
            ListingItem? entity = await _set.AsNoTracking().Where(s => s.Id == id)
                .Include("Details.ListingItemDetailSetting").FirstOrDefaultAsync();
            return ListingItemMapping.EntityToFullDataModel(entity);
        }

        public async Task<BaseResponse?> Save(ListingItemFullDataModel model)
        {
            ListingItem? entity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = entity.FullDataModelToEntity(model);
            var entityWithLogResponse = await SaveAsync(entityWithLog);

            if (entityWithLogResponse?.IsError == false)
            {
                return new BaseResponse
                {
                    IsError = false,
                    ReturnedValue = entityWithLogResponse.TargetId
                };
            }

            return new BaseResponse { IsError = true, Message = "Error saving entity" };
        }

        public async Task<PagedList<ListingItemFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().Include(s => s.ItemSubCategories).AsQueryable();
            if (!filter.Name.IsNullOrEmpty())
            {
                query = query.Where(s => s.Name.Contains(filter.Name ?? "") || s.NameLocalized.Contains(filter.Name ?? ""));
            }
            var pagedList = await PagedList<ListingItemFullDataModel?>.ToPagedList(query.Select(s => ListingItemMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
            return pagedList;
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            List<BaseDropDown>? dropDownList = await _Set.AsNoTracking().Where(s => s.IsDeleted != true).Select(s => ListingItemMapping.EntityToDropDownModel(s)).ToListAsync();
            return dropDownList;
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            List<OuterIncludeModel>? list = await _Set.AsNoTracking().Where(s => s.IsDeleted != true && ids.Contains(s.Id)).Select(s => ListingItemMapping.EntityToOuterIncludeModel(s)).ToListAsync();
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
