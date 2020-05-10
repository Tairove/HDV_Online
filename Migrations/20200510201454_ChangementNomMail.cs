using Microsoft.EntityFrameworkCore.Migrations;

namespace HDV_Online.Migrations
{
    public partial class ChangementNomMail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailUtilisateur",
                table: "Utilisateur");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Utilisateur",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Utilisateur");

            migrationBuilder.AddColumn<string>(
                name: "EmailUtilisateur",
                table: "Utilisateur",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
