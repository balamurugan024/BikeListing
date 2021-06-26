using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeListing.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Showrroom",
                table: "Bikes",
                newName: "Showroom");

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name", "SCode" },
                values: new object[] { 1, "Bajaj", "BAJ" });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name", "SCode" },
                values: new object[] { 2, "Hero", "HER" });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name", "SCode" },
                values: new object[] { 3, "HONDA", "HON" });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "BrandId", "Name", "Rating", "Showroom" },
                values: new object[,]
                {
                    { 1, 1, "Pulsar 150", 4.2999999999999998, "Dindigul" },
                    { 3, 1, "Pulsar NS200", 3.7000000000000002, "Trichy" },
                    { 4, 2, "Xpulse 200T", 3.7000000000000002, "Madurai" },
                    { 2, 3, "Hornet 2.0", 4.5, "Dindigul" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "Showroom",
                table: "Bikes",
                newName: "Showrroom");
        }
    }
}
