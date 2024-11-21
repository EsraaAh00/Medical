using Shared_GeneralSharedData.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using Shared_GeneralSharedData.Models.Currency;
namespace Shared_GeneralSharedData.Interfaces.Repositories
{
    public interface ICurrencyRepository
    {
        #region CURD
        Task<CurrencyFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(CurrencyFullDataModel model);
        Task<PagedList<CurrencyFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        Task<List<BaseDropDown>?> GetDropDownList();
        Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
