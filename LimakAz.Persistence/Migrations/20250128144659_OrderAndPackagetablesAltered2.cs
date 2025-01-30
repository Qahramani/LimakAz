using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LimakAz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class OrderAndPackagetablesAltered2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_AspNetUsers_AppUserId",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Statuses_StatusId1",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_AppUserId",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_StatusId1",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "StatusId1",
                table: "OrderItem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "OrderItem",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId1",
                table: "OrderItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_AppUserId",
                table: "OrderItem",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_StatusId1",
                table: "OrderItem",
                column: "StatusId1");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_AspNetUsers_AppUserId",
                table: "OrderItem",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Statuses_StatusId1",
                table: "OrderItem",
                column: "StatusId1",
                principalTable: "Statuses",
                principalColumn: "Id");
        }
    }
}
