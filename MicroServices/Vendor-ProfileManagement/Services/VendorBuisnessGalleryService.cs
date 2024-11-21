using SharedModels.Models;
using SharedModels.Helpers;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Interfaces.Repositories;
using Vendor_ProfileManagement.Models;
using Vendor_ProfileManagement.Models.VendorBusinessGallery;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Repositories;
using Vendor_ProfileManagement.Validation;
namespace Vendor_ProfileManagement.Services
{
    public class VendorBusinessGalleryService : IVendorBusinessGalleryService
    {
        private readonly IVendorBusinessGalleryRepository _VendorBusinessGalleryRepository;
        public VendorBusinessGalleryService(IVendorBusinessGalleryRepository VendorBusinessGalleryRepository)
        {
            _VendorBusinessGalleryRepository = VendorBusinessGalleryRepository;
        }
        #region CURD
        public async Task<VendorBusinessGalleryFullDataModel?> GetById(int? id)
        {
            return await _VendorBusinessGalleryRepository.GetById(id);
        }
        public async Task<BaseResponse?> DeleteAndActivate(int? id)
        {
            VendorBusinessGalleryFullDataModel? model = await _VendorBusinessGalleryRepository.GetById(id);
            if (model != null)
            {
                model.IsDeleted = !(model.IsDeleted ?? false);

            }
            return await _VendorBusinessGalleryRepository.Save(model);
        }
        public async Task<BaseResponse?> Save(VendorBusinessGalleryFullDataModel model)
        {
            BaseResponse Response = model.Validate();
            if (Response.IsError)
            {
                return Response;
            }
            if (model.GalleryImageFile != null)
            {
                model.GalleryImage = await UploadFilesHelper.UploadFile(model.GalleryImageFile, "Vendor-ProfileManagement/GalleryImage", model.GalleryImage);
            }
            return await _VendorBusinessGalleryRepository.Save(model);
        }
        public async Task<PagedList<VendorBusinessGalleryFullDataModel?>> GetPagedList(PagedFilterModel filter)
        {
            return await _VendorBusinessGalleryRepository.GetPagedList(filter);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _VendorBusinessGalleryRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _VendorBusinessGalleryRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
