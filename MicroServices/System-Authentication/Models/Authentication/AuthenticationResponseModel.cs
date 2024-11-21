using SharedModels.Models;

namespace System_Authentication.Models.Authentication
{
    public class AuthenticationResponseModel : BaseResponse
    {

        public AuthenticationResponseModel()
        {
            Roles = new List<string?>();
        }
        public string? Token { set; get; }
        public string? Route { set; get; }
        public int? UserId { set; get; }
        public string? UserName { set; get; }
        public string? UserType { set; get; }

        public List<string?> Roles { set; get; }


    }
}
