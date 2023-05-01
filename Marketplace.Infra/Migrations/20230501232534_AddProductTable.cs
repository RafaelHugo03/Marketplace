using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marketplace.Infra.Migrations
{
    public partial class AddProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "operation");

            migrationBuilder.CreateTable(
                name: "product",
                schema: "operation",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "varchar", maxLength: 500, nullable: true),
                    price = table.Column<decimal>(type: "decimal", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    user_seller_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_user_user_seller_id",
                        column: x => x.user_seller_id,
                        principalSchema: "security",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_user_seller_id",
                schema: "operation",
                table: "product",
                column: "user_seller_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product",
                schema: "operation");
        }
    }
}
