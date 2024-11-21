using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Client_ClientProfileManagement.Entities
{
    public class ClientMedicalProfile : BaseModel
    {
        public virtual Client? Client { get; set; }
        [ForeignKey("Client")]
        public int? ClientId { get; set; }
        public string? MedicalConditions { get; set; }
        public string? Allergies { get; set; }
        public string? CurrentMedications { get; set; }
        public string? BloodType { get; set; }
        public bool? OrganDonor { get; set; }
        public bool? Smoker { get; set; }
        public bool? Alcoholic { get; set; }
        public bool? Active { get; set; }
        public string? MedicalNotes { get; set; }
    }
}
