using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LimakAz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class OrderTableAltered : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsCancel",
                table: "Order",
                newName: "IsPaid");

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 23, 19, 56, 20, 754, DateTimeKind.Utc).AddTicks(4935), new DateTime(2025, 1, 23, 19, 56, 20, 754, DateTimeKind.Utc).AddTicks(4937) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 23, 19, 56, 20, 754, DateTimeKind.Utc).AddTicks(4940), new DateTime(2025, 1, 23, 19, 56, 20, 754, DateTimeKind.Utc).AddTicks(4941) });

            migrationBuilder.CreateIndex(
                name: "IX_Order_PaymentId",
                table: "Order",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Payments_PaymentId",
                table: "Order",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Payments_PaymentId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_PaymentId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "IsPaid",
                table: "Order",
                newName: "IsCancel");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 21, 14, 51, 7, 280, DateTimeKind.Utc).AddTicks(9564), new DateTime(2025, 1, 21, 14, 51, 7, 280, DateTimeKind.Utc).AddTicks(9565) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 21, 14, 51, 7, 280, DateTimeKind.Utc).AddTicks(9568), new DateTime(2025, 1, 21, 14, 51, 7, 280, DateTimeKind.Utc).AddTicks(9569) });
        }
    }
}
