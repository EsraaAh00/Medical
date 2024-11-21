using SharedModels.Models;
using SharedModels.Helpers;
using Shared_GeneralSharedData.Interfaces.Services;
using Shared_GeneralSharedData.Interfaces.Repositories;
using Shared_GeneralSharedData.Models;
using Shared_GeneralSharedData.Models.Region;
using SharedModels.Models.Filter;
namespace Shared_GeneralSharedData.Services
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _RegionRepository;
        public RegionService(IRegionRepository RegionRepository)
        {
            _RegionRepository = RegionRepository;
        }
        #region CURD
        public async Task<RegionFullDataModel?> GetById(int? id)
        {
            return await _RegionRepository.GetById(id);
        }
        public async Task<BaseResponse?> Save(RegionFullDataModel model)
        {
            return await _RegionRepository.Save(model); ;
        }
        public async Task<BaseResponse?> DeleteAndActivate(int? id)
        {
            RegionFullDataModel? model = await _RegionRepository.GetById(id);
            if (model != null)
            {
                model.IsDeleted = !(model.IsDeleted ?? false);

            }
            return await _RegionRepository.Save(model);
        }
        public async Task<PagedList<RegionFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _RegionRepository.GetPagedList(filter);
        }
        public async Task<List<BaseDropDown>?> GetDropDownList(int GovernorateId)
        {
            return await _RegionRepository.GetDropDownList(GovernorateId);
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            return await _RegionRepository.GetIncludeByIdsList(ids);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _RegionRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _RegionRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
