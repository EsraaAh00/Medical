using Microsoft.AspNetCore.Http;
using System.Security.Claims;


namespace JwtAuthenticationManager
{
    public class AuthenticationHelper
    {

        public static int? GetUserId()
        {

            try
            {
                string? val=new HttpContextAccessor()?.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (val == null) { 
                return null;
                }
                int userId = int.Parse(val);

                return userId;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static bool IsUserInRole(string role)
        {
            try
            {
                var curUser = new HttpContextAccessor()?.HttpContext?.User;
                return curUser?.IsInRole(role) ?? false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static string GetUserName()
        {
            try
            {
                return new HttpContextAccessor()?.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value ?? "";
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static int GetLanuage()
        {
            try
            {
                return (new HttpContextAccessor()?.HttpContext?.User.FindFirst(ClaimTypes.Locality)?.Value ?? "en") == "en" ? 1 : 2;
            }
            catch (Exception)
            {
                return 1;
            }
        }
        public static string? GetToken()
        {
            try
            {
                return new HttpContextAccessor()?.HttpContext?.Request?.Headers["Authorization"] ?? "";
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
