using Shared_GeneralSharedData.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using Shared_GeneralSharedData.Models.Region;
namespace Shared_GeneralSharedData.Interfaces.Services
{
    public interface IRegionService
    {
        #region CURD
        Task<RegionFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(RegionFullDataModel model);
        Task<BaseResponse?> DeleteAndActivate(int? id);
        Task<PagedList<RegionFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        Task<List<BaseDropDown>?> GetDropDownList(int GovernorateId);
        Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
