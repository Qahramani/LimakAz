using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LimakAz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LocalPointDescriptionAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "LocalPointDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 2, 1, 11, 30, 283, DateTimeKind.Utc).AddTicks(5487), new DateTime(2025, 1, 2, 1, 11, 30, 283, DateTimeKind.Utc).AddTicks(5489) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 2, 1, 11, 30, 283, DateTimeKind.Utc).AddTicks(5497), new DateTime(2025, 1, 2, 1, 11, 30, 283, DateTimeKind.Utc).AddTicks(5498) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "LocalPointDetails");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 2, 0, 16, 35, 687, DateTimeKind.Utc).AddTicks(55), new DateTime(2025, 1, 2, 0, 16, 35, 687, DateTimeKind.Utc).AddTicks(56) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 2, 0, 16, 35, 687, DateTimeKind.Utc).AddTicks(60), new DateTime(2025, 1, 2, 0, 16, 35, 687, DateTimeKind.Utc).AddTicks(61) });
        }
    }
}
