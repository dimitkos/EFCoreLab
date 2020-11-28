using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab.DataAccess.Migrations
{
    public partial class Adddisplaypropertytogenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DispalayOrder",
                table: "Genres",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DispalayOrder",
                table: "Genres");
        }
    }
}
