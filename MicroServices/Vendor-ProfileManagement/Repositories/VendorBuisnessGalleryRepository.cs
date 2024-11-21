using Vendor_ProfileManagement.Models.VendorBusinessGallery;
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
    public class VendorBusinessGalleryRepository : BaseRespository<VendorBusinessGallery, VendorBusinessGalleryLogger, ProfileManagementContext>, IVendorBusinessGalleryRepository
    {
        private readonly DbSet<VendorBusinessGallery> _Set;
        public VendorBusinessGalleryRepository(ProfileManagementContext context) : base(context, context.VendorBusinessGallery)
        {
            _Set = context.VendorBusinessGallery;
        }
        #region CURD
        public async Task<VendorBusinessGalleryFullDataModel?> GetById(int? id)
        {
            VendorBusinessGallery? entity = await GetEntityById(id);
            return VendorBusinessGalleryMapping.EntityToFullDataModel(entity);
        }
        public async Task<BaseResponse?> Save(VendorBusinessGalleryFullDataModel model)
        {
            VendorBusinessGallery? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<PagedList<VendorBusinessGalleryFullDataModel?>> GetPagedList(PagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().Include(s => s.VendorBusiness).AsQueryable();
            var pagedList = await PagedList<VendorBusinessGalleryFullDataModel?>.ToPagedList(query.Select(s => VendorBusinessGalleryMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
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
