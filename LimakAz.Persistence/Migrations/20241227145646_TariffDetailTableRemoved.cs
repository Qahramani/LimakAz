using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LimakAz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TariffDetailTableRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TariffDetails");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TariffDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    TariffId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                values: new object[] { new DateTime(2024, 12, 27, 11, 25, 25, 309, DateTimeKind.Utc).AddTicks(4078), new DateTime(2024, 12, 27, 11, 25, 25, 309, DateTimeKind.Utc).AddTicks(4080) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 27, 11, 25, 25, 309, DateTimeKind.Utc).AddTicks(4084), new DateTime(2024, 12, 27, 11, 25, 25, 309, DateTimeKind.Utc).AddTicks(4085) });

            migrationBuilder.CreateIndex(
                name: "IX_TariffDetails_LanguageId",
                table: "TariffDetails",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_TariffDetails_TariffId",
                table: "TariffDetails",
                column: "TariffId");
        }
    }
}
