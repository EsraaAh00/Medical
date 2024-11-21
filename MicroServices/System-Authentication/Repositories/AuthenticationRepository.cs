using JwtAuthenticationManager;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SharedModels.Models;
using System.Numerics;
using System_Authentication.Context;
using System_Authentication.Entities;
using System_Authentication.Interfaces.Repositories;
using System_Authentication.Migrations;
using System_Authentication.Models.Authentication;
using System_Authentication.Models.User;

namespace System_Authentication.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly AuthenticationContext _context;
        public AuthenticationRepository(AuthenticationContext context)
        {
            _context = context;
        }


        public async Task<BaseResponse> AuthenticateNewUser(UserFullDataModel newUserForm, UserManager<User> UserManager)
        {
            User User = new User
            {
                Email = newUserForm?.Email?.ToLower(),
                PhoneNumber = newUserForm?.PhoneNumber,
                Name = newUserForm?.Name,
                NormalizedUserName = newUserForm?.UserName?.ToLower(),
                NormalizedEmail = newUserForm?.Email?.ToLower(),
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                UserName = newUserForm?.UserName?.Trim().ToLower(),
                UserRankId= newUserForm?.UserRankId,

            };
            var SignUp = await UserManager.CreateAsync(User, newUserForm?.Password ?? "");
            if (SignUp.Succeeded)
            {
                var userId = _context.User.Where(u => u.PhoneNumber == User.PhoneNumber).Select(u => u.Id).FirstOrDefault();
                return new BaseResponse { IsError = false , ReturnedValue = userId };
            }

            return new BaseResponse { IsError = true };
        }

        public async Task<AuthenticationResponseModel> AuthenticateUser(LoginModel ?LoginForm, SignInManager<User> SignInManager)
        {
            User ?user;
            if (AuthenticationHelper.GetUserId().HasValue&& LoginForm==null)
            {
                user = await _context.User.AsNoTracking().FirstOrDefaultAsync(s => s.Id == AuthenticationHelper.GetUserId());
                List<string?> Roles = await _context.RoleGroup.AsNoTracking().Where(s => s.IsDeleted != true).Select(s => s.NormalizedName).ToListAsync();
                return new AuthenticationResponseModel { IsError = false, Message = "Sucess", Token = "", UserId = user.Id, UserName = user.UserName, Roles = Roles };

            }
            else
            {

                user = await _context.User.AsNoTracking().FirstOrDefaultAsync(s => (LoginForm!=null&&s.UserName == LoginForm.UserName));
            }
            if (user == null)
            {
                return new AuthenticationResponseModel { IsError = true, Message = "User Not Found", Token = "" };


            }
            else
            {



                 var SigningResult = await SignInManager.CheckPasswordSignInAsync(user, LoginForm?.Password ?? "", false);
                if (SigningResult != null)
                {
                    if (SigningResult.Succeeded)
                    {

                        List<string?> Roles = await _context.RoleGroup.AsNoTracking().Where(s => s.IsDeleted != true).Select(s => s.NormalizedName).ToListAsync();
                        return new AuthenticationResponseModel { IsError = false, Message = "Sucess", Token = "", UserId = user.Id, UserName = user.UserName, Roles = Roles };

                    }
                    else
                    {

                        return new AuthenticationResponseModel { IsError = true, Message = "Password Error", Token = "" };

                    }


                }
                else
                {

                    return new AuthenticationResponseModel { IsError = true, Message = "Password Error", Token = "" };

                }

            }


        }




    }
}
