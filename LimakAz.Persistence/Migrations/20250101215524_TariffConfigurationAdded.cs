using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LimakAz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TariffConfigurationAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Tariffs",
                type: "decimal(10,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MinValue",
                table: "Tariffs",
                type: "decimal(6,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxValue",
                table: "Tariffs",
                type: "decimal(6,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 1, 21, 55, 22, 441, DateTimeKind.Utc).AddTicks(3443), new DateTime(2025, 1, 1, 21, 55, 22, 441, DateTimeKind.Utc).AddTicks(3444) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 1, 21, 55, 22, 441, DateTimeKind.Utc).AddTicks(3447), new DateTime(2025, 1, 1, 21, 55, 22, 441, DateTimeKind.Utc).AddTicks(3448) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Tariffs",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MinValue",
                table: "Tariffs",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxValue",
                table: "Tariffs",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,3)");

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
        }
    }
}
