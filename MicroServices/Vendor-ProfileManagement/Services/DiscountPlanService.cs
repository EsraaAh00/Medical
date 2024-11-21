using SharedModels.Models;
using SharedModels.Helpers;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Interfaces.Repositories;
using Vendor_ProfileManagement.Models;
using Vendor_ProfileManagement.Models.DiscountPlan;
using SharedModels.Models.Filter;
namespace Vendor_ProfileManagement.Services
{
    public class DiscountPlanService : IDiscountPlanService
    {
        private readonly IDiscountPlanRepository _DiscountPlanRepository;
        public DiscountPlanService(IDiscountPlanRepository DiscountPlanRepository)
        {
            _DiscountPlanRepository = DiscountPlanRepository;
        }
        #region CURD
        public async Task<DiscountPlanFullDataModel?> GetById(int? id)
        {
            return await _DiscountPlanRepository.GetById(id);
        }
        public async Task<BaseResponse?> Save(DiscountPlanFullDataModel model)
        {
            return await _DiscountPlanRepository.Save(model); ;
        }
        public async Task<PagedList<DiscountPlanFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _DiscountPlanRepository.GetPagedList(filter);
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            return await _DiscountPlanRepository.GetDropDownList();
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            return await _DiscountPlanRepository.GetIncludeByIdsList(ids);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _DiscountPlanRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _DiscountPlanRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
