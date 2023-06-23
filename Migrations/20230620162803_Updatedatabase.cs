using Microsoft.EntityFrameworkCore.Migrations;

namespace CandidaturesEnligne.Migrations
{
    public partial class Updatedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVFilePath",
                table: "Condidats");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CVFilePath",
                table: "Condidats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
