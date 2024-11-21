using Vendor_ProfileManagement.Models.VendorBusinessFacility;
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
    public class VendorBusinessFacilityRepository : BaseRespository<VendorBusinessFacility, VendorBusinessFacilityLogger, ProfileManagementContext>, IVendorBusinessFacilityRepository
    {
        private readonly DbSet<VendorBusinessFacility> _Set;
        public VendorBusinessFacilityRepository(ProfileManagementContext context) : base(context, context.VendorBusinessFacility)
        {
            _Set = context.VendorBusinessFacility;
        }
        #region CURD
        public async Task<VendorBusinessFacilityFullDataModel?> GetById(int? id)
        {
            VendorBusinessFacility? entity = await GetEntityById(id);
            return VendorBusinessFacilityMapping.EntityToFullDataModel(entity);
        }
        public async Task<BaseResponse?> Save(VendorBusinessFacilityFullDataModel model)
        {
            VendorBusinessFacility? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<PagedList<VendorBusinessFacilityFullDataModel?>> GetPagedList(PagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().Include(s => s.VendorBusiness).Include(s => s.Facility).AsQueryable();
            var pagedList = await PagedList<VendorBusinessFacilityFullDataModel?>.ToPagedList(query.Select(s => VendorBusinessFacilityMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
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
