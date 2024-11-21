using Vendor_ProfileManagement.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Models.Option;
namespace Vendor_ProfileManagement.Interfaces.Services
{
    public interface IOptionService
    {
        #region CURD
        Task<OptionFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(OptionFullDataModel model);
        Task<BaseResponse?> DeleteAndActivate(int? id);
        Task<PagedList<OptionFullDataModel?>> GetPagedList(ParentPagedFilterModel filter);
        Task<List<BaseDropDown>?> GetDropDownList();
        Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
