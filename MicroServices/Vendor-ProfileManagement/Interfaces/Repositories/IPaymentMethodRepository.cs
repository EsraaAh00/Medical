using Vendor_ProfileManagement.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Models.PaymentMethod;
namespace Vendor_ProfileManagement.Interfaces.Repositories
{
    public interface IPaymentMethodRepository
    {
        #region CURD
        Task<PaymentMethodFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(PaymentMethodFullDataModel model);
        Task<PagedList<PaymentMethodFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        Task<List<BaseDropDown>?> GetDropDownList();
        Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
