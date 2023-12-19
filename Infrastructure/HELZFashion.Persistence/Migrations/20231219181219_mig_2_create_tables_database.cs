using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HELZFashion.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2_create_tables_database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Brands_BrandId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_BrandId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ColorType",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SizeType",
                table: "Categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BrandId",
                table: "Categories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "ColorType",
                table: "Categories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentMethod",
                table: "Categories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Categories",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SizeType",
                table: "Categories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_BrandId",
                table: "Categories",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Brands_BrandId",
                table: "Categories",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
