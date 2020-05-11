using Microsoft.EntityFrameworkCore.Migrations;

namespace HDV_Online.Migrations
{
    public partial class FKCategorieProduit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produits_CategorieProduits_CategorieProduitId",
                table: "Produits");

            migrationBuilder.DropIndex(
                name: "IX_Produits_CategorieProduitId",
                table: "Produits");

            migrationBuilder.DropColumn(
                name: "CategorieProduitId",
                table: "Produits");

            migrationBuilder.AddColumn<int>(
                name: "IdCategorieProduit",
                table: "Produits",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Produits_IdCategorieProduit",
                table: "Produits",
                column: "IdCategorieProduit");

            migrationBuilder.AddForeignKey(
                name: "FK_Produits_CategorieProduits_IdCategorieProduit",
                table: "Produits",
                column: "IdCategorieProduit",
                principalTable: "CategorieProduits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produits_CategorieProduits_IdCategorieProduit",
                table: "Produits");

            migrationBuilder.DropIndex(
                name: "IX_Produits_IdCategorieProduit",
                table: "Produits");

            migrationBuilder.DropColumn(
                name: "IdCategorieProduit",
                table: "Produits");

            migrationBuilder.AddColumn<int>(
                name: "CategorieProduitId",
                table: "Produits",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produits_CategorieProduitId",
                table: "Produits",
                column: "CategorieProduitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produits_CategorieProduits_CategorieProduitId",
                table: "Produits",
                column: "CategorieProduitId",
                principalTable: "CategorieProduits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
