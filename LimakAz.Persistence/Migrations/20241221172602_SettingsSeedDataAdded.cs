using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LimakAz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SettingsSeedDataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsoCode", "Name" },
                values: new object[] { "az", "AZE" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IsoCode", "Name" },
                values: new object[] { "ru", "RU" });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "Key" },
                values: new object[,]
                {
                    { 1, "Address" },
                    { 2, "WorkingHours" },
                    { 3, "SupportPhone" },
                    { 4, "InstagramLink" },
                    { 5, "FacebookLink" },
                    { 6, "TwitterLink" },
                    { 7, "YoutubeLink" },
                    { 8, "TiktokLink" },
                    { 9, "Copyright" },
                    { 10, "AppstoreLink" },
                    { 11, "GoogleplayLink" },
                    { 12, "Title" }
                });

            migrationBuilder.InsertData(
                table: "SettingDetails",
                columns: new[] { "Id", "LanguageId", "SettingId", "Value" },
                values: new object[,]
                {
                    { 1, 1, 1, " Səbail rayonu, Lermontov küç. 40A" },
                    { 2, 2, 1, "Сабаильский район, ул. Лермонтова 40А" },
                    { 3, 1, 2, "Bazar ertəsi-cümə" },
                    { 4, 2, 2, "Понедельник-Пятница" },
                    { 5, 1, 3, "9595" },
                    { 6, 2, 3, "9595" },
                    { 7, 1, 4, "https://www.instagram.com/asmannn18" },
                    { 8, 2, 4, "https://www.instagram.com/asmannn18" },
                    { 9, 1, 5, "https://www.instagram.com/asmannn18" },
                    { 10, 2, 5, "https://www.instagram.com/asmannn18" },
                    { 11, 1, 6, "https://www.instagram.com/asmannn18" },
                    { 12, 2, 6, "https://www.instagram.com/asmannn18" },
                    { 13, 1, 7, "https://www.instagram.com/asmannn18" },
                    { 14, 2, 7, "https://www.instagram.com/asmannn18" },
                    { 15, 1, 8, "https://www.instagram.com/asmannn18" },
                    { 16, 2, 8, "https://www.instagram.com/asmannn18" },
                    { 17, 1, 9, "© 2019 - 2024 Limak.az | Bütün hüquqlar qorunur" },
                    { 18, 2, 9, "© 2019 - 2024 Limak.az | Все права защищены" },
                    { 19, 1, 10, "https://www.instagram.com/asmannn18" },
                    { 20, 2, 10, "https://www.instagram.com/asmannn18" },
                    { 21, 1, 11, "https://www.instagram.com/asmannn18" },
                    { 22, 2, 11, "https://www.instagram.com/asmannn18" },
                    { 23, 1, 12, "Tariflər | Amerika və Türkiyədən kargo | Limak.az - Daşınma qiymetleri" },
                    { 24, 2, 12, "Грузы из Америки и Турции Тарифы | Limak.az - цены на доставку" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SettingDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SettingDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SettingDetails",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SettingDetails",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SettingDetails",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SettingDetails",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SettingDetails",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SettingDetails",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SettingDetails",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SettingDetails",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SettingDetails",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SettingDetails",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SettingDetails",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "SettingDetails",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "SettingDetails",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "SettingDetails",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "SettingDetails",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "SettingDetails",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "SettingDetails",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "SettingDetails",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "SettingDetails",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "SettingDetails",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "SettingDetails",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "SettingDetails",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsoCode", "Name" },
                values: new object[] { "AZE", "Azerbaijan" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IsoCode", "Name" },
                values: new object[] { "RUS", "Russian" });
        }
    }
}
