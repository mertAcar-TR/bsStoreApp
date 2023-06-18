using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class AddRolesToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
