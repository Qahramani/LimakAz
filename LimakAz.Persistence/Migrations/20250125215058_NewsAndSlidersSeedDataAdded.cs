using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LimakAz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NewsAndSlidersSeedDataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "ImagePath", "IsDeleted", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Defaul", "https://res.cloudinary.com/dsclrbdnp/image/upload/v1737841428/LimakAz/tkqkwproumeajbfifprs.jpg", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Default" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Defaul", "https://res.cloudinary.com/dsclrbdnp/image/upload/v1737841438/LimakAz/m4yxdcrc4jy33iapjela.jpg", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Default" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Defaul", "https://res.cloudinary.com/dsclrbdnp/image/upload/v1737841534/LimakAz/yccukiy8giu0hsx76ria.jpg", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Default" }
                });

            migrationBuilder.InsertData(
                table: "Sliders",
                columns: new[] { "Id", "ImagePath" },
                values: new object[,]
                {
                    { 1, "https://res.cloudinary.com/dsclrbdnp/image/upload/v1737841750/LimakAz/r8uyjrt2rhcdmhte1ahu.png" },
                    { 2, "https://res.cloudinary.com/dsclrbdnp/image/upload/v1737841753/LimakAz/tysnef6of1mfpuur3ejj.jpg" }
                });

            migrationBuilder.InsertData(
                table: "NewDetails",
                columns: new[] { "Id", "Description", "LanguageId", "NewsId", "Title" },
                values: new object[,]
                {
                    { 1, "Dəyərli müştərilər, çoxsaylı istəkləri nəzərə alaraq, yeni açılan Quba filialımız artıq xidmətinizdədir. Quba filialının ünvanı: Quba şəhəri, Fətəli xan və Səməd Vurğun küçəsinin kəsişməsi. \r\n \r\n Seçdiyiniz məhsulların linkini bizə göndərməklə sifarişlərinizi SifarişEt xidmətimizə həvalə edin. Amerika və Türkiyədən gələn bağlamalarınızı filiallardan, kuryerlərimizdən və ya kargomatlardan təhvil ala bilərsiniz. Limak komandası rahat alış-veriş və sürətli çatdırılma ilə xidmətinizdədir!", 1, 1, "Limakın yeni Quba filialı!" },
                    { 2, "Уважаемые клиенты, учитывая многочисленные запросы, наш филиал Губа теперь к вашим услугам. Адрес Губинского филиала: г. Губа, пересечение улиц Фатали Хана и Самеда Вургуна. \r\n \r\n Отправьте ссылку на выбранные вами продукты, и пусть наша служба «Заказать» обработает ваши заказы. Посылки из Америки и Турции вы можете получить в наших филиалах, в ближайших каргоматах или заказать доставку курьером. Команда Limak к вашим услугам, удобные покупки и быстрая доставка!", 2, 1, "Новый филиал Лимака в Губе!" },
                    { 3, "Amerikadan daşınma tariflərinə yenilik etdik!\r\n \r\n Hörmətli müştərilər, nəzərinizə çatdıraq ki, Amerika tariflərimiz 20 iyul 2024-cü il tarixindən etibarən yenilənir! \r\n \r\n\r\nQeyd olunan tarixdən başlayaraq xarici anbarımıza daxil olan bağlamaların daşınma haqqı çəkiyə uyğun olaraq, yeni tarifə əsasən hesablanacaq! Yeni qiymətlər hazırda bazar rəqabətinə uyğun tənzimlənib. \r\n \r\n\r\nLimak komandası güvənli alış-veriş və sürətli çatdırılma ilə xidmətinizdədir!\r\n \r\n\r\nUzağı yaxın etdik!  ", 1, 2, "Amerika tariflərimiz yeniləndi!" },
                    { 4, "Наши американские тарифы обновлены!\r\n \r\n\r\nУважаемые клиенты, позвольте обратить ваше внимание на то, что наши американские тарифы будут обновлены с 20 июля 2024 года! \r\n \r\n\r\nНачиная с указанной даты, стоимость доставки посылок, поступающих на наш зарубежный склад, будет рассчитываться в зависимости от веса, согласно новому тарифу! Обновленные цены в настоящее время скорректированы с учетом рыночной конкуренции.\r\n \r\n\r\nКоманда Limak к вашим услугам, вместе с удобным шоппингом и быстрой доставкой. \r\n \r\n\r\nМы стали еще ближе к вам! ", 2, 2, "Наши американские тарифы обновлены!" },
                    { 5, "Limak.az - güvənli və sürətli karqo xidməti\r\n \r\n 5 ildən çoxdur ki, sürətli və güvənli karqo şirkəti olaraq fəaliyyət göstəririk. Bizim üçün müştəri məmnuniyyəti ən vacib prioritetlərdən biridir. Biz, sifarişləri ən qısa zamanda, təhlükəsiz çatdıraraq, müştərilərin güvənini qazanmağı bacarmışıq. Bütün ehtiyaclarınızı nəzərə alaraq, xidmətlərimizi davamlı olaraq təkmilləşdirir və müştərilərimizə ən yüksək, keyfiyyətli xidmətlər təklif edirik.\r\n\r\n \r\n\r\nMüştəriləri sevindirəcək xəbər\r\n \r\n Daha sına biləcək bağlamalarınıza görə narahat olmağınıza ehtiyac yoxdur! Sifarişlərinizin güvənli çatdırılması üçün Limak.az karqo şirkəti olaraq, növbəti istəyinizi əlçatan etdik. Hər kəsə məlumdur ki, bir çox hallarda karqo şirkətləri bağlamaların təhlükəsizliyinə görə məsuliyyət daşımır. Lakin biz, müştəriləri düşünərək, sınma təhlükəsi olan bağlamaları xüsusi qablaşdırma və güvənli daşıma ilə sizə çatdırırıq. Beləliklə, sifariş olunan qablar sınmayacaq. Limak.az ilə Türkiyədən istənilən məhsulları əminliklə sifariş edə bilərsiniz.", 1, 3, "Türkiyədən bağlamalarınızı güvənli çatdırırıq" },
                    { 6, "Limak.az - надежная и быстрая служба доставки\r\n\r\nУже более 5 лет мы работаем как быстрая и надежная компания по доставке. Лояльность наших клиентов - один из наших главных приоритетов. Мы добились доверия клиентов, доставляя заказы в кратчайшие сроки и с полной безопасностью. Учитывая все ваши потребности, мы постоянно совершенствуем наши услуги и предлагаем нашим клиентам самые качественные сервисы.\r\n\r\n \r\n\r\nНовость, которая порадует клиентов\r\n\r\n\r\nТеперь вам больше не придется беспокоиться о своих посылках, с хрупким товаром! Для безопасной доставки ваших заказов компания Limak.az сделала ваш очередной запрос доступным. Всем известно, что во многих случаях грузовые компании не несут ответственности за сохранность посылок. Однако, думая о наших клиентах, мы доставляем посылки с риском повреждения в специальной упаковке и с безопасной транспортировкой. Так, заказанная посуда не разобьется. С Limak.az вы можете с уверенностью заказывать любые товары из Турции.", 2, 3, "Мы безопасно доставим ваши посылки из Турции" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NewDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NewDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NewDetails",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "NewDetails",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "NewDetails",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "NewDetails",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
