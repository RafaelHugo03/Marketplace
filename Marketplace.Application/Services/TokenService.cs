using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Marketplace.Application.Models;
using Marketplace.Application.Services.Interfaces;
using Marketplace.Application.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace Marketplace.Application.Services
{
    public class TokenService : ITokenService
    {
        public string GenerateToken(UserDTO user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(TokenSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new []
                {
                    new Claim(ClaimTypes.Email, user.EmailAddress),
                    new Claim(ClaimTypes.SerialNumber, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.Now.AddHours(6),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), 
                    SecurityAlgorithms.HmacSha256),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public Guid GetIdInToken(HttpRequest request)
        {
            var token = request.Headers["Authorization"].ToString().Split(" ")[1];

            var payload = new JwtSecurityTokenHandler().ReadJwtToken(token);
            
            var id = payload.Claims.First(claim => claim.Type == "certserialnumber").Value;
            return Guid.Parse(id);
        }
    }
}