using JwtAuthenticationManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedModels.Helpers;
using System_Authentication.Interfaces.Services;
using System_Authentication.Models.Authentication;
using System_Authentication.Models.User;

namespace System_Authentication.Controllers
{
    [Authorize]
    [ApiController]
    [Route("System/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ICustomAuthenticationService _CustomAuthenticationService;

        public AuthenticationController(ICustomAuthenticationService CustomAuthenticationService)
        {
            _CustomAuthenticationService = CustomAuthenticationService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult> AuthenticateUser(LoginModel LoginForm)
        {
            return Ok(await _CustomAuthenticationService.AuthenticateUser(LoginForm));

        }
        [HttpPost("SignUp")]
        [AllowAnonymous]
        public async Task<ActionResult> AuthenticateNewUser(UserFullDataModel model)
        {
            return Ok(await _CustomAuthenticationService.AuthenticateNewUser(model));
        }
        [HttpGet("AuthenticateGuest")]
        [AllowAnonymous]
        public async Task<ActionResult>  AuthenticateGuest(string? Language, string? DeviceToken){
            return Ok(await _CustomAuthenticationService.AuthenticateGuest(Language, DeviceToken));
        }

        [HttpGet("ChangeLanguage")]
       public async Task<ActionResult> ChangeLanguage()
        {
            return Ok(await _CustomAuthenticationService.ChangeLanguage());
        }

        [HttpPost("ResetPassword")]
        public async Task<ActionResult> ResetPassword(ResetPasswordModel resetPassword)
        {
            return Ok(await _CustomAuthenticationService.ResetPassword(resetPassword));
        }

    }
}
