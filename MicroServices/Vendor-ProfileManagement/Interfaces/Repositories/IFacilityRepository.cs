using Vendor_ProfileManagement.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Models.Facility;
namespace Vendor_ProfileManagement.Interfaces.Repositories
{
    public interface IFacilityRepository
    {
        #region CURD
        Task<FacilityFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(FacilityFullDataModel model);
        Task<PagedList<FacilityFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        Task<List<BaseDropDown>?> GetDropDownList();
        Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
