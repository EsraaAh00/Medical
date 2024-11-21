using Vendor_ProfileManagement.Models.VendorBusinessFeature;
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
    public class VendorBusinessFeatureRepository : BaseRespository<VendorBusinessFeature, VendorBusinessFeatureLogger, ProfileManagementContext>, IVendorBusinessFeatureRepository
    {
        private readonly DbSet<VendorBusinessFeature> _Set;
        public VendorBusinessFeatureRepository(ProfileManagementContext context) : base(context, context.VendorBusinessFeature)
        {
            _Set = context.VendorBusinessFeature;
        }
        #region CURD
        public async Task<VendorBusinessFeatureFullDataModel?> GetById(int? id)
        {
            VendorBusinessFeature? entity = await GetEntityById(id);
            return VendorBusinessFeatureMapping.EntityToFullDataModel(entity);
        }
        public async Task<BaseResponse?> Save(VendorBusinessFeatureFullDataModel model)
        {
            VendorBusinessFeature? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<PagedList<VendorBusinessFeatureFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().Include(s => s.VendorBusiness).Include(s => s.Feature).AsQueryable();
            if (!filter.Name.IsNullOrEmpty())
            {
                query = query.Where(s => (s.Feature.NameLocalized.Contains(filter.Name ?? "") || s.Feature.Name.Contains(filter.Name ?? "")));
            }
            var pagedList = await PagedList<VendorBusinessFeatureFullDataModel?>.ToPagedList(query.Select(s => VendorBusinessFeatureMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
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
