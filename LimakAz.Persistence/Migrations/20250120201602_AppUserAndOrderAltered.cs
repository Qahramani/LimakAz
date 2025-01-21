using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LimakAz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AppUserAndOrderAltered : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLocalCargoFree",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "TotalCargoPrice",
                table: "Order",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Order",
                newName: "OrderTotalPrice");

            migrationBuilder.AddColumn<decimal>(
                name: "CargoPrice",
                table: "Order",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ItemPrice",
                table: "Order",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 20, 15, 59, 364, DateTimeKind.Utc).AddTicks(1749), new DateTime(2025, 1, 20, 20, 15, 59, 364, DateTimeKind.Utc).AddTicks(1750) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 20, 15, 59, 364, DateTimeKind.Utc).AddTicks(1755), new DateTime(2025, 1, 20, 20, 15, 59, 364, DateTimeKind.Utc).AddTicks(1756) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CargoPrice",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ItemPrice",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Order",
                newName: "TotalCargoPrice");

            migrationBuilder.RenameColumn(
                name: "OrderTotalPrice",
                table: "Order",
                newName: "Price");

            migrationBuilder.AddColumn<bool>(
                name: "IsLocalCargoFree",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 2, 21, 51, 715, DateTimeKind.Utc).AddTicks(8838), new DateTime(2025, 1, 20, 2, 21, 51, 715, DateTimeKind.Utc).AddTicks(8838) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 2, 21, 51, 715, DateTimeKind.Utc).AddTicks(8841), new DateTime(2025, 1, 20, 2, 21, 51, 715, DateTimeKind.Utc).AddTicks(8842) });
        }
    }
}
