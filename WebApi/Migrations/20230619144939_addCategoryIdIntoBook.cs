using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class addCategoryIdIntoBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Books",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "51c47178-a8a7-44f4-b804-df43b1cde4a3", "28ec3cd1-4819-43d8-8466-34894e186e42", "Admin", "ADMIN" },
                    { "b38f897e-7ee8-4d24-aeaf-dfa214ad6728", "d8529da4-0693-48fb-8fa9-d148ea43b153", "Editor", "EDITOR" },
                    { "e5c3d46b-8de6-4dc1-a491-d7bdcbe23c01", "da33bd95-d3da-46af-bba3-a9d25f291b1a", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51c47178-a8a7-44f4-b804-df43b1cde4a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b38f897e-7ee8-4d24-aeaf-dfa214ad6728");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5c3d46b-8de6-4dc1-a491-d7bdcbe23c01");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Books");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27a504d4-6f6f-40d5-ac58-cbc07f19da96", "276e85dc-a19c-4ea5-952d-0b44a6267575", "Admin", "ADMIN" },
                    { "2daaa871-9957-44f9-9fb9-e56b4c948b91", "383a2caa-b134-4c2c-8a98-ff759c7cee5c", "Editor", "EDITOR" },
                    { "e6fd0271-7920-40d0-a286-a6185114fce7", "0d23266e-492f-48d7-b008-ea73c3e04d08", "User", "USER" }
                });
        }
    }
}
