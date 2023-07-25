using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourceProject.Data.Migrations
{
    public partial class AddManufacturer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba68bb89-7b4f-4b5a-bb59-d3607ddb7630");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf94e6db-05a6-47b9-a3c6-3caad82095f2");

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "FavouritesCars",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1820b01c-98a7-4b97-bf90-89446888294f", "1a82acd8-5715-4f7f-83fd-371d4d596408", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d7d9595a-a5e6-48b7-97f2-d8f9553dabd0", "ed3afb04-49c9-46dc-9d45-2bc0cc9b3ea7", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1820b01c-98a7-4b97-bf90-89446888294f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7d9595a-a5e6-48b7-97f2-d8f9553dabd0");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "FavouritesCars");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ba68bb89-7b4f-4b5a-bb59-d3607ddb7630", "0e9c491d-25d4-4aa4-a952-5ba881c54d7b", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bf94e6db-05a6-47b9-a3c6-3caad82095f2", "204cbe9d-198b-4146-8def-cb9f96b3f772", "Admin", "ADMIN" });
        }
    }
}
