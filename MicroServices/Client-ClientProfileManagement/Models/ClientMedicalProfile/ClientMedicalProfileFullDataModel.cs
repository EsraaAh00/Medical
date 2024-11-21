﻿using SharedModels.Models;

namespace Client_ClientProfileManagement.Models.ClientMedicalProfile
{
    public class ClientMedicalProfileFullDataModel : BaseModel
    {
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
