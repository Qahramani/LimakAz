﻿using LimakAz.Domain.Entities;
using LimakAz.Persistence.DataInitializers;
using LimakAz.Persistence.Interceptors;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Emit;

namespace LimakAz.Persistence.Contexts;

public class AppDbContext : IdentityDbContext<AppUser>
{
    private readonly BaseEntityInterceptor _entityInterceptor;
    public AppDbContext(DbContextOptions<AppDbContext> options, BaseEntityInterceptor entityInterceptor) : base(options)
    {
        _entityInterceptor = entityInterceptor;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.AddSeedData();

        modelBuilder.Entity<Chat>()
            .HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x =>x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Chat>()
            .HasOne(x => x.Moderator)
            .WithMany()
            .HasForeignKey(x => x.ModeratorId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Message>()
            .HasOne(x => x.Chat)
            .WithMany(x => x.Messages)
            .HasForeignKey(x => x.ChatId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Order>()
       .HasOne(o => o.User)
       .WithMany()  // Assuming User has many Orders
       .HasForeignKey(o => o.UserId)
       .OnDelete(DeleteBehavior.Restrict);  // Prevent cascading delete

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Country)
            .WithMany()  // Assuming Country has many Orders
            .HasForeignKey(o => o.CountryId)
            .OnDelete(DeleteBehavior.Restrict);  // Prevent cascading delete

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Shop)
            .WithMany()  // Assuming Shop has many Orders
            .HasForeignKey(o => o.ShopId)
            .OnDelete(DeleteBehavior.SetNull);  // Prevent cascading delete

        modelBuilder.Entity<Order>()
            .HasOne(o => o.LocalPoint)
            .WithMany()  // Assuming LocalPoint has many Orders
            .HasForeignKey(o => o.LocalPointId)
            .OnDelete(DeleteBehavior.Restrict);  // Prevent cascading delete

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Status)
            .WithMany()  // Assuming Status has many Orders
            .HasForeignKey(o => o.StatusId)
            .OnDelete(DeleteBehavior.Restrict);  // Prevent cascading delete

        modelBuilder.Entity<Category>().HasQueryFilter(x => !x.IsDeleted);
       modelBuilder.Entity<News>().HasQueryFilter(x => !x.IsDeleted);
       modelBuilder.Entity<Tariff>().HasQueryFilter(x => !x.IsDeleted);
       modelBuilder.Entity<LocalPoint>().HasQueryFilter(x => !x.IsDeleted);
       modelBuilder.Entity<Content>().HasQueryFilter(x => !x.IsDeleted);
       modelBuilder.Entity<Notification>().HasQueryFilter(x => !x.IsDeleted);
       modelBuilder.Entity<Message>().HasQueryFilter(x => !x.IsDeleted);
       modelBuilder.Entity<Chat>().HasQueryFilter(x => !x.IsDeleted);
    
        base.OnModelCreating(modelBuilder);
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
    public DbSet<Status> Statuses{ get; set; } = null!;
    public DbSet<StatusDetail> StatusDetails{ get; set; } = null!;

}
