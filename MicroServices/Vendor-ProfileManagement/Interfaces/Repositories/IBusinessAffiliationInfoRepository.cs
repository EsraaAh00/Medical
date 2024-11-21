using Vendor_ProfileManagement.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Models.BusinessAffiliationInfo;
namespace Vendor_ProfileManagement.Interfaces.Repositories
{
    public interface IBusinessAffiliationInfoRepository
    {
        #region CURD
        Task<BusinessAffiliationInfoFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(BusinessAffiliationInfoFullDataModel model);
        Task<PagedList<BusinessAffiliationInfoFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        Task<List<BaseDropDown>?> GetDropDownList();
        Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
