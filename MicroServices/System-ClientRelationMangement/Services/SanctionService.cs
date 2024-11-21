using System_ClientRelationMangement.Interfaces.Services;
using System_ClientRelationMangement.Interfaces.Repositories;
using System_ClientRelationMangement.Models.Sanction;
using SharedModels.Models;
using SharedModels.Helpers;
using SharedModels.Models.Filter;

namespace System_ClientRelationMangement.Services
{
    public class SanctionService :ISanctionService
    {

        private readonly ISanctionRepository _SanctionRepository;
        public SanctionService(ISanctionRepository SanctionRepository)
        {
            _SanctionRepository = SanctionRepository;
        }

        #region CURD
        public async Task<SanctionFullDataModel?> GetById(int? id)
        {
            return await _SanctionRepository.GetById(id);
        }

        public async Task<BaseResponse?> Save(SanctionFullDataModel model)
        {
            return await _SanctionRepository.Save(model);
        }


        public async Task<PagedList<SanctionFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _SanctionRepository.GetPagedList(filter);
        }
        #endregion

        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _SanctionRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _SanctionRepository.GetRecordLogger(recordId);
        }
        #endregion

    }
}