using Microsoft.EntityFrameworkCore.Migrations;

namespace HDV_Online.Migrations
{
    public partial class FKListeProduits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProduitsCommandes_Produits_IdProduit",
                table: "ProduitsCommandes");

            migrationBuilder.DropIndex(
                name: "IX_ProduitsCommandes_IdProduit",
                table: "ProduitsCommandes");

            migrationBuilder.DropColumn(
                name: "IdProduit",
                table: "ProduitsCommandes");

            migrationBuilder.AddColumn<int>(
                name: "IdProduit",
                table: "Produits",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produits_IdProduit",
                table: "Produits",
                column: "IdProduit");

            migrationBuilder.AddForeignKey(
                name: "FK_Produits_ProduitsCommandes_IdProduit",
                table: "Produits",
                column: "IdProduit",
                principalTable: "ProduitsCommandes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produits_ProduitsCommandes_IdProduit",
                table: "Produits");

            migrationBuilder.DropIndex(
                name: "IX_Produits_IdProduit",
                table: "Produits");

            migrationBuilder.DropColumn(
                name: "IdProduit",
                table: "Produits");

            migrationBuilder.AddColumn<int>(
                name: "IdProduit",
                table: "ProduitsCommandes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProduitsCommandes_IdProduit",
                table: "ProduitsCommandes",
                column: "IdProduit");

            migrationBuilder.AddForeignKey(
                name: "FK_ProduitsCommandes_Produits_IdProduit",
                table: "ProduitsCommandes",
                column: "IdProduit",
                principalTable: "Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
