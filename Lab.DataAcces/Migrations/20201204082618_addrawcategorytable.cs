using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab.DataAccess.Migrations
{
    public partial class addrawcategorytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO tbl_category VALUES('Cat 1')");
            migrationBuilder.Sql("INSERT INTO tbl_category VALUES('Cat 2')");
            migrationBuilder.Sql("INSERT INTO tbl_category VALUES('Cat 3')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
