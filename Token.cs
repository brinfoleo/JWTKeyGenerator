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
            tokenq = torkenString
        };
    }

    public static object TokenValidation(string _key, string MyToken)
    {
        var handler = new JwtSecurityTokenHandler();
        var tokenS = handler.ReadToken(MyToken) as JwtSecurityToken;

        return new
        {
            Header = tokenS.Header,
            Subject = tokenS.Subject,
            ValidTo = tokenS.ValidTo,
            Actor = tokenS.Actor,
            Audiences = tokenS.Audiences,
            Claims = tokenS.Claims
        };

    }
}