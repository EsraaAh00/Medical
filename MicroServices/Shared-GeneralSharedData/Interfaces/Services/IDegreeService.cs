using Shared_GeneralSharedData.Models.Degree;
using SharedModels.Models.Filter;
using SharedModels.Models;

namespace Shared_GeneralSharedData.Interfaces.Services
{
    public interface IDegreeService
    {
        #region CURD
        Task<DegreeFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(DegreeFullDataModel model);
        Task<PagedList<DegreeFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        Task<List<BaseDropDown>?> GetDropDownList();
        Task<BaseResponse?> DeleteAndActivate(int? id);
        Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
