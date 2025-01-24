using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LimakAz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemovedOrderInAznProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderTotalPriceInAzn",
                table: "Order");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 23, 22, 17, 22, 83, DateTimeKind.Utc).AddTicks(4580), new DateTime(2025, 1, 23, 22, 17, 22, 83, DateTimeKind.Utc).AddTicks(4581) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 23, 22, 17, 22, 83, DateTimeKind.Utc).AddTicks(4584), new DateTime(2025, 1, 23, 22, 17, 22, 83, DateTimeKind.Utc).AddTicks(4585) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "OrderTotalPriceInAzn",
                table: "Order",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 23, 22, 3, 34, 719, DateTimeKind.Utc).AddTicks(5536), new DateTime(2025, 1, 23, 22, 3, 34, 719, DateTimeKind.Utc).AddTicks(5538) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 23, 22, 3, 34, 719, DateTimeKind.Utc).AddTicks(5542), new DateTime(2025, 1, 23, 22, 3, 34, 719, DateTimeKind.Utc).AddTicks(5543) });
        }
    }
}
