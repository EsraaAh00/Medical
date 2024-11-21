using Shared_GeneralSharedData.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using Shared_GeneralSharedData.Models.Governorate;
namespace Shared_GeneralSharedData.Interfaces.Repositories
{
    public interface IGovernorateRepository
    {
        #region CURD
        Task<GovernorateFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(GovernorateFullDataModel model);
        Task<PagedList<GovernorateFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        Task<List<BaseDropDown>?> GetDropDownList(int? countryId);
        Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
