using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourceProject.Data.Migrations
{
    public partial class AddUserToComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac074c86-5788-427b-9b7d-f1361061ce1e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc9da6d5-a4ac-4dd6-aeda-2843b4fad608");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Comments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "90062e10-8a3e-461b-9e43-95db66e3ea21", "9fc6d5df-f3f9-4dbb-a705-1bf0d5538916", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "96df4dc4-dbcd-4d00-bdef-3285892207a7", "f001ca6e-56fb-4c86-abd8-a74b7979b0d9", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90062e10-8a3e-461b-9e43-95db66e3ea21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96df4dc4-dbcd-4d00-bdef-3285892207a7");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Comments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ac074c86-5788-427b-9b7d-f1361061ce1e", "ca995e21-f6aa-43ed-93a2-38dfff5c6ca1", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dc9da6d5-a4ac-4dd6-aeda-2843b4fad608", "6ce1d5f4-8674-4503-89fd-5e1e23c1712e", "Admin", "ADMIN" });
        }
    }
}
