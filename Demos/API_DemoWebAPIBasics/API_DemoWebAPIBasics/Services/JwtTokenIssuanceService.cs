using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_DemoWebAPIBasics.Services
{
    public class JwtTokenIssuanceService
    {
        private readonly IConfiguration _configuration;

        public JwtTokenIssuanceService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(string userName, List<string> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name,userName)
            };

            roles.ForEach(role=> claims.Add(new Claim(ClaimTypes.Role,role)));
            var creds=new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(double.Parse(_configuration["Jwt:ExpiryInMinutes"])), 
                    signingCredentials:creds
                );
            return tokenHandler.WriteToken(token);
        }
    }
}
