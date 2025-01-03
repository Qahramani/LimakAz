using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LimakAz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ContentTableAltered : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                table: "Contents");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "ContentDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 1, 41, 47, 75, DateTimeKind.Utc).AddTicks(6915), new DateTime(2025, 1, 3, 1, 41, 47, 75, DateTimeKind.Utc).AddTicks(6916) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 1, 41, 47, 75, DateTimeKind.Utc).AddTicks(6920), new DateTime(2025, 1, 3, 1, 41, 47, 75, DateTimeKind.Utc).AddTicks(6921) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                table: "ContentDetails");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 1, 37, 29, 861, DateTimeKind.Utc).AddTicks(435), new DateTime(2025, 1, 3, 1, 37, 29, 861, DateTimeKind.Utc).AddTicks(436) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 1, 37, 29, 861, DateTimeKind.Utc).AddTicks(442), new DateTime(2025, 1, 3, 1, 37, 29, 861, DateTimeKind.Utc).AddTicks(443) });
        }
    }
}
