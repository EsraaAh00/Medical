using SharedModels.Models;
using SharedModels.Helpers;
using System_Authentication.Interfaces.Services;
using System_Authentication.Interfaces.Repositories;
using System_Authentication.Models;
using System_Authentication.Models.ActionRole;
using SharedModels.Models.Filter;
using System_Authentication.Entities;
using System_Authentication.Validation;
using System_Authentication.Models.Rank;
using System_Authentication.Repositories;

namespace System_Authentication.Services
{
    public class ActionRoleService : IActionRoleService
    {
        private readonly IActionRoleRepository _ActionRoleRepository;
        public ActionRoleService(IActionRoleRepository ActionRoleRepository)
        {
            _ActionRoleRepository = ActionRoleRepository;
        }
        #region CURD
        public async Task<ActionRoleFullDataModel?> GetById(int? id)
        {
            return await _ActionRoleRepository.GetById(id);
        }
        public async Task<BaseResponse?> Save(ActionRoleFullDataModel model)
        {
            BaseResponse Response = model.Validate();
            if (Response.IsError)
            {
                return Response;
            }
            return await _ActionRoleRepository.Save(model); ;
        }
        public async Task<BaseResponse?> DeleteAndActivate(int? id)
        {
            ActionRoleFullDataModel? model = await _ActionRoleRepository.GetById(id);
            if (model != null)
            {
                model.IsDeleted = !(model.IsDeleted ?? false);

            }
            return await _ActionRoleRepository.Save(model);
        }
        public async Task<PagedList<ActionRoleFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _ActionRoleRepository.GetPagedList(filter);
        }
        public async Task<List<BaseDropDown>?> GetDropDownList(int? roleGroupId)
        {
            return await _ActionRoleRepository.GetDropDownList(roleGroupId);
        }
        public async Task<List<ActionRoleDataList>?> GetDataList()
        {
            return await _ActionRoleRepository.GetDataList();
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            return await _ActionRoleRepository.GetIncludeByIdsList(ids);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _ActionRoleRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _ActionRoleRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
