using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourceProject.Data.Migrations
{
    public partial class AddCarId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1820b01c-98a7-4b97-bf90-89446888294f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7d9595a-a5e6-48b7-97f2-d8f9553dabd0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ac074c86-5788-427b-9b7d-f1361061ce1e", "ca995e21-f6aa-43ed-93a2-38dfff5c6ca1", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dc9da6d5-a4ac-4dd6-aeda-2843b4fad608", "6ce1d5f4-8674-4503-89fd-5e1e23c1712e", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac074c86-5788-427b-9b7d-f1361061ce1e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc9da6d5-a4ac-4dd6-aeda-2843b4fad608");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1820b01c-98a7-4b97-bf90-89446888294f", "1a82acd8-5715-4f7f-83fd-371d4d596408", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d7d9595a-a5e6-48b7-97f2-d8f9553dabd0", "ed3afb04-49c9-46dc-9d45-2bc0cc9b3ea7", "Admin", "ADMIN" });
        }
    }
}
