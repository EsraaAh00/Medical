using Vendor_ProfileManagement.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Models.VendorBusinessAreaAttraction;
namespace Vendor_ProfileManagement.Interfaces.Repositories
{
    public interface IVendorBusinessAreaAttractionRepository
    {
        #region CURD
        Task<VendorBusinessAreaAttractionFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(VendorBusinessAreaAttractionFullDataModel model);
        Task<PagedList<VendorBusinessAreaAttractionFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        Task<List<BaseDropDown>?> GetDropDownList();
        Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
