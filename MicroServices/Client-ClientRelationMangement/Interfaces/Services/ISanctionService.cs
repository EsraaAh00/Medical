﻿using SharedModels.Models.Filter;
using SharedModels.Models;
using Client_ClientRelationMangement.Models.Sanction;

namespace Client_ClientRelationMangement.Interfaces.Services
{
    public interface ISanctionService
    {
        #region CURD
        Task<SanctionFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(SanctionFullDataModel model);
        Task<PagedList<SanctionFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}