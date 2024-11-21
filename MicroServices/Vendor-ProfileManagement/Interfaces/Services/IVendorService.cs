using Vendor_ProfileManagement.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Models.Vendor;
namespace Vendor_ProfileManagement.Interfaces.Services
{
    public interface IVendorService
    {
        #region CURD
        Task<VendorFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(VendorFullDataModel model);
        Task<PagedList<VendorFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        Task<List<BaseDropDown>?> GetDropDownList();
        Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids);
        Task<BaseResponse?> DeleteAndActivate(int? id);
        List<BaseDropDown>? GetStateEnumDropDownList();
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
