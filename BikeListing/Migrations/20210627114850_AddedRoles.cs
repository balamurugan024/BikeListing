using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeListing.Migrations
{
    public partial class AddedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6b51319d-e2ea-4bfe-bf6c-6839f7acfe33", "6f64e11c-9f4c-425f-a00f-8f25f4102ab2", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0c40ab40-e96a-4c82-8109-88c735d9bfe1", "f795f291-31ea-4217-b041-33409c767b34", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c40ab40-e96a-4c82-8109-88c735d9bfe1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b51319d-e2ea-4bfe-bf6c-6839f7acfe33");
        }
    }
}
