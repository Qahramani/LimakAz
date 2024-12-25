using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LimakAz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SomeManyChangesMade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Locations_LocationId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "LocationDetails");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropColumn(
                name: "IsTermsAccepted",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "AspNetUsers",
                newName: "WareHouseId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_LocationId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_WareHouseId");

            migrationBuilder.AddColumn<decimal>(
                name: "AZNBalance",
                table: "AspNetUsers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TRYBalance",
                table: "AspNetUsers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WareHouse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkingHourse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WareHouse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryDetails_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryDetails_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryDetails_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryDetails_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shops_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewsId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewDetails_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewDetails_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ShopId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopCategories_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDeleted", "LogoPath", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 25, 19, 6, 49, 281, DateTimeKind.Utc).AddTicks(1417), "default", false, "", new DateTime(2024, 12, 25, 19, 6, 49, 281, DateTimeKind.Utc).AddTicks(1419), "default" },
                    { 2, new DateTime(2024, 12, 25, 19, 6, 49, 281, DateTimeKind.Utc).AddTicks(1424), "default", false, "", new DateTime(2024, 12, 25, 19, 6, 49, 281, DateTimeKind.Utc).AddTicks(1425), "default" }
                });

            migrationBuilder.InsertData(
                table: "Certificates",
                columns: new[] { "Id", "ImagePath", "Link" },
                values: new object[,]
                {
                    { 1, "https://res.cloudinary.com/dsclrbdnp/image/upload/v1735148773/LimakAz/fhe6fq69cr1lqamzvhsm.png", "https://www.iata.org/" },
                    { 2, "https://res.cloudinary.com/dsclrbdnp/image/upload/v1735148773/LimakAz/usq5qshiktvvcioeu0xe.png", "https://www.turkishairlines.com/" },
                    { 3, "https://res.cloudinary.com/dsclrbdnp/image/upload/v1735148773/LimakAz/qtiaad8swg6yvs8jobdj.png", "https://fiata.org/" },
                    { 4, "https://res.cloudinary.com/dsclrbdnp/image/upload/v1735148773/LimakAz/ovgeyi6xr3eahskj0u8f.png", "https://limaklogistic.com/tr" },
                    { 5, "https://res.cloudinary.com/dsclrbdnp/image/upload/v1735148773/LimakAz/m9q1xavaxdofuxsc380m.png", "https://www.silkwaywest.com/" },
                    { 6, "https://res.cloudinary.com/dsclrbdnp/image/upload/v1735148773/LimakAz/l9ropu52ecsgkqyd3uej.png", "https://apagroup.az/az" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                column: "Id",
                values: new object[]
                {
                    1,
                    2
                });

            migrationBuilder.InsertData(
                table: "CategoryDetails",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "CreatedBy", "IsDeleted", "LanguageId", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 12, 25, 19, 6, 49, 281, DateTimeKind.Utc).AddTicks(1536), "default", false, 1, "Qeyim", new DateTime(2024, 12, 25, 19, 6, 49, 281, DateTimeKind.Utc).AddTicks(1537), "default" },
                    { 2, 1, new DateTime(2024, 12, 25, 19, 6, 49, 281, DateTimeKind.Utc).AddTicks(1542), "default", false, 2, "Одежда", new DateTime(2024, 12, 25, 19, 6, 49, 281, DateTimeKind.Utc).AddTicks(1543), "default" },
                    { 3, 2, new DateTime(2024, 12, 25, 19, 6, 49, 281, DateTimeKind.Utc).AddTicks(1547), "default", false, 1, "Kosmetika", new DateTime(2024, 12, 25, 19, 6, 49, 281, DateTimeKind.Utc).AddTicks(1548), "default" },
                    { 4, 2, new DateTime(2024, 12, 25, 19, 6, 49, 281, DateTimeKind.Utc).AddTicks(1551), "default", false, 2, "Косметика", new DateTime(2024, 12, 25, 19, 6, 49, 281, DateTimeKind.Utc).AddTicks(1552), "default" }
                });

            migrationBuilder.InsertData(
                table: "GenderDetails",
                columns: new[] { "Id", "GenderId", "LanguageId", "Name" },
                values: new object[,]
                {
                    { 1, 1, 1, "Qadin" },
                    { 2, 2, 1, "Kişi" },
                    { 3, 1, 2, "Женщина" },
                    { 4, 2, 2, "Мужчина" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryDetails_CategoryId",
                table: "CategoryDetails",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryDetails_LanguageId",
                table: "CategoryDetails",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryDetails_CountryId",
                table: "CountryDetails",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryDetails_LanguageId",
                table: "CountryDetails",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_NewDetails_LanguageId",
                table: "NewDetails",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_NewDetails_NewsId",
                table: "NewDetails",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopCategories_CategoryId",
                table: "ShopCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopCategories_ShopId",
                table: "ShopCategories",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_CountryId",
                table: "Shops",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_WareHouse_WareHouseId",
                table: "AspNetUsers",
                column: "WareHouseId",
                principalTable: "WareHouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_WareHouse_WareHouseId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CategoryDetails");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "CountryDetails");

            migrationBuilder.DropTable(
                name: "NewDetails");

            migrationBuilder.DropTable(
                name: "ShopCategories");

            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.DropTable(
                name: "WareHouse");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DeleteData(
                table: "GenderDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GenderDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GenderDetails",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GenderDetails",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "AZNBalance",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TRYBalance",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "WareHouseId",
                table: "AspNetUsers",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_WareHouseId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_LocationId");

            migrationBuilder.AddColumn<bool>(
                name: "IsTermsAccepted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationDetails_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationDetails_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationDetails_LanguageId",
                table: "LocationDetails",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationDetails_LocationId",
                table: "LocationDetails",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Locations_LocationId",
                table: "AspNetUsers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
