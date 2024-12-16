using Microsoft.EntityFrameworkCore;

namespace LimakAz.Persistence.DataInitializers;

public static class SeedDataService
{
    public static void AddSeedData(this ModelBuilder modelBuilder)
    {
        modelBuilder.AddLanguages();
    }

    public static void AddLanguages(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Language>().HasData(
            new Language { Id = 1, Name = "Azerbaijan", IsoCode = "AZE", ImagePath = "" },
            new Language { Id = 2, Name = "Russian", IsoCode = "RUS", ImagePath = "" }
            );
    }
    public static void AddSettings(this ModelBuilder modelBuilder)
    {

    }
}
