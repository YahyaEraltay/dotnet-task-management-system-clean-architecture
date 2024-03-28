using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Auth
{
    public class GenerateJwtToken : IGenerateJwtToken
    {
        private readonly IConfiguration _configuration;

        public GenerateJwtToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var securityKey = new SymmetricSecurityKey(key);
            if (securityKey.KeySize < 256)
            {
                var newKey = new byte[32];
                Array.Copy(key, newKey, Math.Min(key.Length, newKey.Length));
                securityKey = new SymmetricSecurityKey(newKey);
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.Email, user.Mail)
        }),
                Expires = DateTime.UtcNow.AddHours(1),
                Audience = _configuration["Jwt:Audience"],
                Issuer = _configuration["Jwt:Issuer"],
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
