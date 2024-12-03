using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Abstraction.ModelInterfaces;
using System.Security.Cryptography;

namespace API.TokenProviders
{
    public class TokenProvider
    {
        private readonly IConfiguration _configuration;

        public TokenProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken(IUser user)
        {
            string? secretKey = _configuration["JwtSettings:SecretKey"];
            if (string.IsNullOrEmpty(secretKey))
            {
                throw new ArgumentNullException(nameof(secretKey), "Secret key cannot be null or empty.");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            if (!double.TryParse(_configuration["JwtSettings:ExpirationInMinutes"], out double expirationInMinutes))
            {
                throw new ArgumentException("Invalid expiration time in configuration.");
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                       new Claim(ClaimTypes.Name, user.Username),
                       new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                   }),
                Expires = DateTime.UtcNow.AddMinutes(expirationInMinutes),
                SigningCredentials = credentials,
                Issuer = _configuration["JwtSettings:Issuer"],
                Audience = _configuration["JwtSettings:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
            }
            return Convert.ToBase64String(randomNumber);
        }
    }
}
