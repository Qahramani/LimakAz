using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LimakAz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ModeratorIdMadeNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ModeratorId",
                table: "Chats",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 21, 25, 36, 539, DateTimeKind.Utc).AddTicks(6846), new DateTime(2025, 1, 20, 21, 25, 36, 539, DateTimeKind.Utc).AddTicks(6847) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 20, 21, 25, 36, 539, DateTimeKind.Utc).AddTicks(6853), new DateTime(2025, 1, 20, 21, 25, 36, 539, DateTimeKind.Utc).AddTicks(6854) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ModeratorId",
                table: "Chats",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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
    }
}
