using LimakAz.Domain.AppSettingModels;
using LimakAz.Domain.Enums;
using LimakAz.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LimakAz.Persistence.DataInitializers;

public class DbContextInitializer
{
    private readonly AppDbContext _appDbContext;
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;

    public DbContextInitializer(AppDbContext appDbContext, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
    {
        _appDbContext = appDbContext;
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
    }

    public async Task InitDatabaseAsync()
    {
        await _appDbContext.Database.MigrateAsync();    

        await _createRolesAsync();

        await _createAdminAsync();
    }

    private async Task _createRolesAsync()
    {
        var roles = Enum.GetNames(typeof(RoleType));

        foreach (var role in roles)
        {
            if (await _roleManager.FindByNameAsync(role) != null)
                continue;

            await _roleManager.CreateAsync(new IdentityRole { Name = role });
        }
    }
    private async Task _createAdminAsync()
    {
        var admin = _configuration.GetSection("Admin").Get<Admin>();

        if (admin == null)
            return;

        var existUser = await _userManager.FindByNameAsync(admin.Username);

        if (existUser != null)
            return;

        var newUser = new AppUser
        {
            UserName = admin.Username,
            Email = admin.Email,
            Firstname = admin.Firstname,
            Lastname = admin.Lastname,
            Code = "1111111",
            FinCode = "AA11111",
            PhoneNumber = "558983567",
            SerialNumber = "AA1111111",
            Address = "Azerbaijan/Baku",
            LocalPointId = 1,
            GenderId = 1,
            CitizenShipId =1,
            NotificationType = NotificationType.Whatsapp,
            UserPositionId = 1,
            BirthDate = DateTime.Now,
        };

        var result = await _userManager.CreateAsync(newUser,admin.Password);

        if (!result.Succeeded)
            throw new Exception("Admin is not created");

        result = await _userManager.AddToRoleAsync(newUser,RoleType.Admin.ToString());

        if (!result.Succeeded)
            throw new Exception("Admin is not assigned");
    }
}
