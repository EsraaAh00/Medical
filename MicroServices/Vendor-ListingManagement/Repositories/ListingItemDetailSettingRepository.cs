using Vendor_ListingManagement.Models.ListingItemDetailSetting;
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
    public class ListingItemDetailSettingRepository : BaseRespository<ListingItemDetailSetting, ListingItemDetailSettingLogger, ListingManagementContext>, IListingItemDetailSettingRepository
    {
        private readonly DbSet<ListingItemDetailSetting> _Set;
        public ListingItemDetailSettingRepository(ListingManagementContext context) : base(context, context.ListingItemDetailSetting)
        {
            _Set = context.ListingItemDetailSetting;
        }
        #region CURD
        public async Task<ListingItemDetailSettingFullDataModel?> GetById(int? id)
        {
            ListingItemDetailSetting? entity = await GetEntityById(id);
            return ListingItemDetailSettingMapping.EntityToFullDataModel(entity);
        }
        public async Task<List<ListingItemDetailSettingFullDataModel?>> GetFormByBusinessTypeCategoryId(int? id)
        {
            var modellist = new List<ListingItemDetailSettingFullDataModel?>();
            List<ListingItemDetailSetting> entities = await GetEntitiesByCondition(item => item.ItemCategory.BusinessTypeCategoryId == id);
            return entities.Select(s => ListingItemDetailSettingMapping.EntityToFullDataModel(s)).ToList();
           
        }
        public async Task<BaseResponse?> Save(ListingItemDetailSettingFullDataModel model)
        {
            ListingItemDetailSetting? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<List<ListingItemDetailSettingFullDataModel?>> GetItemSetting(int? id)
        {
            var modellist = new List<ListingItemDetailSettingFullDataModel?>();

            List<ListingItemDetailSetting> entities = await GetEntitiesByCondition(item => item.ItemCategoryId == id);

            foreach (var item in entities)
            {
                var fullDataModel = ListingItemDetailSettingMapping.EntityToFullDataModel(item);
                modellist.Add(fullDataModel);
            }

            return modellist;
        }
        public async Task<PagedList<ListingItemDetailSettingFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().AsQueryable();
            if (!filter.Name.IsNullOrEmpty())
            {
                query = query.Where(s => s.Name.Contains(filter.Name ?? "") || s.NameLocalized.Contains(filter.Name ?? ""));
            }
            var pagedList = await PagedList<ListingItemDetailSettingFullDataModel?>.ToPagedList(query.Select(s => ListingItemDetailSettingMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
            return pagedList;
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            List<BaseDropDown>? dropDownList = await _Set.AsNoTracking().Where(s => s.IsDeleted != true).Select(s => ListingItemDetailSettingMapping.EntityToDropDownModel(s)).ToListAsync();
            return dropDownList;
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            List<OuterIncludeModel>? list = await _Set.AsNoTracking().Where(s => s.IsDeleted != true && ids.Contains(s.Id)).Select(s => ListingItemDetailSettingMapping.EntityToOuterIncludeModel(s)).ToListAsync();
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
