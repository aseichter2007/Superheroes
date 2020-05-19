using Microsoft.EntityFrameworkCore.Migrations;

namespace Superheroes.Data.Migrations
{
    public partial class AddImageUrls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IMGurl",
                table: "heroes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IMGurl",
                table: "heroes");
        }
    }
}
