using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LimakAz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddressLineSeedDataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AddressLines",
                columns: new[] { "Id", "CountryId", "Key", "Value" },
                values: new object[,]
                {
                    { 1, 4, "XaricdekiUnvanlar-VergiNo", "6081089593" },
                    { 2, 4, "XaricdekiUnvanlar-Ulke", "Türkiye" },
                    { 3, 4, "XaricdekiUnvanlar-VergiDairesi", "Şişli" },
                    { 4, 4, "XaricdekiUnvanlar-PostKodu", "34060" },
                    { 5, 4, "XaricdekiUnvanlar-Telefon", "05364700021" },
                    { 6, 4, "XaricdekiUnvanlar-İlce", "Eyüpsultan" },
                    { 7, 4, "XaricdekiUnvanlar-TCKimlik", "35650276048" },
                    { 8, 4, "XaricdekiUnvanlar-Semt", "Güzeltepe mahallesi" },
                    { 9, 4, "XaricdekiUnvanlar-IlSehir", "İstanbul" },
                    { 10, 4, "XaricdekiUnvanlar-AdressSatir", ",Güzeltepe mahallesi,Akdeniz caddesi no:33/A" },
                    { 11, 4, "XaricdekiUnvanlar-AdressBasligi", "LIMAK" },
                    { 12, 4, "XaricdekiUnvanlar-AdSoyad", "LİMAK TAŞIMACILIK DIŞ TİCARET LİMİTED ŞİRKETİ" },
                    { 13, 4, "Is-Saatlari", "Həftəiçi 5 gün: 09:00 - 17:00\r\nŞənbə: 09:00 - 14:00\r\nBazar günü qeyri-iş günüdür." },
                    { 14, 5, "Street-Address", "1234 Elm Street, Suite 567" },
                    { 15, 5, "City", "New York" },
                    { 16, 5, "State", "NY" },
                    { 17, 5, "ZIP-Code", "10001" },
                    { 18, 5, "Country", "USA" },
                    { 19, 5, "Phone-Number", "+1-555-123-4567" },
                    { 20, 5, "Working-Hours", "Mon-Fri, 9:00 AM - 5:00 PM EST" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 17, 2, 10, 33, 791, DateTimeKind.Utc).AddTicks(6377), new DateTime(2025, 1, 17, 2, 10, 33, 791, DateTimeKind.Utc).AddTicks(6378) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 17, 2, 10, 33, 791, DateTimeKind.Utc).AddTicks(6381), new DateTime(2025, 1, 17, 2, 10, 33, 791, DateTimeKind.Utc).AddTicks(6381) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AddressLines",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AddressLines",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AddressLines",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AddressLines",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AddressLines",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AddressLines",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AddressLines",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AddressLines",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AddressLines",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AddressLines",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AddressLines",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AddressLines",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AddressLines",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AddressLines",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AddressLines",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AddressLines",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AddressLines",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AddressLines",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AddressLines",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AddressLines",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 17, 2, 8, 54, 336, DateTimeKind.Utc).AddTicks(9145), new DateTime(2025, 1, 17, 2, 8, 54, 336, DateTimeKind.Utc).AddTicks(9145) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 17, 2, 8, 54, 336, DateTimeKind.Utc).AddTicks(9148), new DateTime(2025, 1, 17, 2, 8, 54, 336, DateTimeKind.Utc).AddTicks(9149) });
        }
    }
}
