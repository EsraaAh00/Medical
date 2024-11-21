using JwtAuthenticationManager;
using JwtAuthenticationManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SharedModels.Helpers;
using SharedModels.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System_Authentication.Entities;
using System_Authentication.Interfaces.Repositories;
using System_Authentication.Interfaces.Services;
using System_Authentication.Models.Authentication;
using System_Authentication.Models.Rank;
using System_Authentication.Models.User;
using System_Authentication.MessageBrokerServices;

namespace System_Authentication.Services
{
    public class CustomAuthenticationService : ICustomAuthenticationService
    {

        private readonly IAuthenticationRepository _AuthenticationRepository;
        private readonly JwtTokenHandler _JwtTokenHandler;
        private readonly SignInManager<User> _SignInManager;
        private readonly UserManager<User> _UserManager;
        private readonly IUserRoleGroupRepository _UserRoleGroupRepository;
        private readonly IUserActionRoleRepository _UserActionRoleRepository;
        private readonly IRankRepository _RankRepository;
        private readonly IUserRepository _UserRepository;

        public CustomAuthenticationService(
            JwtTokenHandler JwtTokenHandler,
           IAuthenticationRepository AuthenticationRepository,
           SignInManager<User> SignInManager,
           UserManager<User> UserManager,
           IUserRoleGroupRepository UserRoleGroupRepository,
           IUserActionRoleRepository UserActionRoleRepository,
           IRankRepository RankRepository,
           IUserRepository UserRepository)
        {
            _SignInManager = SignInManager ?? throw new ArgumentNullException(nameof(SignInManager));
            _AuthenticationRepository = AuthenticationRepository;
            _JwtTokenHandler = JwtTokenHandler;
            _UserManager = UserManager;
            _UserActionRoleRepository = UserActionRoleRepository;
            _UserRoleGroupRepository = UserRoleGroupRepository;
            _RankRepository = RankRepository;
            _UserRepository = UserRepository;
        }

        public async Task<BaseResponse?> AuthenticateNewUser(UserFullDataModel NewUserForm)
        {
            return await _AuthenticationRepository.AuthenticateNewUser(NewUserForm, _UserManager);
        }

        public async Task<AuthenticationResponseModel?> AuthenticateUser(LoginModel LoginForm)
        {
            AuthenticationResponseModel? authenticationResponse = await _AuthenticationRepository.AuthenticateUser(LoginForm, _SignInManager);

            if (authenticationResponse != null && !authenticationResponse.IsError)
            {
                LoginedUserData loginedUser = new LoginedUserData();
                
                loginedUser.UserName = authenticationResponse?.UserName ?? "";
                loginedUser.Id = authenticationResponse?.UserId ?? 0;
                
                loginedUser.Language = LoginForm?.Language ?? "";
                if (authenticationResponse != null)
                {
                    User? user = await _UserManager.FindByIdAsync(authenticationResponse?.UserId.ToString());
                    RankFullDataModel? rank= await _RankRepository.GetById (user?.UserRankId);
                    authenticationResponse.UserType = rank?.Name;
                    authenticationResponse.Route = rank?.LandScreen;
                    loginedUser.UserType = authenticationResponse?.UserType ?? "";
                    loginedUser.roles = await _UserActionRoleRepository.GetUserActionRoleByUserId(loginedUser.Id);
                    authenticationResponse.Token = _JwtTokenHandler.GenrateJwtToken(loginedUser);
                }
            }
            return authenticationResponse;
        }

        public async Task<BaseResponse?> AuthenticateGuest(string ?Language,string ?DeviceToken)
        {
            BaseResponse response=  new BaseResponse();
            LoginedUserData loginedUser = new LoginedUserData();
            loginedUser.UserName = "Guest "+DateTime.Now.Nanosecond.ToString();
            loginedUser.Id = 0;
            loginedUser.UserType = "Guest";
            loginedUser.Language = Language ?? "";
            string ?GuestToken = _JwtTokenHandler.GenrateJwtToken(loginedUser);
            if (GuestToken != null)
            {
                response.IsError = false;
                NotificationModel notificationModel = new NotificationModel();
                notificationModel.DeviceToken = DeviceToken;
                notificationModel.Content = DeviceToken;
                NotifactionHelper.SendNotification(notificationModel);
                response.Message = GuestToken;
            }
            else {response.IsError = true;}
            return response;
        }


