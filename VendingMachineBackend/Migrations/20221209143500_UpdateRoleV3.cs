using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendingMachineBackend.Migrations
{
    public partial class UpdateRoleV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "IdentityUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRoles", x => new { x.UserId, x.RoleId });
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityUserRoles");

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
    }
}
