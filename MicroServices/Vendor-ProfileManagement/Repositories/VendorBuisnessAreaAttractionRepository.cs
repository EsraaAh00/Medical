using Vendor_ProfileManagement.Models.VendorBusinessAreaAttraction;
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
    public class VendorBusinessAreaAttractionRepository : BaseRespository<VendorBusinessAreaAttraction, VendorBusinessAreaAttractionLogger, ProfileManagementContext>, IVendorBusinessAreaAttractionRepository
    {
        private readonly DbSet<VendorBusinessAreaAttraction> _Set;
        public VendorBusinessAreaAttractionRepository(ProfileManagementContext context) : base(context, context.VendorBusinessAreaAttraction)
        {
            _Set = context.VendorBusinessAreaAttraction;
        }
        #region CURD
        public async Task<VendorBusinessAreaAttractionFullDataModel?> GetById(int? id)
        {
            VendorBusinessAreaAttraction? entity = await GetEntityById(id);
            return VendorBusinessAreaAttractionMapping.EntityToFullDataModel(entity);
        }
        public async Task<BaseResponse?> Save(VendorBusinessAreaAttractionFullDataModel model)
        {
            VendorBusinessAreaAttraction? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<PagedList<VendorBusinessAreaAttractionFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().Include(s => s.VendorBusiness).AsQueryable();
            if (!filter.Name.IsNullOrEmpty())
            {
                query = query.Where(s => s.Name.Contains(filter.Name ?? "") || s.NameLocalized.Contains(filter.Name ?? ""));
            }
            var pagedList = await PagedList<VendorBusinessAreaAttractionFullDataModel?>.ToPagedList(query.Select(s => VendorBusinessAreaAttractionMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
            return pagedList;
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            List<BaseDropDown>? dropDownList = await _Set.AsNoTracking().Where(s => s.IsDeleted != true).Select(s => VendorBusinessAreaAttractionMapping.EntityToDropDownModel(s)).ToListAsync();
            return dropDownList;
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            List<OuterIncludeModel>? list = await _Set.AsNoTracking().Where(s => s.IsDeleted != true && ids.Contains(s.Id)).Select(s => VendorBusinessAreaAttractionMapping.EntityToOuterIncludeModel(s)).ToListAsync();
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
