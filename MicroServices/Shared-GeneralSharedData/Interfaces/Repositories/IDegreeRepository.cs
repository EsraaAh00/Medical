using SharedModels.Models.Filter;
using SharedModels.Models;
using Shared_GeneralSharedData.Models.Degree;

namespace Shared_GeneralSharedData.Interfaces.Repositories
{
    public interface IDegreeRepository
    {
        #region CURD
        Task<DegreeFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(DegreeFullDataModel model);
        Task<PagedList<DegreeFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        Task<List<BaseDropDown>?> GetDropDownList();
        Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
