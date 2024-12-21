using LimakAz.Domain.Entities;
using LimakAz.Persistence.DataInitializers;
using LimakAz.Persistence.Interceptors;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LimakAz.Persistence.Contexts;

public class AppDbContext : IdentityDbContext<AppUser>
{
    private readonly BaseEntityInterceptor _entityInterceptor;
    public AppDbContext(DbContextOptions<AppDbContext> options, BaseEntityInterceptor entityInterceptor) : base(options)
    {
        _entityInterceptor = entityInterceptor;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        builder.AddSeedData();

       // builder.Entity<Category>().HasQueryFilter(x => !x.IsDeleted);
    
        base.OnModelCreating(builder);
    }

    public DbSet<Language> Languages { get; set; } = null!;
    public DbSet<Setting> Settings { get; set; } = null!;
    public DbSet<SettingDetail> SettingDetails { get; set; } = null!;
    public DbSet<Gender> Genders { get; set; } = null!;
    public DbSet<GenderDetail> GenderDetails { get; set; } = null!;
    public DbSet<Location> Locations { get; set; } = null!; 
    public DbSet<LocationDetail> LocationDetails { get; set; } = null!; 
}
