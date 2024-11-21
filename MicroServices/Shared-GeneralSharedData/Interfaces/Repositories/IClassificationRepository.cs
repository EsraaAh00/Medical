using Shared_GeneralSharedData.Models.Classification;
using SharedModels.Models.Filter;
using SharedModels.Models;

namespace Shared_GeneralSharedData.Interfaces.Repositories
{
    public interface IClassificationRepository
    {
        #region CURD
        Task<ClassificationFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(ClassificationFullDataModel model);
        Task<PagedList<ClassificationFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        Task<List<BaseDropDown>?> GetDropDownList();
        Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
