using Vendor_ProfileManagement.Models.VendorBusinessPolicy;
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
    public class VendorBusinessPolicyRepository : BaseRespository<VendorBusinessPolicy, VendorBusinessPolicyLogger, ProfileManagementContext>, IVendorBusinessPolicyRepository
    {
        private readonly DbSet<VendorBusinessPolicy> _Set;
        public VendorBusinessPolicyRepository(ProfileManagementContext context) : base(context, context.VendorBusinessPolicy)
        {
            _Set = context.VendorBusinessPolicy;
        }
        #region CURD
        public async Task<VendorBusinessPolicyFullDataModel?> GetById(int? id)
        {
            VendorBusinessPolicy? entity = await GetEntityById(id);
            return VendorBusinessPolicyMapping.EntityToFullDataModel(entity);
        }
        public async Task<BaseResponse?> Save(VendorBusinessPolicyFullDataModel model)
        {
            VendorBusinessPolicy? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<PagedList<VendorBusinessPolicyFullDataModel?>> GetPagedList(PagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().Include(s => s.VendorBusiness).AsQueryable();
            var pagedList = await PagedList<VendorBusinessPolicyFullDataModel?>.ToPagedList(query.Select(s => VendorBusinessPolicyMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
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
