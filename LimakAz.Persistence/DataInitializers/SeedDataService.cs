using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

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
        modelBuilder.AddCitizenShips();
        modelBuilder.AddUserPositions();
        modelBuilder.AddAddressLines();
        modelBuilder.AddSStatuses();
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
            new CategoryDetail { Id = 1, Name = "Qeyim", CategoryId = 1, LanguageId = 1 },
            new CategoryDetail { Id = 2, Name = "Одежда", CategoryId = 1, LanguageId = 2 },
            new CategoryDetail { Id = 3, Name = "Kosmetika", CategoryId = 2, LanguageId = 1 },
            new CategoryDetail { Id = 4, Name = "Косметика", CategoryId = 2, LanguageId = 2 }
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
            new Setting { Id = 12, Key = "Title" },
            new Setting { Id = 13, Key = "SupportLineImage" },
            new Setting { Id = 14, Key = "Email" }
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
              new SettingDetail { Id = 24, Value = "Грузы из Америки и Турции Тарифы | Limak.az - цены на доставку", SettingId = 12, LanguageId = 2 },

               new SettingDetail { Id = 25, Value = "https://res.cloudinary.com/dsclrbdnp/image/upload/v1735583341/LimakAz/ggh5cyvitqg56p1avgef.svg", SettingId = 13, LanguageId = 1 },
              new SettingDetail { Id = 26, Value = "https://res.cloudinary.com/dsclrbdnp/image/upload/v1735583605/LimakAz/zkp51genu3lmjahjuox7.svg", SettingId = 13, LanguageId = 2 },

              new SettingDetail { Id = 27, Value = "info@limak.az", SettingId = 14, LanguageId = 1 },
              new SettingDetail { Id = 28, Value = "info@limak.az", SettingId = 14, LanguageId = 2 }

              );
    }
    public static void AddCitizenShips(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CitizenShip>().HasData(
            new CitizenShip { Id = 1 },
            new CitizenShip { Id = 2 }
            );

        modelBuilder.Entity<CitizenShipDetail>().HasData(
            new CitizenShipDetail { Id = 1, Name = "Azərbaycan", CitizenShipId = 1, LanguageId = 1 },
            new CitizenShipDetail { Id = 2, Name = "Азербайджан", CitizenShipId = 1, LanguageId = 2 },
            new CitizenShipDetail { Id = 3, Name = "Xarici", CitizenShipId = 2, LanguageId = 1 },
            new CitizenShipDetail { Id = 4, Name = "Другое", CitizenShipId = 2, LanguageId = 2 }
            );
    }
    public static void AddUserPositions(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserPosition>().HasData(
            new UserPosition { Id = 1 },
            new UserPosition { Id = 2 }
            );

        modelBuilder.Entity<UserPositionDetail>().HasData(
            new UserPositionDetail { Id = 1, Name = "Fiziki şəxs", UserPositionId = 1, LanguageId = 1 },
            new UserPositionDetail { Id = 2, Name = "Физическое лицо", UserPositionId = 1, LanguageId = 2 },
            new UserPositionDetail { Id = 3, Name = "Hüquq şəxs", UserPositionId = 2, LanguageId = 1 },
            new UserPositionDetail { Id = 4, Name = "Юридическое лицо", UserPositionId = 2, LanguageId = 2 }
            );
    }
    public static void AddAddressLines(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddressLine>().HasData(
            new AddressLine { Id = 1, Key = "XaricdekiUnvanlar-VergiNo", Value = "6081089593", CountryId = 4 },
            new AddressLine { Id = 2, Key = "XaricdekiUnvanlar-Ulke", Value = "Türkiye", CountryId = 4 },
            new AddressLine { Id = 3, Key = "XaricdekiUnvanlar-VergiDairesi", Value = "Şişli", CountryId = 4 },
            new AddressLine { Id = 4, Key = "XaricdekiUnvanlar-PostKodu", Value = "34060", CountryId = 4 },
            new AddressLine { Id = 5, Key = "XaricdekiUnvanlar-Telefon", Value = "05364700021", CountryId = 4 },
            new AddressLine { Id = 6, Key = "XaricdekiUnvanlar-İlce", Value = "Eyüpsultan", CountryId = 4 },
            new AddressLine { Id = 7, Key = "XaricdekiUnvanlar-TCKimlik", Value = "35650276048", CountryId = 4 },
            new AddressLine { Id = 8, Key = "XaricdekiUnvanlar-Semt", Value = "Güzeltepe mahallesi", CountryId = 4 },
            new AddressLine { Id = 9, Key = "XaricdekiUnvanlar-IlSehir", Value = "İstanbul", CountryId = 4 },
            new AddressLine { Id = 10, Key = "XaricdekiUnvanlar-AdressSatir", Value = ",Güzeltepe mahallesi,Akdeniz caddesi no:33/A", CountryId = 4 },
            new AddressLine { Id = 11, Key = "XaricdekiUnvanlar-AdressBasligi", Value = "LIMAK", CountryId = 4 },
            new AddressLine { Id = 12, Key = "XaricdekiUnvanlar-AdSoyad", Value = "LİMAK TAŞIMACILIK DIŞ TİCARET LİMİTED ŞİRKETİ", CountryId = 4 },
            new AddressLine { Id = 13, Key = "Is-Saatlari", Value = "Həftəiçi 5 gün: 09:00 - 17:00\r\nŞənbə: 09:00 - 14:00\r\nBazar günü qeyri-iş günüdür.", CountryId = 4 },

            new AddressLine { Id = 14, Key = "Street-Address", Value = "1234 Elm Street, Suite 567", CountryId = 5 },
            new AddressLine { Id = 15, Key = "City", Value = "New York", CountryId = 5 },
            new AddressLine { Id = 16, Key = "State", Value = "NY", CountryId = 5 },
            new AddressLine { Id = 17, Key = "ZIP-Code", Value = "10001", CountryId = 5 },
            new AddressLine { Id = 18, Key = "Country", Value = "USA", CountryId = 5 },
            new AddressLine { Id = 19, Key = "Phone-Number", Value = "+1-555-123-4567", CountryId = 5 },
            new AddressLine { Id = 20, Key = "Working-Hours", Value = "Mon-Fri, 9:00 AM - 5:00 PM EST", CountryId = 5 }
            );
    }
    public static void AddSStatuses(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Status>().HasData(
            new Status { Id = 1 },
            new Status { Id = 2 },
            new Status { Id = 3 },
            new Status { Id = 4 },
            new Status { Id = 5 },
            new Status { Id = 6 },
            new Status { Id = 7 },
            new Status { Id = 8 },
            new Status { Id = 9 }
            );

        modelBuilder.Entity<StatusDetail>().HasData(
            new StatusDetail { Id = 1, Name = "Ödəniş olunub", StatusId = 1, LanguageId = 1 },
            new StatusDetail { Id = 2, Name = "Оплачено", StatusId = 1, LanguageId = 2 },
            new StatusDetail { Id = 3, Name = "Sifariş edilib", StatusId = 2, LanguageId = 1 },
            new StatusDetail { Id = 4, Name = "Заказано", StatusId = 2, LanguageId = 2 },
            new StatusDetail { Id = 5, Name = "Sifariş edilməyib", StatusId = 3, LanguageId = 1 },
            new StatusDetail { Id = 6, Name = "Не заказано", StatusId = 3, LanguageId = 2 },
            new StatusDetail { Id = 7, Name = "Xarici anbardadır", StatusId = 4, LanguageId = 1 },
            new StatusDetail { Id = 8, Name = "На иностранном складе", StatusId = 4, LanguageId = 2 },
            new StatusDetail { Id = 9, Name = "Gömürükdədir", StatusId = 5, LanguageId = 1 },
            new StatusDetail { Id = 10, Name = "На таможне", StatusId = 5, LanguageId = 2 },
            new StatusDetail { Id = 11, Name = "Yoldadır", StatusId = 6, LanguageId = 1 },
            new StatusDetail { Id = 12, Name = "В пути", StatusId = 6, LanguageId = 2 },
            new StatusDetail { Id = 13, Name = "Yerli anbardadır", StatusId = 7, LanguageId = 1 },
            new StatusDetail { Id = 14, Name = "На местном складе", StatusId = 7, LanguageId = 2 },
            new StatusDetail { Id = 15, Name = "Təhvil verilib", StatusId = 8, LanguageId = 1 },
            new StatusDetail { Id = 16, Name = "Доставлено", StatusId = 8, LanguageId = 2 },
            new StatusDetail { Id = 17, Name = "Ləğv edilib", StatusId = 9, LanguageId = 1 },
            new StatusDetail { Id = 18, Name = "Отменено", StatusId = 9, LanguageId = 2 }
        );

    }
    public static void AddCountries(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>().HasData(
            new Country
            {
                Id = 1,
                ImagePath = "https://res.cloudinary.com/dsclrbdnp/image/upload/v1735590904/rfvtik0wyqjxlieecbfm.png",
                IsDeleted = false,
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
                CreatedBy = "Defaul",
                UpdatedBy = "Default",
            },
            new Country
            {
                Id = 2,
                ImagePath = "https://res.cloudinary.com/dsclrbdnp/image/upload/v1735590817/gdrkuwphkhe9f2d0sovw.png",
                IsDeleted = false,
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
                CreatedBy = "Defaul",
                UpdatedBy = "Default",
            });

        modelBuilder.Entity<CountryDetail>().HasData(
            new CountryDetail { Id = 1, Name = "Turkiye", CountryId = 1, LanguageId = 1 },
            new CountryDetail { Id = 2, Name = "Турция", CountryId = 1, LanguageId = 2 },
            new CountryDetail { Id = 3, Name = "Amerika", CountryId = 2, LanguageId = 1 },
            new CountryDetail { Id = 4, Name = "Америка", CountryId = 2, LanguageId = 2 }
        );
    }
}
