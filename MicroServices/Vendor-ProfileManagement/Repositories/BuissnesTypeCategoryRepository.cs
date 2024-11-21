using Vendor_ProfileManagement.Models.BusinessTypeCategory;
using Vendor_ProfileManagement.Models;
using Vendor_ProfileManagement.Entities;
using SharedModels.Models;
using SharedModels.Helpers;
using Vendor_ProfileManagement.Context;
using Vendor_ProfileManagement.Mapping;
using Vendor_ProfileManagement.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Vendor_ProfileManagement.Entities.Logger;
using SharedModels.BaseRepository;
using SharedModels.Models.Filter;
namespace Vendor_ProfileManagement.Repositories
{
    public class BusinessTypeCategoryRepository : BaseRespository<BusinessTypeCategory, BusinessTypeCategoryLogger, ProfileManagementContext>, IBusinessTypeCategoryRepository
    {
        private readonly DbSet<BusinessTypeCategory> _Set;
        public BusinessTypeCategoryRepository(ProfileManagementContext context) : base(context, context.BusinessTypeCategory)
        {
            _Set = context.BusinessTypeCategory;
        }
        #region CURD
        public async Task<BusinessTypeCategoryFullDataModel?> GetById(int? id)
        {
            BusinessTypeCategory? entity = await GetEntityById(id);
            return BusinessTypeCategoryMapping.EntityToFullDataModel(entity);
        }
        public async Task<BaseResponse?> Save(BusinessTypeCategoryFullDataModel model)
        {
            BusinessTypeCategory? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<PagedList<BusinessTypeCategoryFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().Include(s => s.BusinessType).AsQueryable();
            if (!filter.Name.IsNullOrEmpty())
            {
                query = query.Where(s => s.Name.Contains(filter.Name ?? "") || s.NameLocalized.Contains(filter.Name ?? ""));
            }
            var pagedList = await PagedList<BusinessTypeCategoryFullDataModel?>.ToPagedList(query.Select(s => BusinessTypeCategoryMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
            return pagedList;
        }
        public async Task<List<BaseDropDown>?> GetDropDownList(int ?BusinessTypeId)
        {
            List<BaseDropDown>? dropDownList = await _Set.AsNoTracking().Where(s => s.IsDeleted != true&&s.BusinessTypeId== BusinessTypeId).Select(s => BusinessTypeCategoryMapping.EntityToDropDownModel(s)).ToListAsync();
            return dropDownList;
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            List<OuterIncludeModel>? list = await _Set.AsNoTracking().Where(s => s.IsDeleted != true && ids.Contains(s.Id)).Select(s => BusinessTypeCategoryMapping.EntityToOuterIncludeModel(s)).ToListAsync();
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
