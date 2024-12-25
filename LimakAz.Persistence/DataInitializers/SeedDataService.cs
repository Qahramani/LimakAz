using Microsoft.EntityFrameworkCore;

namespace LimakAz.Persistence.DataInitializers;

public static class SeedDataService
{
    public static void AddSeedData(this ModelBuilder modelBuilder)
    {
        modelBuilder.AddLanguages();
        modelBuilder.AddGenders();
        modelBuilder.AddCertificates(); 
        modelBuilder.AddCategories();
        modelBuilder.AddSettings();
    }

    public static void AddLanguages(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Language>().HasData(
            new Language { Id = 1, Name = "AZE", IsoCode = "az", ImagePath = "" },
            new Language { Id = 2, Name = "RU", IsoCode = "ru", ImagePath = "" }
            );
    }
    public static void AddGenders(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Gender>().HasData(
            new Gender { Id = 1 },
            new Gender { Id = 2 }
            );
        modelBuilder.Entity<GenderDetail>().HasData(
           new GenderDetail { Id = 1, Name = "Qadin", GenderId = 1, LanguageId = 1 },
           new GenderDetail { Id = 2, Name = "Kişi", GenderId = 2, LanguageId = 1 },
           new GenderDetail { Id = 3, Name = "Женщина", GenderId = 1, LanguageId = 2 },
           new GenderDetail { Id = 4, Name = "Мужчина", GenderId = 2, LanguageId = 2 }
           );

    }
    public static void AddCertificates(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Certificate>().HasData(
            new Certificate { Id = 1, ImagePath = "https://res.cloudinary.com/dsclrbdnp/image/upload/v1735148773/LimakAz/fhe6fq69cr1lqamzvhsm.png", Link = "https://www.iata.org/" },
            new Certificate { Id = 2, ImagePath = "https://res.cloudinary.com/dsclrbdnp/image/upload/v1735148773/LimakAz/usq5qshiktvvcioeu0xe.png", Link = "https://www.turkishairlines.com/" },
            new Certificate { Id = 3, ImagePath = "https://res.cloudinary.com/dsclrbdnp/image/upload/v1735148773/LimakAz/qtiaad8swg6yvs8jobdj.png", Link = "https://fiata.org/" },
            new Certificate { Id = 4, ImagePath = "https://res.cloudinary.com/dsclrbdnp/image/upload/v1735148773/LimakAz/ovgeyi6xr3eahskj0u8f.png", Link = "https://limaklogistic.com/tr" },
            new Certificate { Id = 5, ImagePath = "https://res.cloudinary.com/dsclrbdnp/image/upload/v1735148773/LimakAz/m9q1xavaxdofuxsc380m.png", Link = "https://www.silkwaywest.com/" },
            new Certificate { Id = 6, ImagePath = "https://res.cloudinary.com/dsclrbdnp/image/upload/v1735148773/LimakAz/l9ropu52ecsgkqyd3uej.png", Link = "https://apagroup.az/az" }
            );
    }
    public static void AddCategories(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, CreatedBy = "default", CreatedAt = DateTime.UtcNow, UpdatedBy = "default", UpdatedAt = DateTime.UtcNow, IsDeleted = false, LogoPath = "" },
            new Category { Id = 2, CreatedBy = "default", CreatedAt = DateTime.UtcNow, UpdatedBy = "default", UpdatedAt = DateTime.UtcNow, IsDeleted = false, LogoPath = "" }
            );
        modelBuilder.Entity<CategoryDetail>().HasData(
            new CategoryDetail { Id = 1, CreatedBy = "default", CreatedAt = DateTime.UtcNow, UpdatedBy = "default", UpdatedAt = DateTime.UtcNow, IsDeleted = false, Name = "Qeyim", CategoryId = 1, LanguageId = 1},
            new CategoryDetail { Id = 2, CreatedBy = "default", CreatedAt = DateTime.UtcNow, UpdatedBy = "default", UpdatedAt = DateTime.UtcNow, IsDeleted = false, Name = "Одежда", CategoryId = 1, LanguageId = 2},
            new CategoryDetail { Id = 3, CreatedBy = "default", CreatedAt = DateTime.UtcNow, UpdatedBy = "default", UpdatedAt = DateTime.UtcNow, IsDeleted = false, Name = "Kosmetika", CategoryId = 2, LanguageId = 1},
            new CategoryDetail { Id = 4, CreatedBy = "default", CreatedAt = DateTime.UtcNow, UpdatedBy = "default", UpdatedAt = DateTime.UtcNow, IsDeleted = false, Name = "Косметика", CategoryId = 2, LanguageId = 2}
            );
    }
    public static void AddSettings(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Setting>().HasData(
            new Setting { Id = 1, Key = "Address" },
            new Setting { Id = 2, Key = "WorkingHours" },
            new Setting { Id = 3, Key = "SupportPhone" },
            new Setting { Id = 4, Key = "InstagramLink" },
            new Setting { Id = 5, Key = "FacebookLink" },
            new Setting { Id = 6, Key = "TwitterLink" },
            new Setting { Id = 7, Key = "YoutubeLink" },
            new Setting { Id = 8, Key = "TiktokLink" },
            new Setting { Id = 9, Key = "Copyright" },
            new Setting { Id = 10, Key = "AppstoreLink" },
            new Setting { Id = 11, Key = "GoogleplayLink" },
            new Setting { Id = 12, Key = "Title" }
            );

        modelBuilder.Entity<SettingDetail>().HasData(
            new SettingDetail { Id = 1, Value = " Səbail rayonu, Lermontov küç. 40A", SettingId = 1, LanguageId = 1 },
            new SettingDetail { Id = 2, Value = "Сабаильский район, ул. Лермонтова 40А", SettingId = 1, LanguageId = 2 },

             new SettingDetail { Id = 3, Value = "Bazar ertəsi-cümə", SettingId = 2, LanguageId = 1 },
            new SettingDetail { Id = 4, Value = "Понедельник-Пятница", SettingId = 2, LanguageId = 2 },

             new SettingDetail { Id = 5, Value = "9595", SettingId = 3, LanguageId = 1 },
            new SettingDetail { Id = 6, Value = "9595", SettingId = 3, LanguageId = 2 },

             new SettingDetail { Id = 7, Value = "https://www.instagram.com/asmannn18", SettingId = 4, LanguageId = 1 },
            new SettingDetail { Id = 8, Value = "https://www.instagram.com/asmannn18", SettingId = 4, LanguageId = 2 },

             new SettingDetail { Id = 9, Value = "https://www.instagram.com/asmannn18", SettingId = 5, LanguageId = 1 },
            new SettingDetail { Id = 10, Value = "https://www.instagram.com/asmannn18", SettingId = 5, LanguageId = 2 },

             new SettingDetail { Id = 11, Value = "https://www.instagram.com/asmannn18", SettingId = 6, LanguageId = 1 },
            new SettingDetail { Id = 12, Value = "https://www.instagram.com/asmannn18", SettingId = 6, LanguageId = 2 },

            new SettingDetail { Id = 13, Value = "https://www.instagram.com/asmannn18", SettingId = 7, LanguageId = 1 },
            new SettingDetail { Id = 14, Value = "https://www.instagram.com/asmannn18", SettingId = 7, LanguageId = 2 },

             new SettingDetail { Id = 15, Value = "https://www.instagram.com/asmannn18", SettingId = 8, LanguageId = 1 },
            new SettingDetail { Id = 16, Value = "https://www.instagram.com/asmannn18", SettingId = 8, LanguageId = 2 },

             new SettingDetail { Id = 17, Value = "© 2019 - 2024 Limak.az | Bütün hüquqlar qorunur", SettingId = 9, LanguageId = 1 },
            new SettingDetail { Id = 18, Value = "© 2019 - 2024 Limak.az | Все права защищены", SettingId = 9, LanguageId = 2 },

             new SettingDetail { Id = 19, Value = "https://www.instagram.com/asmannn18", SettingId = 10, LanguageId = 1 },
            new SettingDetail { Id = 20, Value = "https://www.instagram.com/asmannn18", SettingId = 10, LanguageId = 2 },

              new SettingDetail { Id = 21, Value = "https://www.instagram.com/asmannn18", SettingId = 11, LanguageId = 1 },
              new SettingDetail { Id = 22, Value = "https://www.instagram.com/asmannn18", SettingId = 11, LanguageId = 2 },

               new SettingDetail { Id = 23, Value = "Tariflər | Amerika və Türkiyədən kargo | Limak.az - Daşınma qiymetleri", SettingId = 12, LanguageId = 1 },
              new SettingDetail { Id = 24, Value = "Грузы из Америки и Турции Тарифы | Limak.az - цены на доставку", SettingId = 12, LanguageId = 2 }
            );
    }
}
