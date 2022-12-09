using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendingMachineBackend.Migrations
{
    public partial class UpdateRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRoles",
                keyColumn: "Id",
                keyValue: "0094ddca-b0ae-4b79-9e61-e41519e4d889");

            migrationBuilder.DeleteData(
                table: "IdentityRoles",
                keyColumn: "Id",
                keyValue: "93e2f176-20a2-4979-ace9-89cabb89fc37");

            migrationBuilder.DeleteData(
                table: "IdentityRoles",
                keyColumn: "Id",
                keyValue: "c6bd4543-b3a9-4f20-aae3-141b9ec347ce");

            migrationBuilder.InsertData(
                table: "IdentityRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "04b66156-d20f-424f-ab05-bd6278e22862", "6d41bad8-b8b1-4f86-b1a5-5c418d149029", "SELLER", null });

            migrationBuilder.InsertData(
                table: "IdentityRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5ea9d517-b42e-4d29-a512-bf2f8853aa26", "2ce74e82-3cba-45ca-b846-67a756b9d99e", "BUYER", null });

            migrationBuilder.InsertData(
                table: "IdentityRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9c586a06-83d1-4dc5-8189-324196bd38d2", "df489252-d9a8-432d-b434-156ec1e004cb", "ADMIN", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRoles",
                keyColumn: "Id",
                keyValue: "04b66156-d20f-424f-ab05-bd6278e22862");

            migrationBuilder.DeleteData(
                table: "IdentityRoles",
                keyColumn: "Id",
                keyValue: "5ea9d517-b42e-4d29-a512-bf2f8853aa26");

            migrationBuilder.DeleteData(
                table: "IdentityRoles",
                keyColumn: "Id",
                keyValue: "9c586a06-83d1-4dc5-8189-324196bd38d2");

            migrationBuilder.InsertData(
                table: "IdentityRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0094ddca-b0ae-4b79-9e61-e41519e4d889", "183fb10c-53d1-477b-a875-38c1173bd096", "Buyer", null });

            migrationBuilder.InsertData(
                table: "IdentityRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "93e2f176-20a2-4979-ace9-89cabb89fc37", "1eb5ecea-87dc-4884-90d1-ef51b5adeada", "Seller", null });

            migrationBuilder.InsertData(
                table: "IdentityRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c6bd4543-b3a9-4f20-aae3-141b9ec347ce", "d2fc2eed-0efb-4b52-aba3-d0791123cf5a", "Admin", null });
        }
    }
}
