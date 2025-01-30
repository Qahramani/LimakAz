using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
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
        modelBuilder.AddCountries();
        modelBuilder.AddAddressLines();
        modelBuilder.AddStatuses();
        modelBuilder.AddLocalPoints();
        modelBuilder.AddNews();
        modelBuilder.AddSliders();
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
            new Category { Id = 1, CreatedBy = "default", CreatedAt = DateTime.MinValue, UpdatedBy = "default", UpdatedAt = DateTime.MinValue, IsDeleted = false, LogoPath = "https://res.cloudinary.com/dsclrbdnp/image/upload/v1736343697/slhpbhpb8kz0t8aounk7.png" },
            new Category { Id = 2, CreatedBy = "default", CreatedAt = DateTime.MinValue, UpdatedBy = "default", UpdatedAt = DateTime.MinValue, IsDeleted = false, LogoPath = "https://res.cloudinary.com/dsclrbdnp/image/upload/v1736343830/rqv6ofcjthjh5xvkbejy.png" }
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
            new AddressLine { Id = 1, Key = "XaricdekiUnvanlar-VergiNo", Value = "6081089593", CountryId = 1 },
            new AddressLine { Id = 2, Key = "XaricdekiUnvanlar-Ulke", Value = "Türkiye", CountryId = 1 },
            new AddressLine { Id = 3, Key = "XaricdekiUnvanlar-VergiDairesi", Value = "Şişli", CountryId = 1 },
            new AddressLine { Id = 4, Key = "XaricdekiUnvanlar-PostKodu", Value = "34060", CountryId = 1 },
            new AddressLine { Id = 5, Key = "XaricdekiUnvanlar-Telefon", Value = "05364700021", CountryId = 1},
            new AddressLine { Id = 6, Key = "XaricdekiUnvanlar-İlce", Value = "Eyüpsultan", CountryId = 1 },
            new AddressLine { Id = 7, Key = "XaricdekiUnvanlar-TCKimlik", Value = "35650276048", CountryId = 1 },
            new AddressLine { Id = 8, Key = "XaricdekiUnvanlar-Semt", Value = "Güzeltepe mahallesi", CountryId = 1 },
            new AddressLine { Id = 9, Key = "XaricdekiUnvanlar-IlSehir", Value = "İstanbul", CountryId = 1 },
            new AddressLine { Id = 10, Key = "XaricdekiUnvanlar-AdressSatir", Value = ",Güzeltepe mahallesi,Akdeniz caddesi no:33/A", CountryId = 1 },
            new AddressLine { Id = 11, Key = "XaricdekiUnvanlar-AdressBasligi", Value = "LIMAK", CountryId = 1 },
            new AddressLine { Id = 12, Key = "XaricdekiUnvanlar-AdSoyad", Value = "LİMAK TAŞIMACILIK DIŞ TİCARET LİMİTED ŞİRKETİ", CountryId = 1 },
            new AddressLine { Id = 13, Key = "Is-Saatlari", Value = "Həftəiçi 5 gün: 09:00 - 17:00\r\nŞənbə: 09:00 - 14:00\r\nBazar günü qeyri-iş günüdür.", CountryId = 1 },

            new AddressLine { Id = 14, Key = "Street-Address", Value = "1234 Elm Street, Suite 567", CountryId = 2 },
            new AddressLine { Id = 15, Key = "City", Value = "New York", CountryId = 2 },
            new AddressLine { Id = 16, Key = "State", Value = "NY", CountryId = 2 },
            new AddressLine { Id = 17, Key = "ZIP-Code", Value = "10001", CountryId = 2 },
            new AddressLine { Id = 18, Key = "Country", Value = "USA", CountryId = 2 },
            new AddressLine { Id = 19, Key = "Phone-Number", Value = "+1-555-123-4567", CountryId = 2 },
            new AddressLine { Id = 20, Key = "Working-Hours", Value = "Mon-Fri, 9:00 AM - 5:00 PM EST", CountryId = 2 }
            );
    }
    public static void AddStatuses(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Status>().HasData(
            new Status { Id = 1 },
            new Status { Id = 2 },
            new Status { Id = 3 },
            new Status { Id = 4 },
            new Status { Id = 5 },
            new Status { Id = 6 },
            new Status { Id = 7 }
            );

        modelBuilder.Entity<StatusDetail>().HasData(
            new StatusDetail { Id = 1, Name = "Sifariş edilməyib", StatusId = 1, LanguageId = 1 },
            new StatusDetail { Id = 2, Name = "Не заказано", StatusId = 1, LanguageId = 2 },

            new StatusDetail { Id = 3, Name = "Sifariş edilib", StatusId = 2, LanguageId = 1 },
            new StatusDetail { Id = 4, Name = "Заказано", StatusId = 2, LanguageId = 2 },

            new StatusDetail { Id = 5, Name = "Ödəniş olunub", StatusId = 3, LanguageId = 1 },
            new StatusDetail { Id = 6, Name = "Оплачено", StatusId = 3, LanguageId = 2 },

            new StatusDetail { Id = 7, Name = "Yoldadır", StatusId = 4, LanguageId = 1 },
            new StatusDetail { Id = 8, Name = "В пути", StatusId = 4, LanguageId = 2 },

            new StatusDetail { Id = 9, Name = "Yerli anbardadır", StatusId = 5, LanguageId = 1 },
            new StatusDetail { Id = 10, Name = "На местном складе", StatusId = 5, LanguageId = 2 },

            new StatusDetail { Id = 11, Name = "Sifariş tamamlandı", StatusId = 6, LanguageId = 1 },
            new StatusDetail { Id = 12, Name = "Заказ выполнен", StatusId = 6, LanguageId = 2 },

            new StatusDetail { Id = 13, Name = "Ləğv edilib", StatusId = 7, LanguageId = 1 },
            new StatusDetail { Id = 14, Name = "Отменено", StatusId = 7, LanguageId = 2 }
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
    public static void AddLocalPoints(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LocalPoint>().HasData(
            new LocalPoint {
                Id = 1,
                IsDeleted = false,
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
                CreatedBy = "Defaul",
                UpdatedBy = "Default",
            },
            new LocalPoint {
                Id = 2,
                IsDeleted = false,
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
                CreatedBy = "Defaul",
                UpdatedBy = "Default",
            });

        modelBuilder.Entity<LocalPointDetail>().HasData(

            new LocalPointDetail { Id = 1, Name = "Limak - Gəncə", Description = "Gəncə şəhəri, Kəpəz rayonu, Əziz Əliyev prospekti, 5A. (Köhnə Yevlax avtovağzalı və Neon dəyirmanının yaxınlığı)", WorkingHourse = "Bazar ertəsi-şənbə\r\nSaat 10:00 - 20:00\r\n\r\nŞənbə\r\nSaat 10:00 - 20:00", LocalPointId = 1, LanguageId = 1 },
            new LocalPointDetail { Id = 2, Name = "Limak - Гянджа", Description = "Город Гянджа, Кепазский район, проспект Азиза Алиева, 5А. (Рядом с автовокзалом Евлаха и Неоновой мельницей)", WorkingHourse = "Понедельник-Суббота\r\nС 10:00 до 20:00\r\n\r\nСуббота\r\nС 10:00 до 20:00", LocalPointId = 1, LanguageId = 2 },

            new LocalPointDetail { Id = 3, Name = "Limak - Xalqlar Dostluğu", Description = "Nizami rayonu, Qara Qarayev prospekti, 125a (Səhhət klinikasının yaxınlığı)", WorkingHourse = "Bazar ertəsi-şənbə\r\nSaat 10:00 - 20:00\r\n\r\nŞənbə\r\nSaat 10:00 - 20:00", LocalPointId = 2, LanguageId = 1 },
            new LocalPointDetail { Id = 4, Name = "Limak - Халглар Достлугу", Description = "Низаминский район, проспект Кара Караева, 125а ( возле поликлиники “SƏHHƏT” )", WorkingHourse = "Понедельник-Суббота\r\nС 10:00 до 20:00\r\n\r\nСуббота\r\nС 10:00 до 20:00", LocalPointId = 2, LanguageId = 2 }
            );

    }
    public static void AddNews(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<News>().HasData(
            new News
            {
                Id = 1,
                ImagePath = "https://res.cloudinary.com/dsclrbdnp/image/upload/v1737841428/LimakAz/tkqkwproumeajbfifprs.jpg",
                IsDeleted = false,
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
                CreatedBy = "Defaul",
                UpdatedBy = "Default"
            },
            new News
            {
                Id = 2,
                ImagePath = "https://res.cloudinary.com/dsclrbdnp/image/upload/v1737841438/LimakAz/m4yxdcrc4jy33iapjela.jpg",
                IsDeleted = false,
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
                CreatedBy = "Defaul",
                UpdatedBy = "Default"
            },
            new News
            {
                Id = 3,
                ImagePath = "https://res.cloudinary.com/dsclrbdnp/image/upload/v1737841534/LimakAz/yccukiy8giu0hsx76ria.jpg",
                IsDeleted = false,
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
                CreatedBy = "Defaul",
                UpdatedBy = "Default"
            }
            );

        modelBuilder.Entity<NewsDetail>().HasData(
            new NewsDetail { Id = 1, Title = "Limakın yeni Quba filialı!", Description = "Dəyərli müştərilər, çoxsaylı istəkləri nəzərə alaraq, yeni açılan Quba filialımız artıq xidmətinizdədir." +
            " Quba filialının ünvanı: Quba şəhəri, Fətəli xan və Səməd Vurğun küçəsinin kəsişməsi. \r\n \r\n Seçdiyiniz məhsulların linkini bizə göndərməklə sifarişlərinizi SifarişEt xidmətimizə həvalə edin. Amerika və Türkiyədən gələn bağlamalarınızı filiallardan, " +
            "kuryerlərimizdən və ya kargomatlardan təhvil ala bilərsiniz. Limak komandası rahat alış-veriş və sürətli çatdırılma ilə xidmətinizdədir!", NewsId = 1, LanguageId = 1},
            new NewsDetail { Id = 2, Title = "Новый филиал Лимака в Губе!", Description = "Уважаемые клиенты, учитывая многочисленные запросы, наш филиал Губа теперь к вашим услугам. Адрес Губинского филиала: г. Губа, пересечение улиц Фатали Хана и Самеда Вургуна. \r\n \r\n Отправьте ссылку на выбранные вами продукты, и пусть наша служба «Заказать» обработает ваши заказы. " +
            "Посылки из Америки и Турции вы можете получить в наших филиалах, в ближайших каргоматах или заказать доставку курьером. Команда Limak к вашим услугам, удобные покупки и быстрая доставка!", NewsId = 1, LanguageId = 2},

            new NewsDetail { Id = 3, Title = "Amerika tariflərimiz yeniləndi!", Description = "Amerikadan daşınma tariflərinə yenilik etdik!\r\n \r\n Hörmətli müştərilər, nəzərinizə çatdıraq ki, Amerika tariflərimiz 20 iyul 2024-cü il tarixindən etibarən yenilənir! \r\n \r\n\r\n" +
            "Qeyd olunan tarixdən başlayaraq xarici anbarımıza daxil olan bağlamaların daşınma haqqı çəkiyə uyğun olaraq, yeni tarifə əsasən hesablanacaq! Yeni qiymətlər hazırda bazar rəqabətinə uyğun tənzimlənib. \r\n \r\n\r\nLimak komandası güvənli alış-veriş və sürətli çatdırılma ilə xidmətinizdədir!\r\n \r\n\r\nUzağı yaxın etdik!  ", NewsId = 2, LanguageId = 1},
            new NewsDetail { Id = 4, Title = "Наши американские тарифы обновлены!", Description = "Наши американские тарифы обновлены!\r\n \r\n\r\nУважаемые клиенты, позвольте обратить ваше внимание на то, что наши американские тарифы будут обновлены с 20 июля 2024 года! \r\n \r\n\r\n" +
            "Начиная с указанной даты, стоимость доставки посылок, поступающих на наш зарубежный склад, будет рассчитываться в зависимости от веса, согласно новому тарифу! Обновленные цены в настоящее время скорректированы с учетом рыночной конкуренции.\r\n \r\n\r\nКоманда Limak к вашим услугам, вместе с удобным шоппингом и быстрой доставкой. \r\n \r\n\r\nМы стали еще ближе к вам! ", NewsId = 2, LanguageId = 2},

            new NewsDetail { Id = 5, Title = "Türkiyədən bağlamalarınızı güvənli çatdırırıq", Description = "Limak.az - güvənli və sürətli karqo xidməti\r\n \r\n 5 ildən çoxdur ki, sürətli və güvənli karqo şirkəti olaraq fəaliyyət göstəririk. Bizim üçün müştəri məmnuniyyəti ən vacib prioritetlərdən biridir. Biz, sifarişləri ən qısa zamanda, təhlükəsiz çatdıraraq, müştərilərin güvənini qazanmağı bacarmışıq. Bütün ehtiyaclarınızı nəzərə alaraq, xidmətlərimizi davamlı olaraq təkmilləşdirir və müştərilərimizə ən yüksək, keyfiyyətli xidmətlər təklif edirik.\r\n\r\n \r\n\r\n" +
            "Müştəriləri sevindirəcək xəbər\r\n \r\n Daha sına biləcək bağlamalarınıza görə narahat olmağınıza ehtiyac yoxdur! Sifarişlərinizin güvənli çatdırılması üçün Limak.az karqo şirkəti olaraq, növbəti istəyinizi əlçatan etdik. Hər kəsə məlumdur ki, bir çox hallarda karqo şirkətləri bağlamaların təhlükəsizliyinə görə məsuliyyət daşımır. Lakin biz, müştəriləri düşünərək, sınma təhlükəsi olan bağlamaları xüsusi qablaşdırma və güvənli daşıma ilə sizə çatdırırıq. Beləliklə, sifariş olunan qablar sınmayacaq. Limak.az ilə Türkiyədən istənilən məhsulları əminliklə sifariş edə bilərsiniz.", NewsId = 3, LanguageId = 1},
            new NewsDetail { Id = 6, Title = "Мы безопасно доставим ваши посылки из Турции", Description = "Limak.az - надежная и быстрая служба доставки\r\n\r\nУже более 5 лет мы работаем как быстрая и надежная компания по доставке. Лояльность наших клиентов - один из наших главных приоритетов. Мы добились доверия клиентов, доставляя заказы в кратчайшие сроки и с полной безопасностью. Учитывая все ваши потребности, мы постоянно совершенствуем наши услуги и предлагаем нашим клиентам самые качественные сервисы.\r\n\r\n \r\n\r\n" +
            "Новость, которая порадует клиентов\r\n\r\n\r\nТеперь вам больше не придется беспокоиться о своих посылках, с хрупким товаром! Для безопасной доставки ваших заказов компания Limak.az сделала ваш очередной запрос доступным. Всем известно, что во многих случаях грузовые компании не несут ответственности за сохранность посылок. Однако, думая о наших клиентах, мы доставляем посылки с риском повреждения в специальной упаковке и с безопасной транспортировкой. Так, заказанная посуда не разобьется. С Limak.az вы можете с уверенностью заказывать любые товары из Турции.", NewsId = 3, LanguageId = 2}
            );
    }
    public static void AddSliders(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Slider>().HasData( 
            new Slider { Id = 1, ImagePath = "https://res.cloudinary.com/dsclrbdnp/image/upload/v1737841750/LimakAz/r8uyjrt2rhcdmhte1ahu.png" },
            new Slider { Id = 2, ImagePath = "https://res.cloudinary.com/dsclrbdnp/image/upload/v1737841753/LimakAz/tysnef6of1mfpuur3ejj.jpg" }
        );
    }
  
}
