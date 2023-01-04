using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetAPI.Data.Migratons
{
    /// <inheritdoc />
    public partial class ProductAndCat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    IdCat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.IdCat);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameProduct = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descriptions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Sale = table.Column<byte>(type: "tinyint", nullable: false),
                    IdCat = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_IdCat",
                        column: x => x.IdCat,
                        principalTable: "Category",
                        principalColumn: "IdCat");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_IdCat",
                table: "Product",
                column: "IdCat");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
