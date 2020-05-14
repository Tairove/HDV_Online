using Microsoft.EntityFrameworkCore.Migrations;

namespace HDV_Online.Migrations
{
    public partial class FKClientCommercial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Utilisateur_UtilisateurId",
                table: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Client_UtilisateurId",
                table: "Client");

            migrationBuilder.AlterColumn<int>(
                name: "UtilisateurId",
                table: "Client",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommercialId",
                table: "Client",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Client_CommercialId",
                table: "Client",
                column: "CommercialId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_UtilisateurId",
                table: "Client",
                column: "UtilisateurId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Client_ListeClientCommercials_CommercialId",
                table: "Client",
                column: "CommercialId",
                principalTable: "ListeClientCommercials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Utilisateur_UtilisateurId",
                table: "Client",
                column: "UtilisateurId",
                principalTable: "Utilisateur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_ListeClientCommercials_CommercialId",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Client_Utilisateur_UtilisateurId",
                table: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Client_CommercialId",
                table: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Client_UtilisateurId",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "CommercialId",
                table: "Client");

            migrationBuilder.AlterColumn<int>(
                name: "UtilisateurId",
                table: "Client",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Client_UtilisateurId",
                table: "Client",
                column: "UtilisateurId",
                unique: true,
                filter: "[UtilisateurId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Utilisateur_UtilisateurId",
                table: "Client",
                column: "UtilisateurId",
                principalTable: "Utilisateur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
