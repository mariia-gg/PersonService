using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using PersonService.Configuration;
using System.Security.Claims;
using System.Text;

namespace PersonService.Helpers
{
    public class SecurityHelper : ISecurityHelper
    {
        private readonly JwtConfiguration _jwtConfiguration;

        public SecurityHelper(JwtConfiguration jwtConfiguration)
        {
            _jwtConfiguration = jwtConfiguration;
        }

        public string GetJwtToken(string userName)
        {
            var key = Encoding.ASCII.GetBytes(_jwtConfiguration.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                        new Claim("Id", Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, userName),
                        new Claim(JwtRegisteredClaimNames.Email, userName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                     }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                Issuer = _jwtConfiguration.Issuer,
                Audience = _jwtConfiguration.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            var stringToken = tokenHandler.WriteToken(token);

            return stringToken;
        }
    }
}
