using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImportBackend.Migrations
{
    public partial class Providers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "DJANGO_CLIENT");

            /*migrationBuilder.CreateTable(
                name: "IMPORT_ORDERS",
                schema: "DJANGO_CLIENT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UserId = table.Column<int>(type: "INT", nullable: false),
                    ProductId = table.Column<int>(type: "INT", nullable: false),
                    ProviderId = table.Column<int>(type: "INT", nullable: false),
                    Quantity = table.Column<int>(type: "INT", nullable: false),
                    Individualprice = table.Column<decimal>(type: "DECIMAL(18,4)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(4000)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMPORT_ORDERS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_CATEGORY",
                schema: "DJANGO_CLIENT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_CATEGORY", x => x.Id);
                });*/

            migrationBuilder.CreateTable(
                name: "PROVIDERS",
                schema: "DJANGO_CLIENT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "INT", nullable: false),
                    Country = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROVIDERS", x => x.Id);
                });

            /*migrationBuilder.CreateTable(
                name: "USERS",
                schema: "DJANGO_CLIENT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    GivenName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    LastName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UserName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                schema: "DJANGO_CLIENT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    ProductCategoryId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Image = table.Column<byte[]>(type: "BLOB", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategory",
                        column: x => x.ProductCategoryId,
                        principalSchema: "DJANGO_CLIENT",
                        principalTable: "PRODUCT_CATEGORY",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_ProductCategoryId",
                schema: "DJANGO_CLIENT",
                table: "PRODUCTS",
                column: "ProductCategoryId");*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropTable(
                name: "IMPORT_ORDERS",
                schema: "DJANGO_CLIENT");

            migrationBuilder.DropTable(
                name: "PRODUCTS",
                schema: "DJANGO_CLIENT");*/

            migrationBuilder.DropTable(
                name: "PROVIDERS",
                schema: "DJANGO_CLIENT");

            /*migrationBuilder.DropTable(
                name: "USERS",
                schema: "DJANGO_CLIENT");

            migrationBuilder.DropTable(
                name: "PRODUCT_CATEGORY",
                schema: "DJANGO_CLIENT");*/
        }
    }
}
