using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PersonService.Configuration;

namespace PersonService.Helpers;

public class SecurityHelper : ISecurityHelper
{
    private const string _idClaim = "Id";
    private readonly JwtConfiguration _jwtConfiguration;

    public SecurityHelper(JwtConfiguration jwtConfiguration) => _jwtConfiguration = jwtConfiguration;

    public string GetJwtToken(string userName)
    {
        var key = Encoding.ASCII.GetBytes(_jwtConfiguration.Key);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(_idClaim, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Email, userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }),
            Expires = DateTime.UtcNow.AddMinutes(60),
            Issuer = _jwtConfiguration.Issuer,
            Audience = _jwtConfiguration.Audience,
            SigningCredentials
                = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = tokenHandler.WriteToken(token);

        return jwtToken;
    }

    public string GetUserName(string token)
    {
        var handler = new JwtSecurityTokenHandler();

        var jwtToken = handler.ReadJwtToken(token);

        var userName = jwtToken.Claims.First(c => c.Type == JwtRegisteredClaimNames.Sub).Value;

        return userName;
    }
}