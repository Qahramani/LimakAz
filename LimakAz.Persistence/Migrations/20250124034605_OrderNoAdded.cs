using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LimakAz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class OrderNoAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NO",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 24, 3, 46, 1, 284, DateTimeKind.Utc).AddTicks(2606), new DateTime(2025, 1, 24, 3, 46, 1, 284, DateTimeKind.Utc).AddTicks(2608) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 24, 3, 46, 1, 284, DateTimeKind.Utc).AddTicks(2613), new DateTime(2025, 1, 24, 3, 46, 1, 284, DateTimeKind.Utc).AddTicks(2614) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NO",
                table: "Order");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 23, 22, 17, 22, 83, DateTimeKind.Utc).AddTicks(4580), new DateTime(2025, 1, 23, 22, 17, 22, 83, DateTimeKind.Utc).AddTicks(4581) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 23, 22, 17, 22, 83, DateTimeKind.Utc).AddTicks(4584), new DateTime(2025, 1, 23, 22, 17, 22, 83, DateTimeKind.Utc).AddTicks(4585) });
        }
    }
}
