using Vendor_ProfileManagement.Models.VendorBusinessPaymentMethod;
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
    public class VendorBusinessPaymentMethodRepository : BaseRespository<VendorBusinessPaymentMethod, VendorBusinessPaymentMethodLogger, ProfileManagementContext>, IVendorBusinessPaymentMethodRepository
    {
        private readonly DbSet<VendorBusinessPaymentMethod> _Set;
        public VendorBusinessPaymentMethodRepository(ProfileManagementContext context) : base(context, context.VendorBusinessPaymentMethod)
        {
            _Set = context.VendorBusinessPaymentMethod;
        }
        #region CURD
        public async Task<VendorBusinessPaymentMethodFullDataModel?> GetById(int? id)
        {
            VendorBusinessPaymentMethod? entity = await GetEntityById(id);
            return VendorBusinessPaymentMethodMapping.EntityToFullDataModel(entity);
        }
        public async Task<BaseResponse?> Save(VendorBusinessPaymentMethodFullDataModel model)
        {
            VendorBusinessPaymentMethod? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<PagedList<VendorBusinessPaymentMethodFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().Include(s => s.VendorBusiness).Include(s => s.PaymentMethod).AsQueryable();
            if (!filter.Name.IsNullOrEmpty())
            {
                query = query.Where(s => s.Name.Contains(filter.Name ?? "") || s.NameLocalized.Contains(filter.Name ?? ""));
            }
            var pagedList = await PagedList<VendorBusinessPaymentMethodFullDataModel?>.ToPagedList(query.Select(s => VendorBusinessPaymentMethodMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
            return pagedList;
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            List<BaseDropDown>? dropDownList = await _Set.AsNoTracking().Where(s => s.IsDeleted != true).Select(s => VendorBusinessPaymentMethodMapping.EntityToDropDownModel(s)).ToListAsync();
            return dropDownList;
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            List<OuterIncludeModel>? list = await _Set.AsNoTracking().Where(s => s.IsDeleted != true && ids.Contains(s.Id)).Select(s => VendorBusinessPaymentMethodMapping.EntityToOuterIncludeModel(s)).ToListAsync();
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
