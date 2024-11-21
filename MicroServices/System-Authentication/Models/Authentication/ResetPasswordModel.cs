namespace System_Authentication.Models.Authentication
{
    public class ResetPasswordModel
    {
        public string? OldPassword { set; get; } = "";
        public string? NewPassword { set; get; } = "";
    }
}
