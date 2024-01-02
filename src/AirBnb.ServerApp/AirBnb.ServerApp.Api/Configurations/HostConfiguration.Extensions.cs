using System.Reflection;
using AirBnb.Server.Api.Data;
using AirBnb.ServerApp.Application.Common.Serializers;
using AirBnb.ServerApp.Application.Listings.Services;
using AirBnb.ServerApp.Application.Locations.Services;
using AirBnb.ServerApp.Application.RequestContexts.Brokers;
using AirBnb.ServerApp.Infrastructure.Common.Caching.Brokers;
using AirBnb.ServerApp.Infrastructure.Common.Caching.Settings;
using AirBnb.ServerApp.Infrastructure.Common.Serializers;
using AirBnb.ServerApp.Infrastructure.Listings.Services;
using AirBnb.ServerApp.Infrastructure.Locations.Services;
using AirBnb.ServerApp.Infrastructure.RequestContexts.Brokers;
using AirBnb.ServerApp.Infrastructure.StorageFiles.Settings;
using AirBnb.ServerApp.Persistence.Caching.Brokers;
using AirBnb.ServerApp.Persistence.DataContexts;
using AirBnb.ServerApp.Persistence.Repositories;
using AirBnb.ServerApp.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AirBnb.Server.Api.Configurations;

public static partial class HostConfiguration
{
    private static readonly ICollection<Assembly> Assemblies;

    static HostConfiguration()
    {
        Assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
        Assemblies.Add(Assembly.GetExecutingAssembly());
    }
    
    private static WebApplicationBuilder AddSerializers(this WebApplicationBuilder builder)
    {
        // register json serialization settings
        builder.Services.AddSingleton<IJsonSerializationSettingsProvider, JsonSerializationSettingsProvider>();

        return builder;
    }

    /// <summary>
    /// Adds mappers
    /// </summary>
    /// <param name="builder">The <see cref="WebApplicationBuilder"/> instance.</param>
    /// <returns>The <see cref="WebApplicationBuilder"/> instance.</returns>
    private static WebApplicationBuilder AddMappers(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(Assemblies);

        return builder;
    }

    /// <summary>
    /// Adds caching
    /// </summary>
    /// <param name="builder">The <see cref="WebApplicationBuilder"/> instance.</param>
    /// <returns>The <see cref="WebApplicationBuilder"/> instance.</returns>
    private static WebApplicationBuilder AddCaching(this WebApplicationBuilder builder)
    {
        // Register cache settings
        builder.Services.Configure<CacheSettings>(builder.Configuration.GetSection(nameof(CacheSettings)));

        // Register redis cache
        builder.Services.AddStackExchangeRedisCache(
            options =>
            {
                options.Configuration = builder.Configuration.GetConnectionString("RedisConnectionString");
                options.InstanceName = "Caching.SimpleInfra";
            }
        );

        // Register cache broker
        builder.Services.AddSingleton<ICacheBroker, RedisDistributedCacheBroker>();

        return builder;
    }

    /// <summary>
    /// Adds business logic infrastructure
    /// </summary>
    /// <param name="builder">The <see cref="WebApplicationBuilder"/> instance.</param>
    /// <returns>The <see cref="WebApplicationBuilder"/> instance.</returns>
    private static WebApplicationBuilder AddBusinessLogicInfrastructure(this WebApplicationBuilder builder)
    {
        // register db contexts
        builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        # region Locations

        // Register repositories
        builder.Services.AddScoped<ICityRepository, CityRepository>().AddScoped<ICountryRepository, CountryRepository>();

        // Register foundation data access services
        builder.Services.AddScoped<ICityService, CityService>().AddScoped<ICountryService, CountryService>();

        #endregion

        #region Listing Categories

        // Register repositories
        builder.Services.AddScoped<IListingCategoryRepository, ListingCategoryRepository>();

        // Register foundation data access services
        builder.Services.AddScoped<IListingCategoryService, ListingCategoryService>();

        #endregion

        #region Storage files

        builder.Services.Configure<StorageFileSettings>(builder.Configuration.GetSection(nameof(StorageFileSettings)))
            .Configure<ApiSettings>(builder.Configuration.GetSection(nameof(ApiSettings)));

        #endregion

        #region Listings

        // Register repositories
        builder.Services.AddScoped<IListingRepository, ListingRepository>();

        // Register foundation data access services
        builder.Services.AddScoped<IListingService, ListingService>();

        // Register orchestration services
        builder.Services.AddScoped<IListingOrchestrationService, ListingOrchestrationService>();

        #endregion

        return builder;
    }

    /// <summary>
    /// Adds cors security
    /// </summary>
    /// <param name="builder">The <see cref="WebApplicationBuilder"/> instance.</param>
    /// <returns>The <see cref="WebApplicationBuilder"/> instance.</returns>
    private static WebApplicationBuilder AddCorsSecurity(this WebApplicationBuilder builder)
    {
        var clientSettings = builder.Configuration.GetSection("ClientSettings").Get<ApiSettings>()!;
        
        builder.Services.AddCors(
            options =>
            {
                options.AddDefaultPolicy(
                    policyBuilder =>
                    {
                        policyBuilder.WithOrigins(clientSettings.BaseAddress).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                    }
                );
            }
        );

        return builder;
    }

    private static WebApplicationBuilder AddRequestContextTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddScoped<IRequestContextProvider, RequestContextProvider>();

        return builder;
    }

    /// <summary>
    /// Adds route and controller
    /// </summary>
    /// <param name="builder">The <see cref="WebApplicationBuilder"/> instance.</param>
    /// <returns>The <see cref="WebApplicationBuilder"/> instance.</returns>
    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers();

        return builder;
    }

    /// <summary>
    /// Configures the middleware to seed data
    /// </summary>
    /// <param name="app">The <see cref="WebApplication"/> instance.</param>
    /// <returns>The <see cref="WebApplication"/> instance.</returns>
    private static async Task<WebApplication> SeedDataAsync(this WebApplication app)
    {
        var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
        using var scope = scopeFactory.CreateScope();
        await scope.ServiceProvider.SeedDataAsync();

        return app;
    }

    /// <summary>
    /// Configures the middleware to use media infrastructure.
    /// </summary>
    /// <param name="app">The <see cref="WebApplication"/> instance.</param>
    /// <returns>The <see cref="WebApplication"/> instance.</returns>
    private static WebApplication UseMediaInfrastructure(this WebApplication app)
    {
        app.UseStaticFiles();

        return app;
    }

    /// <summary>
    /// Configures the middleware to use cors security.
    /// </summary>
    /// <param name="app">The <see cref="WebApplication"/> instance.</param>
    /// <returns>The <see cref="WebApplication"/> instance.</returns>
    private static WebApplication UseCorsSecurity(this WebApplication app)
    {
        app.UseCors();

        return app;
    }

    /// <summary>
    /// Applies migrations to the database.
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    private static async Task<WebApplication> ApplyMigrationsAsync(this WebApplication app)
    {
        var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
        await scopeFactory.MigrateAsync<AppDbContext>();

        return app;
    }

    /// <summary>
    /// Configures the middleware to use exposers.
    /// </summary>
    /// <param name="app">The <see cref="WebApplication"/> instance.</param>
    /// <returns>The <see cref="WebApplication"/> instance.</returns>
    private static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }
}