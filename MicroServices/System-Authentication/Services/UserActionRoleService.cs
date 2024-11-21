using SharedModels.Models;
using SharedModels.Helpers;
using System_Authentication.Interfaces.Services;
using System_Authentication.Interfaces.Repositories;
using System_Authentication.Models;
using System_Authentication.Models.UserActionRole;
using SharedModels.Models.Filter;
using System_Authentication.Validation;
using System_Authentication.Models.Rank;
using System_Authentication.Repositories;
namespace System_Authentication.Services
{
    public class UserActionRoleService : IUserActionRoleService
    {
        private readonly IUserActionRoleRepository _UserActionRoleRepository;
        public UserActionRoleService(IUserActionRoleRepository UserActionRoleRepository)
        {
            _UserActionRoleRepository = UserActionRoleRepository;
        }
        #region CURD
        public async Task<UserActionRoleFullDataModel?> GetById(int? id)
        {
            return await _UserActionRoleRepository.GetById(id);
        }
        public async Task<BaseResponse?> Save(UserActionRoleFullDataModel model)
        {
            BaseResponse Response = model.Validate();
            if (Response.IsError)
            {
                return Response;
            }
            return await _UserActionRoleRepository.Save(model); ;
        }
        public async Task<BaseResponse?> DeleteAndActivate(int? id)
        {
            UserActionRoleFullDataModel? model = await _UserActionRoleRepository.GetById(id);
            if (model != null)
            {
                model.IsDeleted = !(model.IsDeleted ?? false);

            }
            return await _UserActionRoleRepository.Save(model);
        }
        public async Task<PagedList<UserActionRoleFullDataModel?>> GetPagedList(PagedFilterModel filter)
        {
            return await _UserActionRoleRepository.GetPagedList(filter);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _UserActionRoleRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _UserActionRoleRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
