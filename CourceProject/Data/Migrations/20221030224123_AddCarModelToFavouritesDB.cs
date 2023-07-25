using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourceProject.Data.Migrations
{
    public partial class AddCarModelToFavouritesDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9625ba34-f5cd-4501-8be5-1c4a4c1e1ef4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d682cfdd-42f6-4862-a903-dfd52168b04e");

            migrationBuilder.AddColumn<string>(
                name: "CarModel",
                table: "FavouritesCars",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EngineDisplacement",
                table: "Cars",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ba68bb89-7b4f-4b5a-bb59-d3607ddb7630", "0e9c491d-25d4-4aa4-a952-5ba881c54d7b", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bf94e6db-05a6-47b9-a3c6-3caad82095f2", "204cbe9d-198b-4146-8def-cb9f96b3f772", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba68bb89-7b4f-4b5a-bb59-d3607ddb7630");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf94e6db-05a6-47b9-a3c6-3caad82095f2");

            migrationBuilder.DropColumn(
                name: "CarModel",
                table: "FavouritesCars");

            migrationBuilder.AlterColumn<double>(
                name: "EngineDisplacement",
                table: "Cars",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9625ba34-f5cd-4501-8be5-1c4a4c1e1ef4", "6a0dd9e2-7912-4497-a717-9e0fa463298a", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d682cfdd-42f6-4862-a903-dfd52168b04e", "8a4b51ea-fb26-4d1c-8d5c-80d30093a732", "Admin", "ADMIN" });
        }
    }
}
