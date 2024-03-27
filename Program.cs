using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//Add Swagger Services

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
    new()
    {
        Title = "JWT Key Generator",
        Version = "v1"
    }
    );
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}



app.MapGet("/", () => "JWT Key Generator");

app.MapPost("connect/token", (UserAuthentication userAuthentication) =>
{
    string key = "MinhaSenhaParaGerarToken";
    if (userAuthentication.User == "cliente" && userAuthentication.Password == "123")
        return Token.Create(key, "Admin");

    return "User not found.";
});

app.MapPost("connect/tokenValidate", (string token) =>
{
    string key = "MinhaSenhaParaGerarToken";

    return Token.TokenValidation(key, token);


});

app.Run();

record UserAuthentication(string User, string Password);