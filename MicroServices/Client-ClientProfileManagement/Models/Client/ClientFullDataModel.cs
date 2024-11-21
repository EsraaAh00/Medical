using SharedModels.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Client_ClientProfileManagement.Models.Client
{
    public class ClientFullDataModel : FullyBaseModel
    {
        public int? UserId { get; set; }
        public string? Email { get; set; }
        public int? Phone { get; set; }
        public string? ProfilePhoto { get; set; }
        public int? Password { get; set; }
        public DateTime? BirthDate { get; set; }

        [NotMapped]
        public IFormFile? Image { set; get; }
    }
}
