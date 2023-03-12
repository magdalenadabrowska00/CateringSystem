using Microsoft.EntityFrameworkCore.Migrations;

namespace CateringSystem.Migrations
{
    public partial class AddRestaurantIdToMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Menus",
                type: "int",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Menus",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MealAssessment",
                table: "MenuMeals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Menus");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Menus",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<int>(
                name: "MealAssessment",
                table: "MenuMeals",
                type: "int",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
