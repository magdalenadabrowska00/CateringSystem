using Microsoft.EntityFrameworkCore.Migrations;

namespace CateringSystem.Migrations
{
    public partial class ChangeRelationBetweenOrdersAndMenus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Orders_OrderId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_OrderId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Menus");

            migrationBuilder.CreateTable(
                name: "OrdersMenus",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersMenus", x => new { x.MenuId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_OrdersMenus_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersMenus_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdersMenus_OrderId",
                table: "OrdersMenus",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdersMenus");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Menus",
                type: "int",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_OrderId",
                table: "Menus",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Orders_OrderId",
                table: "Menus",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
