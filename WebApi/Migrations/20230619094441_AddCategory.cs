using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApi.Migrations
{
    public partial class AddCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27a504d4-6f6f-40d5-ac58-cbc07f19da96", "276e85dc-a19c-4ea5-952d-0b44a6267575", "Admin", "ADMIN" },
                    { "2daaa871-9957-44f9-9fb9-e56b4c948b91", "383a2caa-b134-4c2c-8a98-ff759c7cee5c", "Editor", "EDITOR" },
                    { "e6fd0271-7920-40d0-a286-a6185114fce7", "0d23266e-492f-48d7-b008-ea73c3e04d08", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Computer Science" },
                    { 2, "Network" },
                    { 3, "Database System Managment" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27a504d4-6f6f-40d5-ac58-cbc07f19da96");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2daaa871-9957-44f9-9fb9-e56b4c948b91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fd0271-7920-40d0-a286-a6185114fce7");

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
    }
}
