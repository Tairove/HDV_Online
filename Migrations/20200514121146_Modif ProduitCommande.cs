using Microsoft.EntityFrameworkCore.Migrations;

namespace HDV_Online.Migrations
{
    public partial class ModifProduitCommande : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProduitsCommandes_Commandes_CommandeId",
                table: "ProduitsCommandes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProduitsCommandes_Produits_IdProduit",
                table: "ProduitsCommandes");

            migrationBuilder.DropIndex(
                name: "IX_ProduitsCommandes_CommandeId",
                table: "ProduitsCommandes");

            migrationBuilder.DropColumn(
                name: "CommandeId",
                table: "ProduitsCommandes");

            migrationBuilder.AlterColumn<int>(
                name: "IdProduit",
                table: "ProduitsCommandes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCommande",
                table: "ProduitsCommandes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrixTotalLigne",
                table: "ProduitsCommandes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrixTotalCommande",
                table: "Commandes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProduitsCommandes_IdCommande",
                table: "ProduitsCommandes",
                column: "IdCommande");

            migrationBuilder.AddForeignKey(
                name: "FK_ProduitsCommandes_Commandes_IdCommande",
                table: "ProduitsCommandes",
                column: "IdCommande",
                principalTable: "Commandes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProduitsCommandes_Produits_IdProduit",
                table: "ProduitsCommandes",
                column: "IdProduit",
                principalTable: "Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProduitsCommandes_Commandes_IdCommande",
                table: "ProduitsCommandes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProduitsCommandes_Produits_IdProduit",
                table: "ProduitsCommandes");

            migrationBuilder.DropIndex(
                name: "IX_ProduitsCommandes_IdCommande",
                table: "ProduitsCommandes");

            migrationBuilder.DropColumn(
                name: "IdCommande",
                table: "ProduitsCommandes");

            migrationBuilder.DropColumn(
                name: "PrixTotalLigne",
                table: "ProduitsCommandes");

            migrationBuilder.DropColumn(
                name: "PrixTotalCommande",
                table: "Commandes");

            migrationBuilder.AlterColumn<int>(
                name: "IdProduit",
                table: "ProduitsCommandes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CommandeId",
                table: "ProduitsCommandes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProduitsCommandes_CommandeId",
                table: "ProduitsCommandes",
                column: "CommandeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProduitsCommandes_Commandes_CommandeId",
                table: "ProduitsCommandes",
                column: "CommandeId",
                principalTable: "Commandes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
