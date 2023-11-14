using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Authorize.Constants;
using Authorize.Models;

namespace Authorize.Services;

public class TokenGenerator
{
    public string Generate(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
             Subject = AddClaims(user),
             SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenConstants.Secret)),
                    SecurityAlgorithms.HmacSha256Signature
                ),
                Expires = DateTime.Now.AddDays(TokenConstants.DaysExpire)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private ClaimsIdentity AddClaims(User user) 
    {
        var claims = new ClaimsIdentity();

        claims.AddClaim(new Claim(ClaimTypes.Country, user.Country));
        claims.AddClaim(new Claim(ClaimTypes.Email, user.Email));
        
        return claims;
    }
}