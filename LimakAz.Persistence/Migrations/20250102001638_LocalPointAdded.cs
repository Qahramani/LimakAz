using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LimakAz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LocalPointAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocalPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalPoints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocalPointDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkingHourse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalPointId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalPointDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocalPointDetails_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocalPointDetails_LocalPoints_LocalPointId",
                        column: x => x.LocalPointId,
                        principalTable: "LocalPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_LocalPointDetails_LanguageId",
                table: "LocalPointDetails",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalPointDetails_LocalPointId",
                table: "LocalPointDetails",
                column: "LocalPointId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalPointDetails");

            migrationBuilder.DropTable(
                name: "LocalPoints");

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
    }
}
