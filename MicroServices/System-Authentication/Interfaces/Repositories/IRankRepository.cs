using System_Authentication.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using System_Authentication.Models.Rank;
namespace System_Authentication.Interfaces.Repositories
{
    public interface IRankRepository
    {
        #region CURD
        Task<RankFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(RankFullDataModel model);
        Task<PagedList<RankFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        Task<List<BaseDropDown>?> GetDropDownList();
        Task<List<RankDataList>?> GetDataList();
        Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
