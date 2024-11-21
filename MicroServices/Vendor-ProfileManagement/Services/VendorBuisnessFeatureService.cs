using SharedModels.Models;
using SharedModels.Helpers;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Interfaces.Repositories;
using Vendor_ProfileManagement.Models;
using Vendor_ProfileManagement.Models.VendorBusinessFeature;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Repositories;
using Vendor_ProfileManagement.Validation;
namespace Vendor_ProfileManagement.Services
{
    public class VendorBusinessFeatureService : IVendorBusinessFeatureService
    {
        private readonly IVendorBusinessFeatureRepository _VendorBusinessFeatureRepository;
        public VendorBusinessFeatureService(IVendorBusinessFeatureRepository VendorBusinessFeatureRepository)
        {
            _VendorBusinessFeatureRepository = VendorBusinessFeatureRepository;
        }
        #region CURD
        public async Task<VendorBusinessFeatureFullDataModel?> GetById(int? id)
        {
            return await _VendorBusinessFeatureRepository.GetById(id);
        }
        public async Task<BaseResponse?> DeleteAndActivate(int? id)
        {
            VendorBusinessFeatureFullDataModel? model = await _VendorBusinessFeatureRepository.GetById(id);
            if (model != null)
            {
                model.IsDeleted = !(model.IsDeleted ?? false);

            }
            return await _VendorBusinessFeatureRepository.Save(model);
        }
        public async Task<BaseResponse?> Save(VendorBusinessFeatureFullDataModel model)
        {
            BaseResponse Response = model.Validate();
            if (Response.IsError)
            {
                return Response;
            }
            return await _VendorBusinessFeatureRepository.Save(model);
        }
        public async Task<PagedList<VendorBusinessFeatureFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _VendorBusinessFeatureRepository.GetPagedList(filter);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _VendorBusinessFeatureRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _VendorBusinessFeatureRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
