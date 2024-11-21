using Vendor_ProfileManagement.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Models.BusinessTypeCategory;
namespace Vendor_ProfileManagement.Interfaces.Services
{
    public interface IBusinessTypeCategoryService
    {
        #region CURD
        Task<BusinessTypeCategoryFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(BusinessTypeCategoryFullDataModel model);
        Task<BaseResponse?> DeleteAndActivate(int? id);
        Task<PagedList<BusinessTypeCategoryFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        Task<List<BaseDropDown>?> GetDropDownList(int ?BusinessTypeId);
        Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
