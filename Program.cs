var builder = WebApplication.CreateBuilder(args);

//Add Swagger Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
        return Token.Create(key,"Admin");
    
    return "User not found.";
});

app.Run();

record UserAuthentication(string User, string Password);