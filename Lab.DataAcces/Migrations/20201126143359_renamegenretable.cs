using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab.DataAccess.Migrations
{
    public partial class renamegenretable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "tb_genre");

            migrationBuilder.RenameColumn(
                name: "GenreName",
                table: "tb_genre",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_genre",
                table: "tb_genre",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_genre",
                table: "tb_genre");

            migrationBuilder.RenameTable(
                name: "tb_genre",
                newName: "Genres");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Genres",
                newName: "GenreName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "GenreId");
        }
    }
}
