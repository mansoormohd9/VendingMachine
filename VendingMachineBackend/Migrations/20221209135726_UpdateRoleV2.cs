using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendingMachineBackend.Migrations
{
    public partial class UpdateRoleV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "031f6523-1553-4708-b8e3-71617163d5e0", "a8df27ca-c751-4042-bbb3-f0640dd03b6b", "BUYER", "BUYER" });

            migrationBuilder.InsertData(
                table: "IdentityRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0eb154fb-242a-4bd4-b882-09f3af81d634", "59a8397c-2748-47e2-857c-74205527b9f5", "ADMIN", "ADMIN" });

            migrationBuilder.InsertData(
                table: "IdentityRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "33d5d7b4-2ff3-4fe3-be7f-871b7b3be082", "c584b870-3361-491f-92ef-0fb88f102b50", "SELLER", "SELLER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRoles",
                keyColumn: "Id",
                keyValue: "031f6523-1553-4708-b8e3-71617163d5e0");

            migrationBuilder.DeleteData(
                table: "IdentityRoles",
                keyColumn: "Id",
                keyValue: "0eb154fb-242a-4bd4-b882-09f3af81d634");

            migrationBuilder.DeleteData(
                table: "IdentityRoles",
                keyColumn: "Id",
                keyValue: "33d5d7b4-2ff3-4fe3-be7f-871b7b3be082");

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
    }
}
