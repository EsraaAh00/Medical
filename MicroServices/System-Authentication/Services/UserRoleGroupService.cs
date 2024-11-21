using SharedModels.Models;
using SharedModels.Helpers;
using System_Authentication.Interfaces.Services;
using System_Authentication.Interfaces.Repositories;
using System_Authentication.Models;
using System_Authentication.Models.UserRoleGroup;
using SharedModels.Models.Filter;
using System_Authentication.Validation;
using System_Authentication.Models.Rank;
using System_Authentication.Repositories;
namespace System_Authentication.Services
{
    public class UserRoleGroupService : IUserRoleGroupService
    {
        private readonly IUserRoleGroupRepository _UserRoleGroupRepository;
        public UserRoleGroupService(IUserRoleGroupRepository UserRoleGroupRepository)
        {
            _UserRoleGroupRepository = UserRoleGroupRepository;
        }
        #region CURD
        public async Task<UserRoleGroupFullDataModel?> GetById(int? id)
        {
            
            return await _UserRoleGroupRepository.GetById(id);
        }
        public async Task<BaseResponse?> Save(UserRoleGroupFullDataModel model)
        {
            BaseResponse Response = model.Validate();
            if (Response.IsError)
            {
                return Response;
            }
            return await _UserRoleGroupRepository.Save(model); ;
        }
        public async Task<BaseResponse?> DeleteAndActivate(int? id)
        {
            UserRoleGroupFullDataModel? model = await _UserRoleGroupRepository.GetById(id);
            if (model != null)
            {
                model.IsDeleted = !(model.IsDeleted ?? false);

            }
            return await _UserRoleGroupRepository.Save(model);
        }
        public async Task<PagedList<UserRoleGroupFullDataModel?>> GetPagedList(PagedFilterModel filter)
        {
            return await _UserRoleGroupRepository.GetPagedList(filter);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _UserRoleGroupRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _UserRoleGroupRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
