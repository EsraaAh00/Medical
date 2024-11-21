using SharedModels.Models;
using SharedModels.Helpers;
using System_Authentication.Interfaces.Services;
using System_Authentication.Interfaces.Repositories;
using System_Authentication.Models;
using System_Authentication.Models.RoleGroup;
using SharedModels.Models.Filter;
using System_Authentication.Validation;
using System_Authentication.Models.Rank;
using System_Authentication.Repositories;
namespace System_Authentication.Services
{
    public class RoleGroupService : IRoleGroupService
    {
        private readonly IRoleGroupRepository _RoleGroupRepository;
        public RoleGroupService(IRoleGroupRepository RoleGroupRepository)
        {
            _RoleGroupRepository = RoleGroupRepository;
        }
        #region CURD
        public async Task<RoleGroupFullDataModel?> GetById(int? id)
        {
            return await _RoleGroupRepository.GetById(id);
        }
        public async Task<BaseResponse?> Save(RoleGroupFullDataModel model)
        {
            BaseResponse Response = model.Validate();
            if (Response.IsError)
            {
                return Response;
            }
            return await _RoleGroupRepository.Save(model); ;
        }
        public async Task<BaseResponse?> DeleteAndActivate(int? id)
        {
            RoleGroupFullDataModel? model = await _RoleGroupRepository.GetById(id);
            if (model != null)
            {
                model.IsDeleted = !(model.IsDeleted ?? false);

            }
            return await _RoleGroupRepository.Save(model);
        }
        public async Task<PagedList<RoleGroupFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _RoleGroupRepository.GetPagedList(filter);
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            return await _RoleGroupRepository.GetDropDownList();
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            return await _RoleGroupRepository.GetIncludeByIdsList(ids);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _RoleGroupRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _RoleGroupRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
