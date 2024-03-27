using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.AddBuilders();

var app = builder.Build();

app.MapCategoryEndpoints();//Routes

app.UseSwagger();
app.UseSwaggerUI();

app.Run();

record UserAuthentication(string User, string Password);