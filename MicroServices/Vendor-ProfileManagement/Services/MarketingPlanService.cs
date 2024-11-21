using SharedModels.Models;
using SharedModels.Helpers;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Interfaces.Repositories;
using Vendor_ProfileManagement.Models;
using Vendor_ProfileManagement.Models.MarketingPlan;
using SharedModels.Models.Filter;
namespace Vendor_ProfileManagement.Services
{
    public class MarketingPlanService : IMarketingPlanService
    {
        private readonly IMarketingPlanRepository _MarketingPlanRepository;
        public MarketingPlanService(IMarketingPlanRepository MarketingPlanRepository)
        {
            _MarketingPlanRepository = MarketingPlanRepository;
        }
        #region CURD
        public async Task<MarketingPlanFullDataModel?> GetById(int? id)
        {
            return await _MarketingPlanRepository.GetById(id);
        }
        public async Task<BaseResponse?> Save(MarketingPlanFullDataModel model)
        {
            return await _MarketingPlanRepository.Save(model); ;
        }
        public async Task<PagedList<MarketingPlanFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _MarketingPlanRepository.GetPagedList(filter);
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            return await _MarketingPlanRepository.GetDropDownList();
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            return await _MarketingPlanRepository.GetIncludeByIdsList(ids);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _MarketingPlanRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _MarketingPlanRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
