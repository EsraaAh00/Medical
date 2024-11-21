using SharedModels.Models;
using SharedModels.Helpers;
using Vendor_ListingManagement.Interfaces.Services;
using Vendor_ListingManagement.Interfaces.Repositories;
using Vendor_ListingManagement.Models;
using Vendor_ListingManagement.Models.ListingItemPhotos;
namespace Vendor_ListingManagement.Services
{
    public class ListingItemPhotosService : IListingItemPhotosService
    {
        private readonly IListingItemPhotosRepository _ListingItemPhotosRepository;
        public ListingItemPhotosService(IListingItemPhotosRepository ListingItemPhotosRepository)
        {
            _ListingItemPhotosRepository = ListingItemPhotosRepository;
        }
        #region CURD
        public async Task<ListingItemPhotosFullDataModel?> GetById(int? id)
        {
            return await _ListingItemPhotosRepository.GetById(id);
        }
        public async Task<BaseResponse?> Save(ListingItemPhotosFullDataModel model)
        {
            if (model.ImageFile != null)
            {
                model.Image = await UploadFilesHelper.UploadFile(model.ImageFile, "Vendor-ListingManagement/Image", model.Image);
            }
            return await _ListingItemPhotosRepository.Save(model); ;
        }

        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _ListingItemPhotosRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _ListingItemPhotosRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
