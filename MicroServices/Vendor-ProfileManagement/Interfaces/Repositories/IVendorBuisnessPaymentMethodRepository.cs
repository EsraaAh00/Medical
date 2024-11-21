using Vendor_ProfileManagement.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Models.VendorBusinessPaymentMethod;
namespace Vendor_ProfileManagement.Interfaces.Repositories
{
    public interface IVendorBusinessPaymentMethodRepository
    {
        #region CURD
        Task<VendorBusinessPaymentMethodFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(VendorBusinessPaymentMethodFullDataModel model);
        Task<PagedList<VendorBusinessPaymentMethodFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        Task<List<BaseDropDown>?> GetDropDownList();
        Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
