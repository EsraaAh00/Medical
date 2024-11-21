namespace System_Authentication.Models.Authentication
{
    public class NewUserModel
    {
        public string? UserName { set; get; }
        public string? Email { set; get; }
        public string? Phone { set; get; }
        public string? Password { set; get; }
        public string DeviceToken { set; get; } = "";
        public bool? EmailConfirmation { set; get; }
        public bool? PhoneConfirmation { set; get; }
        public int? RankId { set; get; }
    }
}
