using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LimakAz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataUpdaded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 30, 18, 46, 50, 725, DateTimeKind.Utc).AddTicks(9341), new DateTime(2024, 12, 30, 18, 46, 50, 725, DateTimeKind.Utc).AddTicks(9341) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 30, 18, 46, 50, 725, DateTimeKind.Utc).AddTicks(9345), new DateTime(2024, 12, 30, 18, 46, 50, 725, DateTimeKind.Utc).AddTicks(9346) });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "Key" },
                values: new object[] { 13, "SupportLineImage" });

            migrationBuilder.InsertData(
                table: "SettingDetails",
                columns: new[] { "Id", "LanguageId", "SettingId", "Value" },
                values: new object[,]
                {
                    { 25, 1, 13, "https://res.cloudinary.com/dsclrbdnp/image/upload/v1735583341/LimakAz/ggh5cyvitqg56p1avgef.svg" },
                    { 26, 2, 13, "https://res.cloudinary.com/dsclrbdnp/image/upload/v1735583605/LimakAz/zkp51genu3lmjahjuox7.svg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SettingDetails",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "SettingDetails",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 27, 14, 56, 44, 205, DateTimeKind.Utc).AddTicks(6772), new DateTime(2024, 12, 27, 14, 56, 44, 205, DateTimeKind.Utc).AddTicks(6773) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 27, 14, 56, 44, 205, DateTimeKind.Utc).AddTicks(6776), new DateTime(2024, 12, 27, 14, 56, 44, 205, DateTimeKind.Utc).AddTicks(6777) });
        }
    }
}
