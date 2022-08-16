using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HistoAppV2.Data.Migrations
{
    public partial class MultiSelectMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LevelsId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "Orders",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LevelsId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "Orders");
        }
    }
}
