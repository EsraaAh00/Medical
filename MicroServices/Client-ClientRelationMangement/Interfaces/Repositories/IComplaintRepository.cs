﻿using SharedModels.Models.Filter;
using SharedModels.Models;
using Client_ClientRelationMangement.Models.Complaint;

namespace Client_ClientRelationMangement.Interfaces.Repositories
{
    public interface IComplaintRepository
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