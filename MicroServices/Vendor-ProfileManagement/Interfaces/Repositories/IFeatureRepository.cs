using Vendor_ProfileManagement.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Models.Feature;
namespace Vendor_ProfileManagement.Interfaces.Repositories
{
    public interface IFeatureRepository
    {
        #region CURD
        Task<FeatureFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(FeatureFullDataModel model);
        Task<PagedList<FeatureFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        Task<List<BaseDropDown>?> GetDropDownList();
        Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
