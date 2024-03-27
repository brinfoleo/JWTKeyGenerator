public static class BuilderExtensions
{
    public static void AddBuilders(this WebApplicationBuilder builder)
    {

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


    }

}