using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourceProject.Data.Migrations
{
    public partial class PublicId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "327013b4-719d-44e3-bef4-02c2ff89b350");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a916d13f-4850-4a44-bcfa-49648b531fe0");

            migrationBuilder.RenameColumn(
                name: "QuantityInCourntry",
                table: "Cars",
                newName: "QuantityInCountry");

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Cars",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Cars",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "405b43ab-65e6-4c56-a6e1-e37e3ebc6f77", "7102408d-6948-4adc-9f49-7a2d76c24811", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "db34e0e8-25b8-4934-8214-13afcfece11f", "a0736bda-a3ab-4e39-b828-6d242502215a", "Member", "MEMBER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "405b43ab-65e6-4c56-a6e1-e37e3ebc6f77");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db34e0e8-25b8-4934-8214-13afcfece11f");

            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "QuantityInCountry",
                table: "Cars",
                newName: "QuantityInCourntry");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "327013b4-719d-44e3-bef4-02c2ff89b350", "4949b0d8-6d96-486d-88aa-1078427ecef9", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a916d13f-4850-4a44-bcfa-49648b531fe0", "0399c41e-54de-4b4b-bb13-6f1f609aac18", "Admin", "ADMIN" });
        }
    }
}
