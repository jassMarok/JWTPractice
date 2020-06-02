using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JWTPractice.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    AvailableQuantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    UserInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.UserInfoId);
                });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "UserInfoId", "CreatedDateTime", "Email", "FirstName", "LastName", "Password", "UserName" },
                values: new object[] { 1, new DateTime(2020, 6, 1, 22, 59, 47, 795, DateTimeKind.Local).AddTicks(863), "admin@root.com", "root", "admin", "Secret1$", "rootAdmin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
