using Vendor_ProfileManagement.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Models.BusinessType;
namespace Vendor_ProfileManagement.Interfaces.Services
{
    public interface IBusinessTypeService
    {
        #region CURD
        Task<BusinessTypeFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(BusinessTypeFullDataModel model);
        Task<PagedList<BusinessTypeFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        Task<BaseResponse?> DeleteAndActivate(int? id);
        Task<List<BaseDropDown>?> GetDropDownList();
        Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
