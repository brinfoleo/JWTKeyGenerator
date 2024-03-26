using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

public static class Token
{

    public static object Create(string _key, string role)
    {
        var key = Encoding.ASCII.GetBytes(_key);

        var tokenescriptor = new SecurityTokenDescriptor
        {
            Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role, role)
            }),
            
            Expires = DateTime.UtcNow.AddHours(3),

            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
             SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenescriptor);
        var torkenString = tokenHandler.WriteToken(token);

        return new
        {
            token = torkenString
        };
    }

}