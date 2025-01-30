using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LimakAz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LocalPointSeedDataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LocalPoints",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDeleted", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Defaul", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Default" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Defaul", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Default" }
                });

            migrationBuilder.InsertData(
                table: "LocalPointDetails",
                columns: new[] { "Id", "Description", "LanguageId", "LocalPointId", "Name", "WorkingHourse" },
                values: new object[,]
                {
                    { 1, "Gəncə şəhəri, Kəpəz rayonu, Əziz Əliyev prospekti, 5A. (Köhnə Yevlax avtovağzalı və Neon dəyirmanının yaxınlığı)", 1, 1, "Limak - Gəncə", "Bazar ertəsi-şənbə\r\nSaat 10:00 - 20:00\r\n\r\nŞənbə\r\nSaat 10:00 - 20:00" },
                    { 2, "Город Гянджа, Кепазский район, проспект Азиза Алиева, 5А. (Рядом с автовокзалом Евлаха и Неоновой мельницей)", 2, 1, "Limak - Гянджа", "Понедельник-Суббота\r\nС 10:00 до 20:00\r\n\r\nСуббота\r\nС 10:00 до 20:00" },
                    { 3, "Nizami rayonu, Qara Qarayev prospekti, 125a (Səhhət klinikasının yaxınlığı)", 1, 2, "Limak - Xalqlar Dostluğu", "Bazar ertəsi-şənbə\r\nSaat 10:00 - 20:00\r\n\r\nŞənbə\r\nSaat 10:00 - 20:00" },
                    { 4, "Низаминский район, проспект Кара Караева, 125а ( возле поликлиники “SƏHHƏT” )", 2, 2, "Limak - Халглар Достлугу", "Понедельник-Суббота\r\nС 10:00 до 20:00\r\n\r\nСуббота\r\nС 10:00 до 20:00" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LocalPointDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LocalPointDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LocalPointDetails",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LocalPointDetails",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "LocalPoints",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LocalPoints",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
