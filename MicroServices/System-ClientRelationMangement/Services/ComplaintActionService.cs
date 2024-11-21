using System_ClientRelationMangement.Interfaces.Services;
using System_ClientRelationMangement.Interfaces.Repositories;
using System_ClientRelationMangement.Models.ComplaintAction;
using SharedModels.Models;
using SharedModels.Helpers;
using SharedModels.Models.Filter;

namespace System_ClientRelationMangement.Services
{
    public class ComplaintActionService : IComplaintActionService
    {

        private readonly IComplaintActionRepository _ComplaintActionRepository;
        public ComplaintActionService(IComplaintActionRepository ComplaintActionRepository)
        {
            _ComplaintActionRepository = ComplaintActionRepository;
        }

        #region CURD
        public async Task<ComplaintActionFullDataModel?> GetById(int? id)
        {
            return await _ComplaintActionRepository.GetById(id);
        }

        public async Task<BaseResponse?> Save(ComplaintActionFullDataModel model)
        {
            return await _ComplaintActionRepository.Save(model);
        }


        public async Task<PagedList<ComplaintActionFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _ComplaintActionRepository.GetPagedList(filter);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _ComplaintActionRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _ComplaintActionRepository.GetRecordLogger(recordId);
        }
        #endregion

    }
}