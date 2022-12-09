using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendingMachineBackend.Migrations
{
    public partial class UpdateRoleV4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRoles",
                keyColumn: "Id",
                keyValue: "1838baff-6b99-492b-a3d5-192f62111f23");

            migrationBuilder.DeleteData(
                table: "IdentityRoles",
                keyColumn: "Id",
                keyValue: "53d87119-b91e-478a-a3ec-1b3c5527ef66");

            migrationBuilder.DeleteData(
                table: "IdentityRoles",
                keyColumn: "Id",
                keyValue: "e79dec1e-dc16-46f9-9be2-094d24e986a7");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "75a9f6c2-b188-4d7f-b752-9c72fe5e44e7", 0, "8757d34e-b80f-4201-8133-7e90801bdac0", "admin@test.com", false, null, null, false, null, null, null, null, "1234567890", false, "c48a67ff-b023-449b-9227-6a6787e1b83a", false, "Admin" });

            migrationBuilder.InsertData(
                table: "IdentityRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20b54706-1be9-473d-8a83-2cf57418e2c6", "3", "BUYER", "BUYER" },
                    { "83d8c9d4-610c-40c7-b26c-d0f23d708ee6", "1", "ADMIN", "ADMIN" },
                    { "973c8158-4ca1-48e1-a1c9-5fcd4630cc41", "2", "SELLER", "SELLER" }
                });

            migrationBuilder.InsertData(
                table: "IdentityUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "83d8c9d4-610c-40c7-b26c-d0f23d708ee6", "75a9f6c2-b188-4d7f-b752-9c72fe5e44e7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75a9f6c2-b188-4d7f-b752-9c72fe5e44e7");

            migrationBuilder.DeleteData(
                table: "IdentityRoles",
                keyColumn: "Id",
                keyValue: "20b54706-1be9-473d-8a83-2cf57418e2c6");

            migrationBuilder.DeleteData(
                table: "IdentityRoles",
                keyColumn: "Id",
                keyValue: "83d8c9d4-610c-40c7-b26c-d0f23d708ee6");

            migrationBuilder.DeleteData(
                table: "IdentityRoles",
                keyColumn: "Id",
                keyValue: "973c8158-4ca1-48e1-a1c9-5fcd4630cc41");

            migrationBuilder.DeleteData(
                table: "IdentityUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "83d8c9d4-610c-40c7-b26c-d0f23d708ee6", "75a9f6c2-b188-4d7f-b752-9c72fe5e44e7" });

            migrationBuilder.InsertData(
                table: "IdentityRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1838baff-6b99-492b-a3d5-192f62111f23", "2c343e5e-73bc-44ea-892e-9f1c2cc12ec8", "SELLER", "SELLER" });

            migrationBuilder.InsertData(
                table: "IdentityRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "53d87119-b91e-478a-a3ec-1b3c5527ef66", "48425a7d-404c-41ac-8c81-73961b4adabe", "BUYER", "BUYER" });

            migrationBuilder.InsertData(
                table: "IdentityRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e79dec1e-dc16-46f9-9be2-094d24e986a7", "fef22602-abd8-403b-b3f8-ed6f94afee2a", "ADMIN", "ADMIN" });
        }
    }
}
