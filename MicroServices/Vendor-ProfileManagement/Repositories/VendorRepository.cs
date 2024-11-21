using Vendor_ProfileManagement.Models.Vendor;
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
    public class VendorRepository : BaseRespository<Vendor, VendorLogger, ProfileManagementContext>, IVendorRepository
    {
        private readonly DbSet<Vendor> _Set;
        public VendorRepository(ProfileManagementContext context) : base(context, context.Vendor)
        {
            _Set = context.Vendor;
        }
        #region CURD
        public async Task<VendorFullDataModel?> GetById(int? id)
        {
            Vendor? entity = await GetEntityById(id);
            return VendorMapping.EntityToFullDataModel(entity);
        }
        public async Task<BaseResponse?> Save(VendorFullDataModel model)
        {
            Vendor? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            var issaved = await SaveAsync(entityWithLog);
            if(issaved?.IsError == false)
            {
                var vendorId = _context.Vendor.Where(v => v.UserID == model.UserId).Select(u => u.Id).FirstOrDefault();
                return new BaseResponse { IsError = false, ReturnedValue = vendorId };
            }
            return new BaseResponse { IsError = true }; ;
        }
        public async Task<PagedList<VendorFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().Include(s => s.SubscriptionPlan).Include(s => s.MarketingPlan).Include(s => s.DiscountPlan).AsQueryable();
            if (!filter.Name.IsNullOrEmpty())
            {
                query = query.Where(s => s.NameLocalized.Contains(filter.Name ?? "") || s.Name.Contains(filter.Name ?? "") || s.ManagerFirstName.Contains(filter.Name ?? "") || s.ManagerLastName.Contains(filter.Name ?? ""));
            }
            var pagedList = await PagedList<VendorFullDataModel?>.ToPagedList(query.Select(s => VendorMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
            return pagedList;
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            List<BaseDropDown>? dropDownList = await _Set.AsNoTracking().Where(s => s.IsDeleted != true).Select(s => VendorMapping.EntityToDropDownModel(s)).ToListAsync();
            return dropDownList;
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            List<OuterIncludeModel>? list = await _Set.AsNoTracking().Where(s => s.IsDeleted != true && ids.Contains(s.Id)).Select(s => VendorMapping.EntityToOuterIncludeModel(s)).ToListAsync();
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
