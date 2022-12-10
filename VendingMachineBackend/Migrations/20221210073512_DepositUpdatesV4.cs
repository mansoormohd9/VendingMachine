using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendingMachineBackend.Migrations
{
    public partial class DepositUpdatesV4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "UserDeposits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserBuy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceBoughtAt = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    BuyDate = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBuy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBuy_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75a9f6c2-b188-4d7f-b752-9c72fe5e44e7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44467acd-a292-4d9b-8bcc-29faf6802284", "AQAAAAEAACcQAAAAELdBBOFOwSUD5GpGQRQuzUWH6Uapm7zabPjyeOqtuDyOSN4wowCWEk5+6muTLjw72Q==", "e47e5bd6-4159-4b68-9498-27f851865940" });

            migrationBuilder.InsertData(
                table: "Deposits",
                columns: new[] { "Id", "Amount" },
                values: new object[,]
                {
                    { 1, 5m },
                    { 2, 10m },
                    { 3, 20m },
                    { 4, 50m },
                    { 5, 100m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBuy_ProductId",
                table: "UserBuy",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBuy");

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "UserDeposits");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75a9f6c2-b188-4d7f-b752-9c72fe5e44e7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50203f54-0f97-4f20-b039-07082aabfb95", "AQAAAAEAACcQAAAAEGeGjcDCu8FKNGhB/yfmzm/ixztecosUmDuHRkQZWH9nIUkxZPp8g6ZFgfKcpmBvEw==", "8b71535e-015a-42a1-aec3-c7c7fabaed72" });
        }
    }
}
