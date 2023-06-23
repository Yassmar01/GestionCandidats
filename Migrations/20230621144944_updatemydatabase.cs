using Microsoft.EntityFrameworkCore.Migrations;

namespace CandidaturesEnligne.Migrations
{
    public partial class updatemydatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CvPath",
                table: "Condidats",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CvPath",
                table: "Condidats");
        }
    }
}
