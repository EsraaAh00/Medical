using Vendor_ListingManagement.Models.ItemSubCategories;
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
    public class ItemSubCategoriesRepository : BaseRespository<ItemSubCategories, ItemSubCategoriesLogger, ListingManagementContext>, IItemSubCategoriesRepository
    {
        private readonly DbSet<ItemSubCategories> _Set;
        public ItemSubCategoriesRepository(ListingManagementContext context) : base(context, context.ItemSubCategories)
        {
            _Set = context.ItemSubCategories;
        }
        #region CURD
        public async Task<ItemSubCategoriesFullDataModel?> GetById(int? id)
        {
            ItemSubCategories? entity = await GetEntityById(id);
            return ItemSubCategoriesMapping.EntityToFullDataModel(entity);
        }
        public async Task<BaseResponse?> Save(ItemSubCategoriesFullDataModel model)
        {
            ItemSubCategories? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<PagedList<ItemSubCategoriesFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().AsQueryable();
            if (!filter.Name.IsNullOrEmpty())
            {
                query = query.Where(s => s.Name.Contains(filter.Name ?? "") || s.NameLocalized.Contains(filter.Name ?? ""));
            }
            var pagedList = await PagedList<ItemSubCategoriesFullDataModel?>.ToPagedList(query.Select(s => ItemSubCategoriesMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
            return pagedList;
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            List<BaseDropDown>? dropDownList = await _Set.AsNoTracking().Where(s => s.IsDeleted != true).Select(s => ItemSubCategoriesMapping.EntityToDropDownModel(s)).ToListAsync();
            return dropDownList;
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            List<OuterIncludeModel>? list = await _Set.AsNoTracking().Where(s => s.IsDeleted != true && ids.Contains(s.Id)).Select(s => ItemSubCategoriesMapping.EntityToOuterIncludeModel(s)).ToListAsync();
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
