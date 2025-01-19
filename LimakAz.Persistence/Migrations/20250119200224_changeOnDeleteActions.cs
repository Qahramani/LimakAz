using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LimakAz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changeOnDeleteActions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_UserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Countries_CountryId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_LocalPoints_LocalPointId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Shops_ShopId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Statuses_StatusId",
                table: "Order");

            migrationBuilder.AlterColumn<int>(
                name: "ShopId",
                table: "Order",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 19, 20, 2, 19, 248, DateTimeKind.Utc).AddTicks(8173), new DateTime(2025, 1, 19, 20, 2, 19, 248, DateTimeKind.Utc).AddTicks(8175) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 19, 20, 2, 19, 248, DateTimeKind.Utc).AddTicks(8180), new DateTime(2025, 1, 19, 20, 2, 19, 248, DateTimeKind.Utc).AddTicks(8181) });

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_UserId",
                table: "Order",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Countries_CountryId",
                table: "Order",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_LocalPoints_LocalPointId",
                table: "Order",
                column: "LocalPointId",
                principalTable: "LocalPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Shops_ShopId",
                table: "Order",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Statuses_StatusId",
                table: "Order",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_UserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Countries_CountryId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_LocalPoints_LocalPointId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Shops_ShopId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Statuses_StatusId",
                table: "Order");

            migrationBuilder.AlterColumn<int>(
                name: "ShopId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 19, 19, 3, 3, 290, DateTimeKind.Utc).AddTicks(8935), new DateTime(2025, 1, 19, 19, 3, 3, 290, DateTimeKind.Utc).AddTicks(8936) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 19, 19, 3, 3, 290, DateTimeKind.Utc).AddTicks(8939), new DateTime(2025, 1, 19, 19, 3, 3, 290, DateTimeKind.Utc).AddTicks(8940) });

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_UserId",
                table: "Order",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Countries_CountryId",
                table: "Order",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_LocalPoints_LocalPointId",
                table: "Order",
                column: "LocalPointId",
                principalTable: "LocalPoints",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Shops_ShopId",
                table: "Order",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Statuses_StatusId",
                table: "Order",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id");
        }
    }
}
