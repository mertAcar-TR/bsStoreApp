using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class AddRefreshTokenFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "502dd2bc-33f3-4ee3-9789-3d8913b1edf8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ba9f0cd-b476-4a93-9b66-44439f6e4df7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8c3aa41-b32b-42e9-bea2-8d0280b01f88");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "502dd2bc-33f3-4ee3-9789-3d8913b1edf8", "e336c322-8450-4762-86fd-c19d582c40be", "Admin", "ADMIN" },
                    { "6ba9f0cd-b476-4a93-9b66-44439f6e4df7", "98867ab0-372a-44e1-8e1c-fe9c522c1ded", "User", "USER" },
                    { "a8c3aa41-b32b-42e9-bea2-8d0280b01f88", "73125fe6-37a3-49f8-a2cd-b579c42e050d", "Editor", "EDITOR" }
                });
        }
    }
}
