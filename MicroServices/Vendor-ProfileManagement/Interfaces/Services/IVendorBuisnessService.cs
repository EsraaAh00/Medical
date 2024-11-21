using Vendor_ProfileManagement.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Models.VendorBusiness;
namespace Vendor_ProfileManagement.Interfaces.Services
{
    public interface IVendorBusinessService
    {
        #region CURD
        Task<VendorBusinessFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(VendorBusinessFullDataModel model);
        Task<PagedList<VendorBusinessFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        Task<BaseResponse?> DeleteAndActivate(int? id);
        Task<List<BaseDropDown>?> GetDropDownList();
        Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids);
        List<BaseDropDown>? GetBusinessStatusEnumDropDownList();
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
