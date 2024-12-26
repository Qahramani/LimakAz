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

       builder.Entity<Category>().HasQueryFilter(x => !x.IsDeleted);
       builder.Entity<News>().HasQueryFilter(x => !x.IsDeleted);
       builder.Entity<NewsDetail>().HasQueryFilter(x => !x.IsDeleted);
    
        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_entityInterceptor);

        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Language> Languages { get; set; } = null!;
    public DbSet<Certificate> Certificates{ get; set; } = null!;
    public DbSet<Slider> Sliders{ get; set; } = null!;
    public DbSet<Setting> Settings { get; set; } = null!;
    public DbSet<SettingDetail> SettingDetails { get; set; } = null!;
    public DbSet<Gender> Genders { get; set; } = null!;
    public DbSet<GenderDetail> GenderDetails { get; set; } = null!;
    //public DbSet<WareHouse> Locations { get; set; } = null!; 
    //public DbSet<WareHouseDetail> LocationDetails { get; set; } = null!; 
    public DbSet<Shop> Shops{ get; set; } = null!;
    public DbSet<ShopCategory> ShopCategories{ get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<CategoryDetail> CategoryDetails { get; set; } = null!;
    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<CountryDetail> CountryDetails{ get; set; } = null!;
    public DbSet<News> News{ get; set; } = null!;
    public DbSet<NewsDetail> NewDetails{ get; set; } = null!;

}
