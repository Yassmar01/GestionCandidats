using Microsoft.EntityFrameworkCore.Migrations;

namespace CandidaturesEnligne.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mail = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Condidats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: false),
                    Prenom = table.Column<string>(nullable: false),
                    Mail = table.Column<string>(nullable: false),
                    Telephone = table.Column<string>(nullable: false),
                    NiveauDetude = table.Column<string>(nullable: false),
                    Experiance = table.Column<int>(nullable: false),
                    DernierEmployeur = table.Column<string>(nullable: false),
                    CVFilePath = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condidats", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Condidats");
        }
    }
}
