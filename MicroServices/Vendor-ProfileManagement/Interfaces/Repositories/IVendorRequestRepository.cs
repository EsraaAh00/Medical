using Vendor_ProfileManagement.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Models.VendorRequest;
namespace Vendor_ProfileManagement.Interfaces.Repositories
{
    public interface IVendorRequestRepository
    {
        #region CURD

        Task<VendorRequestFullDataModel?> GetById(int? id);
      
        Task<VendorRequestFullDataModel?> GetByNameLocalized(string? name);

        Task<BaseResponse?> Save(VendorRequestFullDataModel model);
        Task<PagedList<VendorRequestFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        Task<List<BaseDropDown>?> GetDropDownList();
        Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}