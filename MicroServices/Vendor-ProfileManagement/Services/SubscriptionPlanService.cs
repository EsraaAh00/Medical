using SharedModels.Models;
using SharedModels.Helpers;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Interfaces.Repositories;
using Vendor_ProfileManagement.Models;
using Vendor_ProfileManagement.Models.SubscriptionPlan;
using SharedModels.Models.Filter;
namespace Vendor_ProfileManagement.Services
{
    public class SubscriptionPlanService : ISubscriptionPlanService
    {
        private readonly ISubscriptionPlanRepository _SubscriptionPlanRepository;
        public SubscriptionPlanService(ISubscriptionPlanRepository SubscriptionPlanRepository)
        {
            _SubscriptionPlanRepository = SubscriptionPlanRepository;
        }
        #region CURD
        public async Task<SubscriptionPlanFullDataModel?> GetById(int? id)
        {
            return await _SubscriptionPlanRepository.GetById(id);
        }
        public async Task<BaseResponse?> Save(SubscriptionPlanFullDataModel model)
        {
            return await _SubscriptionPlanRepository.Save(model); ;
        }
        public async Task<PagedList<SubscriptionPlanFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _SubscriptionPlanRepository.GetPagedList(filter);
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            return await _SubscriptionPlanRepository.GetDropDownList();
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            return await _SubscriptionPlanRepository.GetIncludeByIdsList(ids);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _SubscriptionPlanRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _SubscriptionPlanRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
