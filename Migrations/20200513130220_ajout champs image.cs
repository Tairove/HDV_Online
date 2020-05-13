using Microsoft.EntityFrameworkCore.Migrations;

namespace HDV_Online.Migrations
{
    public partial class ajoutchampsimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantite",
                table: "ProduitsCommandes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SourceImg",
                table: "Produits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceImg",
                table: "CategorieProduits",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantite",
                table: "ProduitsCommandes");

            migrationBuilder.DropColumn(
                name: "SourceImg",
                table: "Produits");

            migrationBuilder.DropColumn(
                name: "SourceImg",
                table: "CategorieProduits");
        }
    }
}
