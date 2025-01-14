using LimakAz.Application.Interfaces.Helpers;
using LimakAz.Application.Interfaces.Services.UI;
using LimakAz.Persistence.Contexts;
using LimakAz.Persistence.DataInitializers;
using LimakAz.Persistence.Helpers;
using LimakAz.Persistence.Implementations.Repositories;
using LimakAz.Persistence.Implementations.Services;
using LimakAz.Persistence.Implementations.Services.UI;
using LimakAz.Persistence.Interceptors;
using LimakAz.Persistence.Localizers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace LimakAz.Persistence.ServiceRegistrations;

public static class ServiceRegistrations
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));

        services.AddScoped<BaseEntityInterceptor>();
        services.AddScoped<DbContextInitializer>();

        _addLocalizers(services);
        _addIdentiy(services);
        _addRepositories(services);
        _addServices(services);


        return services;
    }

    private static void _addRepositories(IServiceCollection services)
    {
        //  services.AddScoped<IRepository, Repository>();
        services.AddScoped<ILanguageRepository, LanguageRepository>();
        services.AddScoped<ISettingRepository, SettingRepository>();
        services.AddScoped<ICertificateRepository, CertificateRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IShopRepository, ShopRepository>();
        services.AddScoped<IShopCategoryRepository, ShopCategoryRepository>();
        services.AddScoped<ISliderRepository, SliderRepository>();
        services.AddScoped<INewsRepository, NewsRepository>();
        services.AddScoped<ITariffRepository, TariffRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<ILocalPointRepository, LocalPointRepository>();
        services.AddScoped<IContentRepository, ContentRepository>();
        services.AddScoped<IGenderRepository, GenderRepository>();
        services.AddScoped<IUserPositionRepository, UserPositionRepository>();
        services.AddScoped<ICitizenShipRepository, CitizenShipRepository>();
    }

    private static void _addServices(IServiceCollection services)
    {
        services.AddScoped<ILanguageService, LanguageService>();
        services.AddScoped<ICertificateService, CertificateService>();
        services.AddScoped<ISettingService, SettingService>();
        services.AddScoped<ICookieService, CookieService>();
        services.AddScoped<INewsService, NewsService>();
        services.AddScoped<ITariffService, TariffService>();
        services.AddScoped<ICountryService, CountryService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IShopService, ShopService>();
        services.AddScoped<IShopCategoryService, ShopCategoryService>();
        services.AddScoped<ISliderService, SliderService>();
        services.AddScoped<ILocalPointService, LocalPointService>();
        services.AddScoped<IContentService, ContentService>();
        services.AddScoped<IGenderService, GenderService>();
        services.AddScoped<IUserPositionService, UserPositionService>();
        services.AddScoped<ICitizenShipService, CitizenShipService>();
        services.AddScoped<IAuthService, AuthService>();

        services.AddScoped<IValidationMessageProvider, ValidationMessagesLocalizer>();

        services.AddScoped<ILayoutService, LayoutService>();
        services.AddScoped<IHomeService, HomeService>();
        services.AddScoped<ICalculatorService, CalculatorService>();

    }

    private static void _addLocalizers(IServiceCollection services)
    {
        services.Configure<RequestLocalizationOptions>(
          options =>
          {
              var supportedCultures = new List<CultureInfo>
                  {
                        new CultureInfo("ru"),
                        new CultureInfo("az"),
                  };

              options.DefaultRequestCulture = new RequestCulture(culture: "az", uiCulture: "az");

              options.SupportedCultures = supportedCultures;
              options.SupportedUICultures = supportedCultures;

          });

        services.AddSingleton<LayoutLocalizer>();
        services.AddSingleton<HomeLocalizer>();
        services.AddSingleton<TariffsLocalizer>();
        services.AddSingleton<ContactLocalizer>();
        services.AddSingleton<ContentLocalizer>();
        services.AddSingleton<NewsLocalizer>();
        services.AddSingleton<CalculatorLocalizer>();
        services.AddSingleton<AccountLocalizer>();
        services.AddSingleton<ValidationMessagesLocalizer>();

    }

    private static void _addIdentiy(IServiceCollection services)
    {
        services.AddIdentity<AppUser, IdentityRole>(options =>
        {
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = true;

            options.Lockout.AllowedForNewUsers = false;
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);

            options.SignIn.RequireConfirmedEmail = true;

            options.User.RequireUniqueEmail = true;
        }).AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders()
        .AddErrorDescriber<CustomIdentityErrorDescriber>();

    }
}
