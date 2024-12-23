using Microsoft.EntityFrameworkCore;

namespace LimakAz.Persistence.DataInitializers;

public static class SeedDataService
{
    public static void AddSeedData(this ModelBuilder modelBuilder)
    {
        modelBuilder.AddLanguages();
        modelBuilder.AddSettings();
    }

    public static void AddLanguages(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Language>().HasData(
            new Language { Id = 1, Name = "AZE", IsoCode = "az", ImagePath = "" },
            new Language { Id = 2, Name = "RU", IsoCode = "ru", ImagePath = "" }
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
