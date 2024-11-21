using SharedModels.Models.Filter;
using SharedModels.Models;
using Client_ClientRelationMangement.Models.ComplaintAction;

namespace Client_ClientRelationMangement.Interfaces.Repositories
{
    public interface IComplaintActionRepository
    {
        #region CURD
        Task<ComplaintActionFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(ComplaintActionFullDataModel model);
        Task<PagedList<ComplaintActionFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
