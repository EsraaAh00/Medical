using SharedModels.Models;
using SharedModels.Helpers;
using SharedModels.Models.Filter;
using Client_ClientRelationMangement.Models.Complaint;
using Client_ClientRelationMangement.Interfaces.Repositories;
using Client_ClientRelationMangement.Interfaces.Services;

namespace Client_ClientRelationMangement.Services
{
    public class ComplaintService : IComplaintService
    {

        private readonly IComplaintRepository _ComplaintRepository;
        public ComplaintService(IComplaintRepository ComplaintRepository)
        {
            _ComplaintRepository = ComplaintRepository;
        }

        #region CURD
        public async Task<ComplaintFullDataModel?> GetById(int? id)
        {
            return await _ComplaintRepository.GetById(id);
        }

        public async Task<BaseResponse?> Save(ComplaintFullDataModel model)
        {
            return await _ComplaintRepository.Save(model);
        }


        public async Task<PagedList<ComplaintFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _ComplaintRepository.GetPagedList(filter);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _ComplaintRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _ComplaintRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}