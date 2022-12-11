using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendingMachineBackend.Migrations
{
    public partial class ProductMOdelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75a9f6c2-b188-4d7f-b752-9c72fe5e44e7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "404daff3-2a7a-4c4e-97e4-28f4bf41664e", "AQAAAAEAACcQAAAAED1Wr9RcpG4QQ+RRvxw3gXID9KMxtntVzno6XTN6KPmvIsYIcDEWDYHn56SJ525y/Q==", "2117f37f-f539-4f60-a825-c2f37b9e617f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75a9f6c2-b188-4d7f-b752-9c72fe5e44e7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44467acd-a292-4d9b-8bcc-29faf6802284", "AQAAAAEAACcQAAAAELdBBOFOwSUD5GpGQRQuzUWH6Uapm7zabPjyeOqtuDyOSN4wowCWEk5+6muTLjw72Q==", "e47e5bd6-4159-4b68-9498-27f851865940" });
        }
    }
}
