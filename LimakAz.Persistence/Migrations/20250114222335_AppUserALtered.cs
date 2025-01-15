using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LimakAz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AppUserALtered : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsTermsAccepted",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 14, 22, 23, 33, 241, DateTimeKind.Utc).AddTicks(9782), new DateTime(2025, 1, 14, 22, 23, 33, 241, DateTimeKind.Utc).AddTicks(9783) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 14, 22, 23, 33, 241, DateTimeKind.Utc).AddTicks(9786), new DateTime(2025, 1, 14, 22, 23, 33, 241, DateTimeKind.Utc).AddTicks(9787) });

            migrationBuilder.UpdateData(
                table: "CitizenShipDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Azərbaycan");

            migrationBuilder.UpdateData(
                table: "CitizenShipDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Азербайджан");

            migrationBuilder.UpdateData(
                table: "CitizenShipDetails",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Xarici");

            migrationBuilder.UpdateData(
                table: "CitizenShipDetails",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Другое");

            migrationBuilder.UpdateData(
                table: "UserPositionDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Fiziki şəxs");

            migrationBuilder.UpdateData(
                table: "UserPositionDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Физическое лицо");

            migrationBuilder.UpdateData(
                table: "UserPositionDetails",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Hüquq şəxs");

            migrationBuilder.UpdateData(
                table: "UserPositionDetails",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Юридическое лицо");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTermsAccepted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 16, 54, 26, 408, DateTimeKind.Utc).AddTicks(601), new DateTime(2025, 1, 3, 16, 54, 26, 408, DateTimeKind.Utc).AddTicks(603) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 16, 54, 26, 408, DateTimeKind.Utc).AddTicks(610), new DateTime(2025, 1, 3, 16, 54, 26, 408, DateTimeKind.Utc).AddTicks(611) });

            migrationBuilder.UpdateData(
                table: "CitizenShipDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Fiziki şəxs");

            migrationBuilder.UpdateData(
                table: "CitizenShipDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Физическое лицо");

            migrationBuilder.UpdateData(
                table: "CitizenShipDetails",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Hüquq şəxs");

            migrationBuilder.UpdateData(
                table: "CitizenShipDetails",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Юридическое лицо");

            migrationBuilder.UpdateData(
                table: "UserPositionDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Azərbaycan");

            migrationBuilder.UpdateData(
                table: "UserPositionDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Азербайджан");

            migrationBuilder.UpdateData(
                table: "UserPositionDetails",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Xarici");

            migrationBuilder.UpdateData(
                table: "UserPositionDetails",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Другое");
        }
    }
}
