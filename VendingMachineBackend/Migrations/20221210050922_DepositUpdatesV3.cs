using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendingMachineBackend.Migrations
{
    public partial class DepositUpdatesV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDeposits_AspNetUsers_UserId1",
                table: "UserDeposits");

            migrationBuilder.DropIndex(
                name: "IX_UserDeposits_UserId1",
                table: "UserDeposits");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserDeposits");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserDeposits",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "Products",
                type: "decimal(18,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Deposits",
                type: "decimal(18,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75a9f6c2-b188-4d7f-b752-9c72fe5e44e7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50203f54-0f97-4f20-b039-07082aabfb95", "AQAAAAEAACcQAAAAEGeGjcDCu8FKNGhB/yfmzm/ixztecosUmDuHRkQZWH9nIUkxZPp8g6ZFgfKcpmBvEw==", "8b71535e-015a-42a1-aec3-c7c7fabaed72" });

            migrationBuilder.CreateIndex(
                name: "IX_UserDeposits_UserId",
                table: "UserDeposits",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deposits_Amount",
                table: "Deposits",
                column: "Amount",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDeposits_AspNetUsers_UserId",
                table: "UserDeposits",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDeposits_AspNetUsers_UserId",
                table: "UserDeposits");

            migrationBuilder.DropIndex(
                name: "IX_UserDeposits_UserId",
                table: "UserDeposits");

            migrationBuilder.DropIndex(
                name: "IX_Products_Name",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Deposits_Amount",
                table: "Deposits");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "UserDeposits",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserDeposits",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Deposits",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75a9f6c2-b188-4d7f-b752-9c72fe5e44e7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aca2b087-f57d-4f52-86f9-b7e34116e9f5", "AQAAAAEAACcQAAAAEHNd/W4W7+/nPBZ1GYLBDkdStsGsaMjJnZ8VI0UnQatPdBksGp8d5QqwxJ/uHCQkew==", "2a8fd2f4-63b0-4ae4-aeca-58f4c40fc58b" });

            migrationBuilder.CreateIndex(
                name: "IX_UserDeposits_UserId1",
                table: "UserDeposits",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDeposits_AspNetUsers_UserId1",
                table: "UserDeposits",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
