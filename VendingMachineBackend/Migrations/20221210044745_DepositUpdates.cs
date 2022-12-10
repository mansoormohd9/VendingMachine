using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendingMachineBackend.Migrations
{
    public partial class DepositUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deposits_AspNetUsers_UserId1",
                table: "Deposits");

            migrationBuilder.DropIndex(
                name: "IX_Deposits_UserId1",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Deposits");

            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "Deposits",
                newName: "Amount");

            migrationBuilder.CreateTable(
                name: "UserDeposits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepositId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDeposits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDeposits_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserDeposits_Deposits_DepositId",
                        column: x => x.DepositId,
                        principalTable: "Deposits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75a9f6c2-b188-4d7f-b752-9c72fe5e44e7",
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "5e01bd2d-af91-4799-97c5-d0ebffde2016", "ADMIN@TEST.COM", true, "ADMIN@TEST.COM", "ADMIN@TEST.COM", "AQAAAAEAACcQAAAAEIUb+29SiLKqLgqQ8eBBc4kq7HAE4z+OY3R8XWdH5Mg5JIg4c3ZG1w3hf9Xz1/0+xg==", null, "a2cb9be6-90b2-42a8-a48d-5fbeeebe9c46", "ADMIN@TEST.COM" });

            migrationBuilder.CreateIndex(
                name: "IX_UserDeposits_DepositId",
                table: "UserDeposits",
                column: "DepositId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDeposits_UserId1",
                table: "UserDeposits",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDeposits");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Deposits",
                newName: "Balance");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Deposits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Deposits",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75a9f6c2-b188-4d7f-b752-9c72fe5e44e7",
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "8757d34e-b80f-4201-8133-7e90801bdac0", "admin@test.com", false, null, null, null, "1234567890", "c48a67ff-b023-449b-9227-6a6787e1b83a", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Deposits_UserId1",
                table: "Deposits",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Deposits_AspNetUsers_UserId1",
                table: "Deposits",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
