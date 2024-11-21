using SharedModels.Models;
using SharedModels.Helpers;
using System_Authentication.Interfaces.Services;
using System_Authentication.Interfaces.Repositories;
using System_Authentication.Models;
using System_Authentication.Models.User;
using SharedModels.Models.Filter;
using System_Authentication.Validation;
using System_Authentication.Models.Rank;
using System_Authentication.Repositories;
namespace System_Authentication.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;
        private readonly ICustomAuthenticationService _CustomAuthenticationService;

        public UserService(IUserRepository UserRepository, ICustomAuthenticationService customAuthenticationService)
        {
            _UserRepository = UserRepository;
            _CustomAuthenticationService = customAuthenticationService;
        }
        #region CURD
        public async Task<UserFullDataModel?> GetById(int? id)
        {
            return await _UserRepository.GetById(id);
        }
        public async Task<BaseResponse?> Save(UserFullDataModel model)
        {
            BaseResponse? Response =await model.Validate(_UserRepository);
            if (Response.IsError)
            {
                return Response;
            }
            if (model.Id == 0)
            {
                return await _CustomAuthenticationService.AuthenticateNewUser(model);
            }
            return await _UserRepository.Save(model);
        }
        public async Task<BaseResponse?> DeleteAndActivate(int? id)
        {
            UserFullDataModel? model = await _UserRepository.GetById(id);
            if (model != null)
            {
                model.IsDeleted = !(model.IsDeleted ?? false);

            }
            return await _UserRepository.Save(model);
        }
        public async Task<PagedList<UserFullDataModel?>> GetPagedList(PagedFilterModel filter)
        {
            return await _UserRepository.GetPagedList(filter);
        }
        public async Task<List<UserDataList>?> GetDataList()
        {
            return await _UserRepository.GetDataList();
        }

        public async Task<BaseResponse?> CheckForRepetitationEmailAndPhone(string? email, string? phone)
        
        {
            BaseResponse response = new BaseResponse();

            int emailReponse = await _UserRepository.CheckForRepetitationEmail(email);
            int phoneReponse = await _UserRepository.CheckForRepetitationPhone(phone);

            if (emailReponse > 0)
            {
                response.Errors.Add(new ReposneError()
                {
                    Key = "Email",
                    Value = DicHelper.GetMessage("This E-mail already exist"),
                });

            }
            if (phoneReponse > 0)
            {
                response.Errors.Add(new ReposneError()
                {
                    Key = "Phone",
                    Value = DicHelper.GetMessage("This Phone already exist"),
                });

            }
            return response;

        }





        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _UserRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _UserRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
