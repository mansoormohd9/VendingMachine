using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendingMachineBackend.Migrations
{
    public partial class DepositUpdatesV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75a9f6c2-b188-4d7f-b752-9c72fe5e44e7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aca2b087-f57d-4f52-86f9-b7e34116e9f5", "AQAAAAEAACcQAAAAEHNd/W4W7+/nPBZ1GYLBDkdStsGsaMjJnZ8VI0UnQatPdBksGp8d5QqwxJ/uHCQkew==", "2a8fd2f4-63b0-4ae4-aeca-58f4c40fc58b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75a9f6c2-b188-4d7f-b752-9c72fe5e44e7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e01bd2d-af91-4799-97c5-d0ebffde2016", "AQAAAAEAACcQAAAAEIUb+29SiLKqLgqQ8eBBc4kq7HAE4z+OY3R8XWdH5Mg5JIg4c3ZG1w3hf9Xz1/0+xg==", "a2cb9be6-90b2-42a8-a48d-5fbeeebe9c46" });
        }
    }
}
