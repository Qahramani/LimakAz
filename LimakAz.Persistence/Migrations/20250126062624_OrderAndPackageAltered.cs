using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LimakAz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class OrderAndPackageAltered : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_LocalPoints_LocalPointId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_LocalPointId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "LocalPointId",
                table: "Order");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "LocalPointId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_LocalPointId",
                table: "Order",
                column: "LocalPointId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_LocalPoints_LocalPointId",
                table: "Order",
                column: "LocalPointId",
                principalTable: "LocalPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
