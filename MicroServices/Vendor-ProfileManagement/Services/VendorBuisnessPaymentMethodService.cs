using SharedModels.Models;
using SharedModels.Helpers;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Interfaces.Repositories;
using Vendor_ProfileManagement.Models;
using Vendor_ProfileManagement.Models.VendorBusinessPaymentMethod;
using SharedModels.Models.Filter;
namespace Vendor_ProfileManagement.Services
{
    public class VendorBusinessPaymentMethodService : IVendorBusinessPaymentMethodService
    {
        private readonly IVendorBusinessPaymentMethodRepository _VendorBusinessPaymentMethodRepository;
        public VendorBusinessPaymentMethodService(IVendorBusinessPaymentMethodRepository VendorBusinessPaymentMethodRepository)
        {
            _VendorBusinessPaymentMethodRepository = VendorBusinessPaymentMethodRepository;
        }
        #region CURD
        public async Task<VendorBusinessPaymentMethodFullDataModel?> GetById(int? id)
        {
            return await _VendorBusinessPaymentMethodRepository.GetById(id);
        }
        public async Task<BaseResponse?> Save(VendorBusinessPaymentMethodFullDataModel model)
        {
            return await _VendorBusinessPaymentMethodRepository.Save(model); ;
        }
        public async Task<PagedList<VendorBusinessPaymentMethodFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _VendorBusinessPaymentMethodRepository.GetPagedList(filter);
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            return await _VendorBusinessPaymentMethodRepository.GetDropDownList();
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            return await _VendorBusinessPaymentMethodRepository.GetIncludeByIdsList(ids);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _VendorBusinessPaymentMethodRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _VendorBusinessPaymentMethodRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
