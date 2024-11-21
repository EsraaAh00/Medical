using SharedModels.Models;
using SharedModels.Helpers;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Interfaces.Repositories;
using Vendor_ProfileManagement.Models;
using Vendor_ProfileManagement.Models.VendorBusinessFacility;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Repositories;
using Vendor_ProfileManagement.Validation;
namespace Vendor_ProfileManagement.Services
{
    public class VendorBusinessFacilityService : IVendorBusinessFacilityService
    {
        private readonly IVendorBusinessFacilityRepository _VendorBusinessFacilityRepository;
        public VendorBusinessFacilityService(IVendorBusinessFacilityRepository VendorBusinessFacilityRepository)
        {
            _VendorBusinessFacilityRepository = VendorBusinessFacilityRepository;
        }
        #region CURD
        public async Task<VendorBusinessFacilityFullDataModel?> GetById(int? id)
        {
            return await _VendorBusinessFacilityRepository.GetById(id);
        }
        public async Task<BaseResponse?> DeleteAndActivate(int? id)
        {
            VendorBusinessFacilityFullDataModel? model = await _VendorBusinessFacilityRepository.GetById(id);
            if (model != null)
            {
                model.IsDeleted = !(model.IsDeleted ?? false);

            }
            return await _VendorBusinessFacilityRepository.Save(model);
        }
        public async Task<BaseResponse?> Save(VendorBusinessFacilityFullDataModel model)
        {
            BaseResponse Response = model.Validate();
            if (Response.IsError)
            {
                return Response;
            }
            return await _VendorBusinessFacilityRepository.Save(model);
        }
        public async Task<PagedList<VendorBusinessFacilityFullDataModel?>> GetPagedList(PagedFilterModel filter)
        {
            return await _VendorBusinessFacilityRepository.GetPagedList(filter);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _VendorBusinessFacilityRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _VendorBusinessFacilityRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
