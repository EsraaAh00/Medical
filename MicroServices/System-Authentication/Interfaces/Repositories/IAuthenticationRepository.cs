using Microsoft.AspNetCore.Identity;
using SharedModels.Models;
using System_Authentication.Entities;
using System_Authentication.Models.Authentication;
using System_Authentication.Models.User;

namespace System_Authentication.Interfaces.Repositories
{
    public interface IAuthenticationRepository
    {
        Task<AuthenticationResponseModel> AuthenticateUser(LoginModel ?LoginForm, SignInManager<User> SignInManager);
        Task<BaseResponse> AuthenticateNewUser(UserFullDataModel newUserForm, UserManager<User> UserManager);
    }
}
