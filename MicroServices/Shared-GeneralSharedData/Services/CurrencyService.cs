using SharedModels.Models;
using SharedModels.Helpers;
using Shared_GeneralSharedData.Interfaces.Services;
using Shared_GeneralSharedData.Interfaces.Repositories;
using Shared_GeneralSharedData.Models;
using Shared_GeneralSharedData.Models.Currency;
using SharedModels.Models.Filter;
namespace Shared_GeneralSharedData.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository _CurrencyRepository;
        public CurrencyService(ICurrencyRepository CurrencyRepository)
        {
            _CurrencyRepository = CurrencyRepository;
        }
        #region CURD
        public async Task<CurrencyFullDataModel?> GetById(int? id)
        {
            return await _CurrencyRepository.GetById(id);
        }
        public async Task<BaseResponse?> Save(CurrencyFullDataModel model)
        {
            return await _CurrencyRepository.Save(model); ;
        }
        public async Task<BaseResponse?> DeleteAndActivate(int? id)
        {
            CurrencyFullDataModel? model = await _CurrencyRepository.GetById(id);
            if (model != null)
            {
                model.IsDeleted = !(model.IsDeleted ?? false);

            }
            return await _CurrencyRepository.Save(model);
        }
        public async Task<PagedList<CurrencyFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _CurrencyRepository.GetPagedList(filter);
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            return await _CurrencyRepository.GetDropDownList();
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            return await _CurrencyRepository.GetIncludeByIdsList(ids);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _CurrencyRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _CurrencyRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
