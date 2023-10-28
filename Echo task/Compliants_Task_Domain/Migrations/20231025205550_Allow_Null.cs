using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Compliants_Task_Domain.Migrations
{
    public partial class Allow_Null : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4aa3cd32-c940-44a3-a292-c6004037d5b1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad376a8f",
                column: "ConcurrencyStamp",
                value: "55228ae0-d0ed-440b-ab53-36de3d878fae");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6fa1fcee-1389-4ca9-b593-426db1006fe5", "80e06332-e7af-4779-842f-95df2d28a7bb", "User", "User" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e9b68636-5eb0-4737-af57-6c34dbb5eec6", "AQAAAAEAACcQAAAAEM1DDmgT/IJYm9CBGlNwP9lPZYJiLlxvoNXQgEy3uE0xi3IeNCJjoAAoICcNbo2hcw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6fa1fcee-1389-4ca9-b593-426db1006fe5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad376a8f",
                column: "ConcurrencyStamp",
                value: "3daadb5e-aee5-4791-b092-222390f6dff3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4aa3cd32-c940-44a3-a292-c6004037d5b1", "b8ca880c-ad49-408e-9d5b-17e23275d828", "User", "User" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6ce5f24e-6455-4ebb-bf89-6bd544490879", "AQAAAAEAACcQAAAAEEn2DE3qdJ0ul8QcitNUlAp0NA2oeARJvxi/FhJS5QLtXXVnTTTahA8N0LkORtVR+g==" });
        }
    }
}
