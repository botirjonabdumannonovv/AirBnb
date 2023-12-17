namespace AirBnb.Server.Api.Configurations;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder
            .AddValidators()
            .AddMappers()
            .AddCaching()
            .AddCors()
            .AddBusinessLogicInfrastructure()
            .AddDevTools()
            .AddExposers();

        return new ValueTask<WebApplicationBuilder>(builder);
    }

    public static async ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app.SeedDataAsync();
        app.UseExposers()
            .UseDevTools()
            .UseCors()
            .UseStaticFiles();

        return app;
    }
}