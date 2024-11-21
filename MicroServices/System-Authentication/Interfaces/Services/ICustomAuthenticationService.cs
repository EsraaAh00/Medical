using SharedModels.Models;
using System.Threading.Tasks;
using System_Authentication.Models.Authentication;
using System_Authentication.Models.User;

namespace System_Authentication.Interfaces.Services
{
    public interface ICustomAuthenticationService
    {
        Task<AuthenticationResponseModel?> AuthenticateUser(LoginModel LoginForm);
        Task<BaseResponse?> AuthenticateGuest(string? Language, string? DeviceToken);
        Task<BaseResponse?> ChangeLanguage();
        Task<BaseResponse?> AuthenticateNewUser(UserFullDataModel NewUserForm);
        Task<BaseResponse?> ResetPassword(ResetPasswordModel? resetPassword);
    }
}
