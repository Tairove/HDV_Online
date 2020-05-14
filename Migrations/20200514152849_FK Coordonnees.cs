using Microsoft.EntityFrameworkCore.Migrations;

namespace HDV_Online.Migrations
{
    public partial class FKCoordonnees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coordonnee_Client_ClientId",
                table: "Coordonnee");

            migrationBuilder.DropForeignKey(
                name: "FK_Coordonnee_Pays_PaysId",
                table: "Coordonnee");

            migrationBuilder.AlterColumn<int>(
                name: "PaysId",
                table: "Coordonnee",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Coordonnee",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Coordonnee_Client_ClientId",
                table: "Coordonnee",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Coordonnee_Pays_PaysId",
                table: "Coordonnee",
                column: "PaysId",
                principalTable: "Pays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coordonnee_Client_ClientId",
                table: "Coordonnee");

            migrationBuilder.DropForeignKey(
                name: "FK_Coordonnee_Pays_PaysId",
                table: "Coordonnee");

            migrationBuilder.AlterColumn<int>(
                name: "PaysId",
                table: "Coordonnee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Coordonnee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Coordonnee_Client_ClientId",
                table: "Coordonnee",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Coordonnee_Pays_PaysId",
                table: "Coordonnee",
                column: "PaysId",
                principalTable: "Pays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
