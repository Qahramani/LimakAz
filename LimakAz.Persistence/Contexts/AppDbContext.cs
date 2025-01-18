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

        builder.Entity<Chat>()
            .HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x =>x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Entity<Chat>()
            .HasOne(x => x.Moderator)
            .WithMany()
            .HasForeignKey(x => x.ModeratorId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Entity<Message>()
            .HasOne(x => x.Chat)
            .WithMany(x => x.Messages)
            .HasForeignKey(x => x.ChatId)
            .OnDelete(DeleteBehavior.Restrict);


       builder.Entity<Category>().HasQueryFilter(x => !x.IsDeleted);
       builder.Entity<News>().HasQueryFilter(x => !x.IsDeleted);
       builder.Entity<Tariff>().HasQueryFilter(x => !x.IsDeleted);
       builder.Entity<LocalPoint>().HasQueryFilter(x => !x.IsDeleted);
       builder.Entity<Content>().HasQueryFilter(x => !x.IsDeleted);
       builder.Entity<Notification>().HasQueryFilter(x => !x.IsDeleted);
       builder.Entity<Message>().HasQueryFilter(x => !x.IsDeleted);
       builder.Entity<Chat>().HasQueryFilter(x => !x.IsDeleted);
    
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
    public DbSet<Shop> Shops{ get; set; } = null!;
    public DbSet<ShopCategory> ShopCategories{ get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<CategoryDetail> CategoryDetails { get; set; } = null!;
    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<CountryDetail> CountryDetails{ get; set; } = null!;
    public DbSet<News> News{ get; set; } = null!;
    public DbSet<NewsDetail> NewDetails{ get; set; } = null!;
    public DbSet<Tariff> Tariffs { get; set; } = null!;
    public DbSet<LocalPoint> LocalPoints{ get; set; } = null!;
    public DbSet<LocalPointDetail> LocalPointDetails{ get; set; } = null!;
    public DbSet<Content> Contents{ get; set; } = null!;
    public DbSet<ContentDetail> ContentDetails{ get; set; } = null!;
    public DbSet<UserPosition> UserPositions{ get; set; } = null!;
    public DbSet<UserPositionDetail> UserPositionDetails { get; set; } = null!;
    public DbSet<CitizenShip> CitizenShips{ get; set; } = null!;
    public DbSet<CitizenShipDetail> CitizenShipDetails { get; set; } = null!;
    public DbSet<AddressLine> AddressLines { get; set; } = null!;
    public DbSet<Notification> Notifications{ get; set; } = null!;
    public DbSet<NotificationDetail> NotificationDetails{ get; set; } = null!;
    public DbSet<Message> Messages{ get; set; } = null!;
    public DbSet<Chat> Chats{ get; set; } = null!;

}
