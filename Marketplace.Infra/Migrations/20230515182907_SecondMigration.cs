using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marketplace.Infra.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "category_id",
                schema: "operation",
                table: "product",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "category",
                schema: "operation",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_category_id",
                schema: "operation",
                table: "product",
                column: "category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_category_category_id",
                schema: "operation",
                table: "product",
                column: "category_id",
                principalSchema: "operation",
                principalTable: "category",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_category_category_id",
                schema: "operation",
                table: "product");

            migrationBuilder.DropTable(
                name: "category",
                schema: "operation");

            migrationBuilder.DropIndex(
                name: "IX_product_category_id",
                schema: "operation",
                table: "product");

            migrationBuilder.DropColumn(
                name: "category_id",
                schema: "operation",
                table: "product");
        }
    }
}
