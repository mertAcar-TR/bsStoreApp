using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class ChangeUserRefreshTokenExpireTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ed3aa0d-5d2e-4a2f-ac7e-24941ae9f176");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86ea4550-84ae-4a0a-aef1-863c0f55855b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "daec0076-c817-4210-9bad-1c2868706665");

            migrationBuilder.AlterColumn<string>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b12438a7-fced-46fe-bdee-87c75ba4aaf5", "a5fc7277-a8ee-4cf4-a35c-9635390fb7f1", "User", "USER" },
                    { "d5d197c0-2f1d-4959-ac64-0addae0906ec", "07e3c3f1-13ee-4a1d-aa81-b57149629e66", "Admin", "ADMIN" },
                    { "f8eb4342-0e36-471a-8aa8-a4d95818009d", "a372a4e7-e531-4789-a4a8-eb5ab61b4bb1", "Editor", "EDITOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b12438a7-fced-46fe-bdee-87c75ba4aaf5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5d197c0-2f1d-4959-ac64-0addae0906ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8eb4342-0e36-471a-8aa8-a4d95818009d");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ed3aa0d-5d2e-4a2f-ac7e-24941ae9f176", "4f8dbf3a-acdb-4fe9-9d95-66b1e2fea63d", "User", "USER" },
                    { "86ea4550-84ae-4a0a-aef1-863c0f55855b", "34f412e6-5286-4b18-9cdf-5cc9579c24c0", "Editor", "EDITOR" },
                    { "daec0076-c817-4210-9bad-1c2868706665", "d9a4b3af-8835-4b78-aa92-63e5e66df523", "Admin", "ADMIN" }
                });
        }
    }
}
