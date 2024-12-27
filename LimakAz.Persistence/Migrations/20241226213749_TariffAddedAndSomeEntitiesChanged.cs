using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LimakAz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TariffAddedAndSomeEntitiesChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "NewDetails");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "NewDetails");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "NewDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "NewDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "NewDetails");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CategoryDetails");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CategoryDetails");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CategoryDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "CategoryDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "CategoryDetails");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "WareHouse",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "WareHouse",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "WareHouse",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "WareHouse",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "WareHouse",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Tariffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tariffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tariffs_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TariffDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TariffId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TariffDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TariffDetails_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TariffDetails_Tariffs_TariffId",
                        column: x => x.TariffId,
                        principalTable: "Tariffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 21, 37, 46, 871, DateTimeKind.Utc).AddTicks(594), new DateTime(2024, 12, 26, 21, 37, 46, 871, DateTimeKind.Utc).AddTicks(596) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 21, 37, 46, 871, DateTimeKind.Utc).AddTicks(600), new DateTime(2024, 12, 26, 21, 37, 46, 871, DateTimeKind.Utc).AddTicks(601) });

            migrationBuilder.CreateIndex(
                name: "IX_TariffDetails_LanguageId",
                table: "TariffDetails",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_TariffDetails_TariffId",
                table: "TariffDetails",
                column: "TariffId");

            migrationBuilder.CreateIndex(
                name: "IX_Tariffs_CountryId",
                table: "Tariffs",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TariffDetails");

            migrationBuilder.DropTable(
                name: "Tariffs");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "WareHouse");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "WareHouse");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "WareHouse");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "WareHouse");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "WareHouse");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "NewDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "NewDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "NewDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "NewDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "NewDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "CategoryDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CategoryDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CategoryDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "CategoryDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "CategoryDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 25, 19, 6, 49, 281, DateTimeKind.Utc).AddTicks(1417), new DateTime(2024, 12, 25, 19, 6, 49, 281, DateTimeKind.Utc).AddTicks(1419) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 25, 19, 6, 49, 281, DateTimeKind.Utc).AddTicks(1424), new DateTime(2024, 12, 25, 19, 6, 49, 281, DateTimeKind.Utc).AddTicks(1425) });

            migrationBuilder.UpdateData(
                table: "CategoryDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy", "IsDeleted", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new DateTime(2024, 12, 25, 19, 6, 49, 281, DateTimeKind.Utc).AddTicks(1536), "default", false, new DateTime(2024, 12, 25, 19, 6, 49, 281, DateTimeKind.Utc).AddTicks(1537), "default" });

            migrationBuilder.UpdateData(
                table: "CategoryDetails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy", "IsDeleted", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new DateTime(2024, 12, 25, 19, 6, 49, 281, DateTimeKind.Utc).AddTicks(1542), "default", false, new DateTime(2024, 12, 25, 19, 6, 49, 281, DateTimeKind.Utc).AddTicks(1543), "default" });

            migrationBuilder.UpdateData(
                table: "CategoryDetails",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy", "IsDeleted", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new DateTime(2024, 12, 25, 19, 6, 49, 281, DateTimeKind.Utc).AddTicks(1547), "default", false, new DateTime(2024, 12, 25, 19, 6, 49, 281, DateTimeKind.Utc).AddTicks(1548), "default" });

            migrationBuilder.UpdateData(
                table: "CategoryDetails",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy", "IsDeleted", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new DateTime(2024, 12, 25, 19, 6, 49, 281, DateTimeKind.Utc).AddTicks(1551), "default", false, new DateTime(2024, 12, 25, 19, 6, 49, 281, DateTimeKind.Utc).AddTicks(1552), "default" });
        }
    }
}
