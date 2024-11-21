using SharedModels.Models;
namespace Staff_StaffProfileManagement.RefrenceModels
{
    public class UserFullDataModel : BaseModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int? UserRankId { get; set; }
        public string? UserRank { get; set; }

    }
}
