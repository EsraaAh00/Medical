using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthenticationManager.Models
{
    public class LoginedUserData
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? UserType { get; set; }
        public int? RequestId { get; set; }
        public string? LandScreen { get; set; }
        public string? Language { get; set; }
        public List<string?> roles = new List<string?>();
    }
}
