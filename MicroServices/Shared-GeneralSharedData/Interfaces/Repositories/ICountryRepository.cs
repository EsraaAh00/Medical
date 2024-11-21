using Shared_GeneralSharedData.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using Shared_GeneralSharedData.Models.Country;
namespace Shared_GeneralSharedData.Interfaces.Repositories
{
    public interface ICountryRepository
    {
        #region CURD
        Task<CountryFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(CountryFullDataModel model);
        Task<PagedList<CountryFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        Task<List<BaseDropDown>?> GetDropDownList();
        Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}