using Vendor_ListingManagement.Models.ListingItemPhotos;
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
namespace Vendor_ListingManagement.Repositories
{
    public class ListingItemPhotosRepository : BaseRespository<ListingItemPhotos, Logger, ListingManagementContext>, IListingItemPhotosRepository
    {
        private readonly DbSet<ListingItemPhotos> _Set;
        public ListingItemPhotosRepository(ListingManagementContext context) : base(context, context.ListingItemPhotos)
        {
            _Set = context.ListingItemPhotos;
        }
        #region CURD
        public async Task<ListingItemPhotosFullDataModel?> GetById(int? id)
        {
            ListingItemPhotos? entity = await GetEntityById(id);
            return ListingItemPhotosMapping.EntityToFullDataModel(entity);
        }
        public async Task<BaseResponse?> Save(ListingItemPhotosFullDataModel model)
        {
            ListingItemPhotos? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
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
