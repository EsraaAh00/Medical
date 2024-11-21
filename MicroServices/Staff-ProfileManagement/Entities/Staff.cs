using SharedModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Staff_StaffProfileManagement.Entities
{
    public class Staff : FullyBaseEnity
    {
        public int? UserId { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? Logo { get; set; }
        public string? Gender { get; set; }
        public string? Nationality { get; set; }
        public string? NationalId { get; set; }
        public string? About { get; set; }
        public string? AboutLocalized { get; set; }
        public string? MedicallicenseNumber { get; set; }
        public string? MedicallicenseAttachment { get; set; }
        public string? MedicallicenseExpiryDate { get; set; }
        public string? SatffType { get; set; }
        public string? Speciality { get; set; }
        public string? Classification { get; set; }
        public string? SubSpeciality { get; set; }
        public string? Degree { get; set; }
        public double? OfflineSessionFair { get; set; }
        public double? OnlineSessionFair { get; set; }
        public string? State { get; set; }
        public int? StateCode { get; set; }
    }
}
