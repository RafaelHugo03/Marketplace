using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marketplace.Infra.Migrations
{
    public partial class MigrationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "operation");

            migrationBuilder.EnsureSchema(
                name: "security");

            migrationBuilder.CreateTable(
                name: "user",
                schema: "security",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    email_address = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    birth_date = table.Column<DateTime>(type: "date", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    is_valid_email = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "order",
                schema: "operation",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    total_price = table.Column<float>(type: "real", nullable: false),
                    order_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    user_buyer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    status = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_user_user_buyer_id",
                        column: x => x.user_buyer_id,
                        principalSchema: "security",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "order_item",
                schema: "operation",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    order_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    quantity = table.Column<int>(type: "int4", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_item_order_order_id",
                        column: x => x.order_id,
                        principalSchema: "operation",
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_item_product_product_id",
                        column: x => x.product_id,
                        principalSchema: "operation",
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_order_user_buyer_id",
                schema: "operation",
                table: "order",
                column: "user_buyer_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_item_order_id",
                schema: "operation",
                table: "order_item",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_item_product_id",
                schema: "operation",
                table: "order_item",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_user_seller_id",
                schema: "operation",
                table: "product",
                column: "user_seller_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_item",
                schema: "operation");

            migrationBuilder.DropTable(
                name: "order",
                schema: "operation");

            migrationBuilder.DropTable(
                name: "product",
                schema: "operation");

            migrationBuilder.DropTable(
                name: "user",
                schema: "security");
        }
    }
}
