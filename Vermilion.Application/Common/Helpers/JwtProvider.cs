using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Vermilion.Domain.Entities;
using Vermilion.Domain.Interfaces;

namespace Vermilion.Application.Common.Helpers
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _jwtOptions;
        public JwtProvider(IOptions<JwtOptions> options) => _jwtOptions = options.Value;
        public string Generate(User User)
        {
            Claim[] claims = {

                new(ClaimTypes.NameIdentifier, User.FullName.LastName),
                new(ClaimTypes.Email, User.Email),
                new(ClaimTypes.Role, User.Role.ToString()),
            };

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddMinutes(_jwtOptions.ExpiresMinutes));

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }
    }
}
