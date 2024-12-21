using LimakAz.Application.Interfaces.Services;
using LimakAz.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LimakAz.Infrastructure.ServiceRegistraions;

public static class ServiceRegistrations
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection services)
    {
        services.AddScoped<ICloudinaryService, CloudinaryService>();

        return services;
    }
}
