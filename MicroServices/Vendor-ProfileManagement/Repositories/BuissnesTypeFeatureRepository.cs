using Vendor_ProfileManagement.Models.BusinessTypeFeature;
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
    public class BusinessTypeFeatureRepository : BaseRespository<BusinessTypeFeature, BusinessTypeFeatureLogger, ProfileManagementContext>, IBusinessTypeFeatureRepository
    {
        private readonly DbSet<BusinessTypeFeature> _Set;
        public BusinessTypeFeatureRepository(ProfileManagementContext context) : base(context, context.BusinessTypeFeature)
        {
            _Set = context.BusinessTypeFeature;
        }
        #region CURD
        public async Task<BusinessTypeFeatureFullDataModel?> GetById(int? id)
        {
            BusinessTypeFeature? entity = await GetEntityById(id);
            return BusinessTypeFeatureMapping.EntityToFullDataModel(entity);
        }
        public async Task<BaseResponse?> Save(BusinessTypeFeatureFullDataModel model)
        {
            BusinessTypeFeature? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<PagedList<BusinessTypeFeatureFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().Include(s => s.BusinessType).Include(s => s.Feature).AsQueryable();
            if (!filter.Name.IsNullOrEmpty())
            {
                query = query.Where(s => (s.BusinessType.NameLocalized.Contains(filter.Name ?? "") || s.BusinessType.Name.Contains(filter.Name ?? "")) || (s.Feature.NameLocalized.Contains(filter.Name ?? "") || s.Feature.Name.Contains(filter.Name ?? "")));
            }
            var pagedList = await PagedList<BusinessTypeFeatureFullDataModel?>.ToPagedList(query.Select(s => BusinessTypeFeatureMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
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
