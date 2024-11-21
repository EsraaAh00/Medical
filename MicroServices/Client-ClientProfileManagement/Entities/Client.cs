using SharedModels.Entities;

namespace Client_ClientProfileManagement.Entities
{
    public class Client : FullyBaseEnity
    {
        public int? UserId { get; set; }
        public string? Email { get; set; }
        public int? Phone { get; set; }
        public string? ProfilePhoto { get; set; }
        public int? Password { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
