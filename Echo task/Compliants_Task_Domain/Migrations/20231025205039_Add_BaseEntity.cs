using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Compliants_Task_Domain.Migrations
{
    public partial class Add_BaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b208f0ab-3d22-4de5-9c54-eaf0190948ae");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Demands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Demands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifyBy",
                table: "Demands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyOn",
                table: "Demands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Complaints",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Complaints",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifyBy",
                table: "Complaints",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyOn",
                table: "Complaints",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4aa3cd32-c940-44a3-a292-c6004037d5b1");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Demands");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Demands");

            migrationBuilder.DropColumn(
                name: "ModifyBy",
                table: "Demands");

            migrationBuilder.DropColumn(
                name: "ModifyOn",
                table: "Demands");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "ModifyBy",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "ModifyOn",
                table: "Complaints");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad376a8f",
                column: "ConcurrencyStamp",
                value: "dd86db56-8e77-4983-8baf-341b1ba1fdd6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b208f0ab-3d22-4de5-9c54-eaf0190948ae", "fdc42937-30e6-4024-b9d0-625234f15ee9", "User", "User" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a43b76b0-95d3-4ecc-8d1b-440f9541f983", "AQAAAAEAACcQAAAAEGaB6WxCx+tmFt0rZUUSuBETvZB3ALtpoWevuh1OR9xUNKtVcmMzOTgRxzDQ7HCigw==" });
        }
    }
}
