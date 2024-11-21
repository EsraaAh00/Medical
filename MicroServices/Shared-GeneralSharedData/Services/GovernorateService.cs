using SharedModels.Models;
using SharedModels.Helpers;
using Shared_GeneralSharedData.Interfaces.Services;
using Shared_GeneralSharedData.Interfaces.Repositories;
using Shared_GeneralSharedData.Models;
using Shared_GeneralSharedData.Models.Governorate;
using SharedModels.Models.Filter;
namespace Shared_GeneralSharedData.Services
{
    public class GovernorateService : IGovernorateService
    {
        private readonly IGovernorateRepository _GovernorateRepository;
        public GovernorateService(IGovernorateRepository GovernorateRepository)
        {
            _GovernorateRepository = GovernorateRepository;
        }
        #region CURD
        public async Task<GovernorateFullDataModel?> GetById(int? id)
        {
            return await _GovernorateRepository.GetById(id);
        }
        public async Task<BaseResponse?> Save(GovernorateFullDataModel model)
        {
            return await _GovernorateRepository.Save(model); ;
        }
        public async Task<BaseResponse?> DeleteAndActivate(int? id)
        {
            GovernorateFullDataModel? model = await _GovernorateRepository.GetById(id);
            if (model != null)
            {
                model.IsDeleted = !(model.IsDeleted ?? false);

            }
            return await _GovernorateRepository.Save(model);
        }
        public async Task<PagedList<GovernorateFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _GovernorateRepository.GetPagedList(filter);
        }
        public async Task<List<BaseDropDown>?> GetDropDownList(int? countryId)
        {
            return await _GovernorateRepository.GetDropDownList(countryId);
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            return await _GovernorateRepository.GetIncludeByIdsList(ids);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _GovernorateRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _GovernorateRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