        public BaseResponse? GenerateGuestToken(string requestId)
        {
            var response = new BaseResponse();
            try
            {

                var guestToken = _JwtTokenHandler.GenerateGuestToken(0, new List<Claim> { new Claim("RequestId", requestId) });

                if (!string.IsNullOrEmpty(guestToken))
                {
                    response = new BaseResponse { IsError = false, Message = guestToken };
                }
                else
                {
                    response = new BaseResponse { IsError = true, Message = "Failed to generate guest token." };
                }
            }
            catch
            {

                response = new BaseResponse { IsError = true, Message = "An error occurred during token generation." };
            }

            return response;
        }


        public async Task<BaseResponse?> CheckGuestToken(string token)
        {
            var response = new BaseResponse();
            try
            {

                var requestId = _JwtTokenHandler.ValidateTokenAndExtractRequestId(token);

                if (requestId != null)
                {

                    var request = await MessageBrokerService.GetRequestStatus((requestId));
                    response = new BaseResponse { IsError = false, ReturnedValue = requestId};
                }
                else
                {
                    response = new BaseResponse { IsError = true, Message = "Failed to validate guest token or RequestId not found." };
                }
            }
            catch
            {
                response = new BaseResponse { IsError = true, Message = "An error occurred during token validation." };
            }

            return response;
        }

        public async Task<BaseResponse?> ResetPassword(ResetPasswordModel? resetPassword)
        {


            User? user = await _UserManager.FindByIdAsync(AuthenticationHelper.GetUserId()?.ToString() ?? "");
            if (user != null)
            {
                var _SigningResult = await _SignInManager.CheckPasswordSignInAsync(user, resetPassword?.OldPassword ?? "", false);
                if (_SigningResult.Succeeded)
                {
                    var token = await _UserManager.GeneratePasswordResetTokenAsync(user);

                    var result = await _UserManager.ResetPasswordAsync(user, token, resetPassword?.NewPassword ?? "");
                    if (result.Succeeded)
                    {
                        return new BaseResponse { IsError = false, Message = "PassWord Saved Successfully" };
                    }
                    else
                    {
                        return new BaseResponse { IsError = true, Message = "error" };


                    }
                }
            }
            return new BaseResponse { IsError = true, Message = "error" };



        }

        public async Task<BaseResponse?> ChangeLanguage()
        {
            AuthenticationResponseModel? authenticationResponse = await _AuthenticationRepository.AuthenticateUser(null, _SignInManager);

            if (authenticationResponse != null && !authenticationResponse.IsError)
            {
                LoginedUserData loginedUser = new LoginedUserData();

                loginedUser.UserName = authenticationResponse?.UserName ?? "";
                loginedUser.Id = authenticationResponse?.UserId ?? 0;
                loginedUser.Language = AuthenticationHelper.GetLanuage()==1 ? "ar":"en" ;
                if (authenticationResponse != null)
                {
                    User? user = await _UserManager.FindByIdAsync(authenticationResponse?.UserId.ToString());
                    RankFullDataModel? rank = await _RankRepository.GetById(user?.UserRankId);
                    authenticationResponse.UserType = rank?.Name;
                    authenticationResponse.Route = rank?.LandScreen;
                    loginedUser.UserType = authenticationResponse?.UserType ?? "";
                    loginedUser.roles = await _UserActionRoleRepository.GetUserActionRoleByUserId(loginedUser.Id);
                    authenticationResponse.Token = _JwtTokenHandler.GenrateJwtToken(loginedUser);
                }
            }
            return authenticationResponse;
        }
    }
}
