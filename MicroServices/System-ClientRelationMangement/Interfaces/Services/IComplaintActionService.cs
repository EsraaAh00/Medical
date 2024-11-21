using SharedModels.Models.Filter;
using SharedModels.Models;
using System_ClientRelationMangement.Models.ComplaintAction;


namespace System_ClientRelationMangement.Interfaces.Services
{
    public interface IComplaintActionService
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





