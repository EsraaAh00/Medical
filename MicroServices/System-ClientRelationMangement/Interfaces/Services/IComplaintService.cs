using SharedModels.Models.Filter;
using SharedModels.Models;
using System_ClientRelationMangement.Models.Complaint;

namespace System_ClientRelationMangement.Interfaces.Services
{
    public interface IComplaintService
    {
        #region CURD
        Task<ComplaintFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(ComplaintFullDataModel model);
        Task<PagedList<ComplaintFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
