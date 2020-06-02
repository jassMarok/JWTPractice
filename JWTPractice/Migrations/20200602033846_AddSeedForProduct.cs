using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JWTPractice.Migrations
{
    public partial class AddSeedForProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "AvailableQuantity", "Category", "Color", "Name", "UnitPrice" },
                values: new object[] { 1, 20, "Toys", "Red", "Avenger", 22.40m });

            migrationBuilder.UpdateData(
                table: "UserInfo",
                keyColumn: "UserInfoId",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2020, 6, 1, 23, 38, 45, 793, DateTimeKind.Local).AddTicks(9040));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "UserInfo",
                keyColumn: "UserInfoId",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2020, 6, 1, 22, 59, 47, 795, DateTimeKind.Local).AddTicks(863));
        }
    }
}
