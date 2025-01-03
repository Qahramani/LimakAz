using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LimakAz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UserPositionAndCitizenShipAddedAndAppUserAltered : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_WareHouse_WareHouseId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "WareHouse");

            migrationBuilder.RenameColumn(
                name: "WareHouseId",
                table: "AspNetUsers",
                newName: "UserPositionId");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "AspNetUsers",
                newName: "FinCode");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_WareHouseId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_UserPositionId");

            migrationBuilder.AddColumn<int>(
                name: "CitizenShipId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsTermsAccepted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LocalPointId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CitizenShips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitizenShips", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CitizenShipDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CitizenShipId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitizenShipDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CitizenShipDetails_CitizenShips_CitizenShipId",
                        column: x => x.CitizenShipId,
                        principalTable: "CitizenShips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CitizenShipDetails_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPositionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPositionId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPositionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPositionDetails_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPositionDetails_UserPositions_UserPositionId",
                        column: x => x.UserPositionId,
                        principalTable: "UserPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "CitizenShips",
                column: "Id",
                values: new object[]
                {
                    1,
                    2
                });

            migrationBuilder.InsertData(
                table: "UserPositions",
                column: "Id",
                values: new object[]
                {
                    1,
                    2
                });

            migrationBuilder.InsertData(
                table: "CitizenShipDetails",
                columns: new[] { "Id", "CitizenShipId", "LanguageId", "Name" },
                values: new object[,]
                {
                    { 1, 1, 1, "Fiziki şəxs" },
                    { 2, 1, 2, "Физическое лицо" },
                    { 3, 2, 1, "Hüquq şəxs" },
                    { 4, 2, 2, "Юридическое лицо" }
                });

            migrationBuilder.InsertData(
                table: "UserPositionDetails",
                columns: new[] { "Id", "LanguageId", "Name", "UserPositionId" },
                values: new object[,]
                {
                    { 1, 1, "Azərbaycan", 1 },
                    { 2, 2, "Азербайджан", 1 },
                    { 3, 1, "Xarici", 2 },
                    { 4, 2, "Другое", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CitizenShipId",
                table: "AspNetUsers",
                column: "CitizenShipId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LocalPointId",
                table: "AspNetUsers",
                column: "LocalPointId");

            migrationBuilder.CreateIndex(
                name: "IX_CitizenShipDetails_CitizenShipId",
                table: "CitizenShipDetails",
                column: "CitizenShipId");

            migrationBuilder.CreateIndex(
                name: "IX_CitizenShipDetails_LanguageId",
                table: "CitizenShipDetails",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPositionDetails_LanguageId",
                table: "UserPositionDetails",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPositionDetails_UserPositionId",
                table: "UserPositionDetails",
                column: "UserPositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_CitizenShips_CitizenShipId",
                table: "AspNetUsers",
                column: "CitizenShipId",
                principalTable: "CitizenShips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_LocalPoints_LocalPointId",
                table: "AspNetUsers",
                column: "LocalPointId",
                principalTable: "LocalPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserPositions_UserPositionId",
                table: "AspNetUsers",
                column: "UserPositionId",
                principalTable: "UserPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CitizenShips_CitizenShipId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_LocalPoints_LocalPointId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserPositions_UserPositionId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CitizenShipDetails");

            migrationBuilder.DropTable(
                name: "UserPositionDetails");

            migrationBuilder.DropTable(
                name: "CitizenShips");

            migrationBuilder.DropTable(
                name: "UserPositions");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CitizenShipId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LocalPointId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CitizenShipId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsTermsAccepted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LocalPointId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserPositionId",
                table: "AspNetUsers",
                newName: "WareHouseId");

            migrationBuilder.RenameColumn(
                name: "FinCode",
                table: "AspNetUsers",
                newName: "Code");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_UserPositionId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_WareHouseId");

            migrationBuilder.CreateTable(
                name: "WareHouse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkingHourse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WareHouse", x => x.Id);
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_WareHouse_WareHouseId",
                table: "AspNetUsers",
                column: "WareHouseId",
                principalTable: "WareHouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
