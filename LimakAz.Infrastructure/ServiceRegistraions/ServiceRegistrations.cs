using LimakAz.Application.Interfaces.Services.External;
using LimakAz.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LimakAz.Infrastructure.ServiceRegistraions;

public static class ServiceRegistrations
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection services)
    {
        services.AddScoped<ICloudinaryService, CloudinaryService>();
        services.AddScoped<ICurrencyService, CurrencyService>();
        services.AddScoped<IEmailService, EmailService>();

        services.AddHttpClient<CurrencyService>();


        return services;
    }
}
