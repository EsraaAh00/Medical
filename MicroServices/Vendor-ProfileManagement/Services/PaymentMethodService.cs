using SharedModels.Models;
using SharedModels.Helpers;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Interfaces.Repositories;
using Vendor_ProfileManagement.Models;
using Vendor_ProfileManagement.Models.PaymentMethod;
using SharedModels.Models.Filter;
namespace Vendor_ProfileManagement.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IPaymentMethodRepository _PaymentMethodRepository;
        public PaymentMethodService(IPaymentMethodRepository PaymentMethodRepository)
        {
            _PaymentMethodRepository = PaymentMethodRepository;
        }
        #region CURD
        public async Task<PaymentMethodFullDataModel?> GetById(int? id)
        {
            return await _PaymentMethodRepository.GetById(id);
        }
        public async Task<BaseResponse?> Save(PaymentMethodFullDataModel model)
        {
            if (model.IconFile != null)
            {
                model.Icon = await UploadFilesHelper.UploadFile(model.IconFile, "Vendor-ProfileManagement/Icon", model.Icon);
            }
            return await _PaymentMethodRepository.Save(model); ;
        }
        public async Task<PagedList<PaymentMethodFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _PaymentMethodRepository.GetPagedList(filter);
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            return await _PaymentMethodRepository.GetDropDownList();
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            return await _PaymentMethodRepository.GetIncludeByIdsList(ids);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _PaymentMethodRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _PaymentMethodRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
