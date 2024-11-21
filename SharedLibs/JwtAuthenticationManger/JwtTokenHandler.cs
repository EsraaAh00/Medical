using JwtAuthenticationManager.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAuthenticationManager
{
    public class JwtTokenHandler
    {
        public const string JWT_SECURITY_KEY = "Hhllnf47saweriyfrH7J8m0jhkjfHDMDMcpvjdmcmqasodc";

        public JwtTokenHandler()
        {

        }
        public string? GenrateJwtToken(LoginedUserData loginedUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var Key = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var Claims = new ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.Name, loginedUser.UserName??""),
                        new Claim(ClaimTypes.Locality, loginedUser.Language??"en"),
                        new Claim(ClaimTypes.NameIdentifier,loginedUser.Id.ToString()??"")
                    });



            foreach (string? role in loginedUser.roles)
            {
                Claims.AddClaim(new Claim(ClaimTypes.Role, role ?? ""));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = Claims,
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256)
            };
            var tokenobj = tokenHandler.CreateToken(tokenDescriptor);
            string? token = tokenHandler.WriteToken(tokenobj);
            return token;


        }


        public string GenerateGuestToken(int id, IEnumerable<Claim>? additionalClaims = null)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);

            var claims = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, id.ToString())
            });

            if (additionalClaims != null)
            {
                claims.AddClaims(additionalClaims);
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddDays(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        public int? ValidateTokenAndExtractRequestId(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var claimsPrincipal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JWT_SECURITY_KEY)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out _);

                var requestIdClaim = claimsPrincipal.FindFirst("RequestId");
                return Int32.Parse(requestIdClaim.Value);
            }
            catch
            {
                return null;
            }
        }




    }
}
