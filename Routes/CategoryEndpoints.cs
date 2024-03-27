public static class CategoryEndpoints
{

    public static void MapCategoryEndpoints(this WebApplication app)
    {

        string key = "MinhaSenhaParaGerarToken";

        app.MapGet("v1/", () => "JWT Key Generator");

        app.MapPost("v1/token", (UserAuthentication userAuthentication) =>
        {
            return Token.Create(key, "Admin");

        }).Produces<UserAuthentication>();//Show example of return

        app.MapPost("v1/tokenValidate", (string token) =>
        {

            return Token.TokenValidation(key, token);
        });

    }
}