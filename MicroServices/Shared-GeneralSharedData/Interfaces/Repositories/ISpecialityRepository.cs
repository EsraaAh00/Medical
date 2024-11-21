using SharedModels.Models.Filter;
using SharedModels.Models;
using Shared_GeneralSharedData.Models.Speciality;

namespace Shared_GeneralSharedData.Interfaces.Repositories
{
    public interface ISpecialityRepository
    {
        #region CURD
        Task<SpecialityFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(SpecialityFullDataModel model);
        Task<PagedList<SpecialityFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        Task<List<BaseDropDown>?> GetDropDownList();
        Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
