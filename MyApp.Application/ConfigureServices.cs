using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
namespace MyApp.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        // need to register all query handlers
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ConfigureServices).Assembly));
        
        return services;
    }
}