using System_Authentication.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using System_Authentication.Models.ActionRole;
namespace System_Authentication.Interfaces.Repositories
{
    public interface IActionRoleRepository
    {
        #region CURD
        Task<ActionRoleFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(ActionRoleFullDataModel model);
        Task<PagedList<ActionRoleFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        Task<List<BaseDropDown>?> GetDropDownList(int? roleGroupId);
        Task<List<ActionRoleDataList>?> GetDataList();
        Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
