using LimakAz.Domain.Entities;
using LimakAz.Persistence.DataInitializers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LimakAz.Persistence.Contexts;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.AddSeedData();

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
